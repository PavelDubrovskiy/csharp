using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Application.ZabbixIntegraion.Dto;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Mfc.Health.Corner.ZabbixIntegration.Dto;
using Mfc.Health.Corner.ZabbixIntegration.Repositories.Interfases;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class DashBordService : IDashBordService
    {
        private readonly IMfcCorenerStatisticPerDayRepository _mfcCorenerStatisticPerDayRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserManagementRepository _userManagementRepository;
        private readonly IHeadOfMfcRepository _headOfMfcRepository;
        private readonly IHeadOfDivisionRepository _headOfDivisionRepository;
        private readonly IMfcCornerRepository _mfcCornerRepository;
        private readonly ITriggersRepository _triggersRepository;

        public DashBordService(
            IMfcCorenerStatisticPerDayRepository mfcCorenerStatisticPerDayRepository,
            IUserRoleRepository userRoleRepository,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUserManagementRepository userManagementRepository,
            IHeadOfMfcRepository headOfMfcRepository,
            IHeadOfDivisionRepository headOfDivisionRepository,
            IMfcCornerRepository mfcCornerRepository,
            ITriggersRepository triggersRepository
        )
        {
            _mfcCorenerStatisticPerDayRepository = mfcCorenerStatisticPerDayRepository;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _userManagementRepository = userManagementRepository;
            _headOfMfcRepository = headOfMfcRepository;
            _headOfDivisionRepository = headOfDivisionRepository;
            _mfcCornerRepository = mfcCornerRepository;
            _triggersRepository = triggersRepository;
        }

        public async Task<OperationResult<CommonCircleDiagramData>> GetCircleDiagramsData(string jwt)
        {
            try
            {
                var requestUserId = GetUserIdFromJwt(jwt);
                User requestUser = null;

                if (string.IsNullOrWhiteSpace(requestUserId))
                {
                    return OperationResult.Error<CommonCircleDiagramData>("Invalid Claims", OperationCode.ValidationError);
                }
                else
                {
                    requestUser = await _userRepository.GetUserByIdAsync(requestUserId);
                    if (requestUser == null)
                    {
                        return OperationResult.Error<CommonCircleDiagramData>("User with current token not exist", OperationCode.EntityWasNotFound);
                    }
                }

                var AdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "Admin" })).FirstOrDefault().Id;
                var SuperAdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "SuperAdmin" })).FirstOrDefault().Id;
                var headOfDivisionRoleId =
                   (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;
                var HeadOfMfcRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;
                var UserManagementRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "UserManagement" })).FirstOrDefault().Id;

                var userRoles = await _userRoleRepository.GetUserRolesByUserIdsAsync(
                    new List<string> { requestUserId });
                if (userRoles.Where(x => x.RoleId.Equals(AdminId)).Count() > 0 ||
                    userRoles.Where(x => x.RoleId.Equals(SuperAdminId)).Count() > 0)
                {
                    var allMfcCorners = await _mfcCornerRepository.GetAllMfcAsync();
                    var commonResult = await GetCircleDateForMfcCornerList(allMfcCorners);
                    commonResult = CalculateProcents(commonResult);
                    return OperationResult<CommonCircleDiagramData>.Ok(commonResult);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).First();
                    var headOfDivision = await _headOfDivisionRepository.GetHeadOfDivisionByUserRoleId(userRole.Id);
                    var divisionMfcCorners = await _mfcCornerRepository.GetDivisionMfcCornersAsync(headOfDivision.DistrictId);
                    var commonResult = await GetCircleDateForMfcCornerList(divisionMfcCorners);
                    commonResult = CalculateProcents(commonResult);
                    return OperationResult<CommonCircleDiagramData>.Ok(commonResult);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).First();
                    var HeadOfMfc = await _headOfMfcRepository.GetHeadOfMfcByUserRoleId(userRole.Id);
                    var result = await GetCircleDateForSingleMfc(HeadOfMfc.MfcCornerId);
                    result = CalculateProcents(result);
                    return OperationResult<CommonCircleDiagramData>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).First();
                    var userManagement = await _userManagementRepository.GetUserManagementUserRoleId(userRole.Id);
                    var result = await GetCircleDateForSingleMfc(userManagement.MfcCornerId);
                    result = CalculateProcents(result);
                    return OperationResult<CommonCircleDiagramData>.Ok(result);
                }

                throw new ArgumentNullException(" CurrentUserRole ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OperationResult<StockCountResearchDto>> GetStockDiagramByMedDevice(string jwt)
        {
            try
            {
                var requestUserId = GetUserIdFromJwt(jwt);
                User requestUser = null;

                if (string.IsNullOrWhiteSpace(requestUserId))
                {
                    return OperationResult.Error<StockCountResearchDto>("Invalid Claims", OperationCode.ValidationError);
                }
                else
                {
                    requestUser = await _userRepository.GetUserByIdAsync(requestUserId);
                    if (requestUser == null)
                    {
                        return OperationResult.Error<StockCountResearchDto>("User with current token not exist", OperationCode.EntityWasNotFound);
                    }
                }

                var AdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "Admin" })).FirstOrDefault().Id;
                var SuperAdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "SuperAdmin" })).FirstOrDefault().Id;
                var headOfDivisionRoleId =
                   (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;
                var HeadOfMfcRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;
                var UserManagementRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "UserManagement" })).FirstOrDefault().Id;

                var userRoles = await _userRoleRepository.GetUserRolesByUserIdsAsync(
                    new List<string> { requestUserId });
                if (userRoles.Where(x => x.RoleId.Equals(AdminId)).Count() > 0 ||
                    userRoles.Where(x => x.RoleId.Equals(SuperAdminId)).Count() > 0)
                {
                    var allMfcCorners = await _mfcCornerRepository.GetAllMfcAsync();
                    var result = await GetStockCountResearchForMfcCornerList(allMfcCorners);
                    return OperationResult<StockCountResearchDto>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).First();
                    var headOfDivision = await _headOfDivisionRepository.GetHeadOfDivisionByUserRoleId(userRole.Id);
                    var divisionMfcCorners = await _mfcCornerRepository.GetDivisionMfcCornersAsync(headOfDivision.DistrictId);
                    var result = await GetStockCountResearchForMfcCornerList(divisionMfcCorners);
                    return OperationResult<StockCountResearchDto>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).First();
                    var HeadOfMfc = await _headOfMfcRepository.GetHeadOfMfcByUserRoleId(userRole.Id);
                    var result = await GetStockCountResearchForSingleMfc(HeadOfMfc.MfcCornerId);
                    return OperationResult<StockCountResearchDto>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).First();
                    var userManagement = await _userManagementRepository.GetUserManagementUserRoleId(userRole.Id);
                    var result = await GetStockCountResearchForSingleMfc(userManagement.MfcCornerId);
                    return OperationResult<StockCountResearchDto>.Ok(result);
                }
                throw new ArgumentNullException(" CurrentUserRole ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OperationResult<ResearchDynamicsDto>> GetResearchDynamics(string jwt)
        {
            try
            {
                var requestUserId = GetUserIdFromJwt(jwt);
                User requestUser = null;

                if (string.IsNullOrWhiteSpace(requestUserId))
                {
                    return OperationResult.Error<ResearchDynamicsDto>("Invalid Claims", OperationCode.ValidationError);
                }
                else
                {
                    requestUser = await _userRepository.GetUserByIdAsync(requestUserId);
                    if (requestUser == null)
                    {
                        return OperationResult.Error<ResearchDynamicsDto>("User with current token not exist", OperationCode.EntityWasNotFound);
                    }
                }

                var AdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "Admin" })).FirstOrDefault().Id;
                var SuperAdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "SuperAdmin" })).FirstOrDefault().Id;
                var headOfDivisionRoleId =
                   (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;
                var HeadOfMfcRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;
                var UserManagementRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "UserManagement" })).FirstOrDefault().Id;

                var userRoles = await _userRoleRepository.GetUserRolesByUserIdsAsync(
                    new List<string> { requestUserId });
                if (userRoles.Where(x => x.RoleId.Equals(AdminId)).Count() > 0 ||
                    userRoles.Where(x => x.RoleId.Equals(SuperAdminId)).Count() > 0)
                {
                    var allMfcCorners = await _mfcCornerRepository.GetAllMfcAsync();
                    var result = await GetResearchDynamicsDtoForListMfc(allMfcCorners);
                    return OperationResult<ResearchDynamicsDto>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).First();
                    var headOfDivision = await _headOfDivisionRepository.GetHeadOfDivisionByUserRoleId(userRole.Id);
                    var divisionMfcCorners = await _mfcCornerRepository.GetDivisionMfcCornersAsync(headOfDivision.DistrictId);
                    var result = await GetResearchDynamicsDtoForListMfc(divisionMfcCorners);
                    return OperationResult<ResearchDynamicsDto>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).First();
                    var HeadOfMfc = await _headOfMfcRepository.GetHeadOfMfcByUserRoleId(userRole.Id);
                    var result = await GetResearchDynamicsDtoForSingleMfc(HeadOfMfc.MfcCornerId);
                    return OperationResult<ResearchDynamicsDto>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).First();
                    var userManagement = await _userManagementRepository.GetUserManagementUserRoleId(userRole.Id);
                    var result = await GetResearchDynamicsDtoForSingleMfc(userManagement.MfcCornerId);
                    return OperationResult<ResearchDynamicsDto>.Ok(result);
                }
                throw new ArgumentNullException(" CurrentUserRole ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private async Task<ResearchDynamicsDto> GetResearchDynamicsDtoForListMfc(List<MfcCorner> mfcCorners)
        {
            try
            {
                ResearchDynamicsDto researchDynamics = GetDefautResearchDynamicsDto();
                researchDynamics.DynamicResearch[0].count_1 = mfcCorners.Count;
                foreach (var mfcCorner in mfcCorners)
                {
                    var singleMfcStatistic = await GetResearchDynamicsDtoForSingleMfc(mfcCorner.Id);
                    researchDynamics.DynamicResearch[1].count_1 += singleMfcStatistic.DynamicResearch[1].count_1;
                    researchDynamics.DynamicResearch[2].count_1 += singleMfcStatistic.DynamicResearch[2].count_1;

                    researchDynamics.DynamicResearch[3].count_1 += singleMfcStatistic.DynamicResearch[3].count_1;
                    researchDynamics.DynamicResearch[3].count_0 += singleMfcStatistic.DynamicResearch[3].count_0;

                    researchDynamics.DynamicResearch[4].count_1 += singleMfcStatistic.DynamicResearch[4].count_1;
                    researchDynamics.DynamicResearch[4].count_0 += singleMfcStatistic.DynamicResearch[4].count_0;

                    researchDynamics.DynamicResearch[5].count_1 += singleMfcStatistic.DynamicResearch[5].count_1;
                    researchDynamics.DynamicResearch[5].count_0 += singleMfcStatistic.DynamicResearch[5].count_0;

                    if (researchDynamics.AverageAttendancePerWeek.Count == 0)
                    {
                        researchDynamics.AverageAttendancePerWeek = singleMfcStatistic.AverageAttendancePerWeek;
                        researchDynamics.CornerCountPerWeek = singleMfcStatistic.CornerCountPerWeek;
                        researchDynamics.VisitsPerWeek = singleMfcStatistic.VisitsPerWeek;
                        researchDynamics.SpecialistCallPerWeek = singleMfcStatistic.SpecialistCallPerWeek;
                        researchDynamics.DoctorsAppointmentPerWeek = singleMfcStatistic.DoctorsAppointmentPerWeek;
                        researchDynamics.SendEmiasToEmiasPerWeek = singleMfcStatistic.SendEmiasToEmiasPerWeek;

                    }
                    else
                    {
                        for (int i = 0; i < researchDynamics.AverageAttendancePerWeek.Count; i++)
                        {
                            researchDynamics.AverageAttendancePerWeek[i].Value += singleMfcStatistic.AverageAttendancePerWeek[i].Value;
                            //researchDynamics.AverageAttendancePerWeek[i].Value += singleMfcStatistic.AverageAttendancePerWeek[i].Value;
                            researchDynamics.CornerCountPerWeek[i].Value += singleMfcStatistic.CornerCountPerWeek[i].Value;
                            researchDynamics.VisitsPerWeek[i].Value += singleMfcStatistic.VisitsPerWeek[i].Value;
                            researchDynamics.SpecialistCallPerWeek[i].Value += singleMfcStatistic.SpecialistCallPerWeek[i].Value;
                            researchDynamics.DoctorsAppointmentPerWeek[i].Value += singleMfcStatistic.DoctorsAppointmentPerWeek[i].Value;
                            researchDynamics.SendEmiasToEmiasPerWeek[i].Value += singleMfcStatistic.SendEmiasToEmiasPerWeek[i].Value;


                        }
                    }
                }

                return researchDynamics;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<ResearchDynamicsDto> GetResearchDynamicsDtoForSingleMfc(string mfcCornerId)
        {
            try
            {
                DateTime startDate = DateTime.Now.AddDays(-365);
                DateTime endDate = DateTime.Now;

                ResearchDynamicsDto researchDynamics = GetDefautResearchDynamicsDto();
                researchDynamics.DynamicResearch[0].count_1 = 1;

                while (startDate < endDate)
                {
                    var cycleDate = startDate.AddDays(7) < endDate ? startDate.AddDays(8) < endDate ? startDate.AddDays(7) : endDate : endDate;

                    var averageAttendancePerWeek = getDefaultResearchDynamicsStatisticPoint(cycleDate);
                    var cornerCountPerWeek = getDefaultResearchDynamicsStatisticPoint(cycleDate);
                    var visitsPerWeek = getDefaultResearchDynamicsStatisticPoint(cycleDate);
                    var specialistCallPerWeek = getDefaultResearchDynamicsStatisticPoint(cycleDate);

                    var sendEmiasToEmiasPerWeek = getDefaultResearchDynamicsStatisticPoint(cycleDate);
                    var doctorsAppointmentPerWeek = getDefaultResearchDynamicsStatisticPoint(cycleDate);

                    var mfcIsExist = await _mfcCornerRepository.IsMfcExistInCurrentDate(endDate, mfcCornerId);
                    if (mfcIsExist)
                    {
                        var weekData = await _mfcCorenerStatisticPerDayRepository.GetStatisticForPeriod(startDate, cycleDate, mfcCornerId);
                        cornerCountPerWeek.Value = 1;
                        foreach (var elem in weekData)
                        {
                            specialistCallPerWeek.Value += elem.SpecialistCall;
                            visitsPerWeek.Value += elem.FullExamCount + elem.NotFullExamCount;

                            sendEmiasToEmiasPerWeek.Value += elem.SendEmiasCount;
                            doctorsAppointmentPerWeek.Value += elem.DoctorsAppointmentCount;
                        }
                        averageAttendancePerWeek.Value = visitsPerWeek.Value / 7;
                    }

                    researchDynamics.AverageAttendancePerWeek.Add(averageAttendancePerWeek);
                    researchDynamics.CornerCountPerWeek.Add(cornerCountPerWeek);
                    researchDynamics.SpecialistCallPerWeek.Add(specialistCallPerWeek);
                    researchDynamics.VisitsPerWeek.Add(visitsPerWeek);

                    researchDynamics.DoctorsAppointmentPerWeek.Add(doctorsAppointmentPerWeek);
                    researchDynamics.SendEmiasToEmiasPerWeek.Add(sendEmiasToEmiasPerWeek);

                    startDate = cycleDate;
                }

                var data = await _mfcCorenerStatisticPerDayRepository.GetStatisticForPeriod(DateTime.Now.AddDays(-7), DateTime.Now, mfcCornerId);
                foreach (var elem in data)
                {
                    researchDynamics.DynamicResearch[1].count_1 += elem.FullExamCount + elem.NotFullExamCount;
                    researchDynamics.DynamicResearch[4].count_1 += elem.SpecialistCall;
                    researchDynamics.DynamicResearch[5].count_1 += elem.SendEmiasCount;
                    researchDynamics.DynamicResearch[3].count_1 += elem.DoctorsAppointmentCount;

                }
                researchDynamics.DynamicResearch[2].count_1 = researchDynamics.DynamicResearch[1].count_1 / 7;
                researchDynamics.DynamicResearch[3].count_0 += researchDynamics.DynamicResearch[3].count_1 / 7;
                researchDynamics.DynamicResearch[4].count_0 += researchDynamics.DynamicResearch[4].count_1 / 7;
                researchDynamics.DynamicResearch[5].count_0 += researchDynamics.DynamicResearch[5].count_1 / 7;

                return researchDynamics;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private ResearchDynamicsStatisticPointPerWeekDto getDefaultResearchDynamicsStatisticPoint(DateTime date)
        {
            return new ResearchDynamicsStatisticPointPerWeekDto
            {
                Date = $"{date.Year}-{date.Month}-{date.Day}",
                Value = 0
            };
        }


        public async Task<OperationResult<UpdateResearchDynamicsDto>> UpdateResearchDynamics(string jwt)
        {
            try
            {
                var requestUserId = GetUserIdFromJwt(jwt);
                User requestUser = null;

                if (string.IsNullOrWhiteSpace(requestUserId))
                {
                    return OperationResult.Error<UpdateResearchDynamicsDto>("Invalid Claims", OperationCode.ValidationError);
                }
                else
                {
                    requestUser = await _userRepository.GetUserByIdAsync(requestUserId);
                    if (requestUser == null)
                    {
                        return OperationResult.Error<UpdateResearchDynamicsDto>("User with current token not exist", OperationCode.EntityWasNotFound);
                    }
                }

                var AdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "Admin" })).FirstOrDefault().Id;
                var SuperAdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "SuperAdmin" })).FirstOrDefault().Id;
                var headOfDivisionRoleId =
                   (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;
                var HeadOfMfcRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;
                var UserManagementRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "UserManagement" })).FirstOrDefault().Id;

                var userRoles = await _userRoleRepository.GetUserRolesByUserIdsAsync(
                    new List<string> { requestUserId });
                if (userRoles.Where(x => x.RoleId.Equals(AdminId)).Count() > 0 ||
                    userRoles.Where(x => x.RoleId.Equals(SuperAdminId)).Count() > 0)
                {
                    var allMfcCorners = await _mfcCornerRepository.GetAllMfcAsync();
                    var result = await UpdateResearchDynamicsDtoForListMfc(allMfcCorners);
                    return OperationResult<UpdateResearchDynamicsDto>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).First();
                    var headOfDivision = await _headOfDivisionRepository.GetHeadOfDivisionByUserRoleId(userRole.Id);
                    var divisionMfcCorners = await _mfcCornerRepository.GetDivisionMfcCornersAsync(headOfDivision.DistrictId);
                    var result = await UpdateResearchDynamicsDtoForListMfc(divisionMfcCorners);
                    return OperationResult<UpdateResearchDynamicsDto>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).First();
                    var HeadOfMfc = await _headOfMfcRepository.GetHeadOfMfcByUserRoleId(userRole.Id);
                    var result = await UpdateResearchDynamicsDtoForSingleMfc(HeadOfMfc.MfcCornerId);
                    return OperationResult<UpdateResearchDynamicsDto>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).First();
                    var userManagement = await _userManagementRepository.GetUserManagementUserRoleId(userRole.Id);
                    var result = await UpdateResearchDynamicsDtoForSingleMfc(userManagement.MfcCornerId);
                    return OperationResult<UpdateResearchDynamicsDto>.Ok(result);
                }
                throw new ArgumentNullException(" CurrentUserRole ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<UpdateResearchDynamicsDto> UpdateResearchDynamicsDtoForListMfc(List<MfcCorner> mfcCorners)
        {
            try
            {
                var researchDynamics = GetDefaultUpdateResearchDynamicsDto();
                researchDynamics.DynamicResearch[0].count_1 = mfcCorners.Count;
                foreach (var mfcCorner in mfcCorners)
                {
                    var singleMfcStatistic = await UpdateResearchDynamicsDtoForSingleMfc(mfcCorner.Id);

                    researchDynamics.DynamicResearch[1].count_1 += singleMfcStatistic.DynamicResearch[1].count_1;
                    researchDynamics.DynamicResearch[2].count_1 += singleMfcStatistic.DynamicResearch[2].count_1;

                    researchDynamics.DynamicResearch[4].count_1 += singleMfcStatistic.DynamicResearch[4].count_1;
                    researchDynamics.DynamicResearch[4].count_0 += singleMfcStatistic.DynamicResearch[4].count_0;

                    researchDynamics.DynamicResearch[3].count_1 += singleMfcStatistic.DynamicResearch[3].count_1;
                    researchDynamics.DynamicResearch[3].count_0 += singleMfcStatistic.DynamicResearch[3].count_0;

                    researchDynamics.DynamicResearch[5].count_1 += singleMfcStatistic.DynamicResearch[5].count_1;
                    researchDynamics.DynamicResearch[5].count_0 += singleMfcStatistic.DynamicResearch[5].count_0;

                    researchDynamics.AverageAttendancePerWeek.Value += singleMfcStatistic.AverageAttendancePerWeek.Value;
                    researchDynamics.CornerCountPerWeek.Value += singleMfcStatistic.CornerCountPerWeek.Value;
                    researchDynamics.VisitsPerWeek.Value += singleMfcStatistic.VisitsPerWeek.Value;
                    researchDynamics.SpecialistCallPerWeek.Value += singleMfcStatistic.SpecialistCallPerWeek.Value;
                    researchDynamics.DoctorsApointmentPerWeek.Value += singleMfcStatistic.DoctorsApointmentPerWeek.Value;
                    researchDynamics.SendEmiasPerWeek.Value += singleMfcStatistic.SendEmiasPerWeek.Value;
                }

                return researchDynamics;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<UpdateResearchDynamicsDto> UpdateResearchDynamicsDtoForSingleMfc(string mfcCornerId)
        {
            try
            {
                DateTime startDate = DateTime.Now.AddDays(-8);
                DateTime endDate = DateTime.Now;

                UpdateResearchDynamicsDto researchDynamics = GetDefaultUpdateResearchDynamicsDto();
                researchDynamics.DynamicResearch[0].count_1 = 1;

                var mfcIsExist = await _mfcCornerRepository.IsMfcExistInCurrentDate(endDate, mfcCornerId);
                if (mfcIsExist)
                {
                    var weekData = await _mfcCorenerStatisticPerDayRepository.GetStatisticForPeriod(startDate, endDate, mfcCornerId);
                    researchDynamics.CornerCountPerWeek.Value = 1;
                    foreach (var elem in weekData)
                    {
                        researchDynamics.SpecialistCallPerWeek.Value += elem.SpecialistCall;
                        researchDynamics.DoctorsApointmentPerWeek.Value += elem.DoctorsAppointmentCount;
                        researchDynamics.SendEmiasPerWeek.Value += elem.SendEmiasCount;
                        researchDynamics.VisitsPerWeek.Value += elem.FullExamCount + elem.NotFullExamCount;
                    }
                    researchDynamics.AverageAttendancePerWeek.Value = researchDynamics.VisitsPerWeek.Value / 7;
                }


                var data = await _mfcCorenerStatisticPerDayRepository.GetStatisticForPeriod(DateTime.Now.AddDays(-7), DateTime.Now, mfcCornerId);
                foreach (var elem in data)
                {
                    researchDynamics.DynamicResearch[1].count_1 += elem.FullExamCount + elem.NotFullExamCount;
                    researchDynamics.DynamicResearch[4].count_1 += elem.SpecialistCall;
                    researchDynamics.DynamicResearch[3].count_1 += elem.DoctorsAppointmentCount;
                    researchDynamics.DynamicResearch[5].count_1 += elem.SendEmiasCount;
                }
                researchDynamics.DynamicResearch[2].count_1 = researchDynamics.DynamicResearch[1].count_1 / 7;
                researchDynamics.DynamicResearch[4].count_0 += researchDynamics.DynamicResearch[4].count_1 / 7;
                researchDynamics.DynamicResearch[3].count_0 += researchDynamics.DynamicResearch[3].count_1 / 7;
                researchDynamics.DynamicResearch[5].count_0 += researchDynamics.DynamicResearch[5].count_1 / 7;

                return researchDynamics;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private UpdateResearchDynamicsDto GetDefaultUpdateResearchDynamicsDto()
        {
            DateTime startDate = DateTime.Now.AddDays(-8);
            DateTime endDate = DateTime.Now;
            UpdateResearchDynamicsDto researchDynamics = new UpdateResearchDynamicsDto
            {
                DynamicResearch = GetDefaultResearchDynamicsDescriptionDto(),
                AverageAttendancePerWeek = new ResearchDynamicsStatisticPointPerWeekDto
                {
                    Date = $"{endDate.Year}-{endDate.Month}-{endDate.Day}",
                    Value = 0
                },
                CornerCountPerWeek = new ResearchDynamicsStatisticPointPerWeekDto
                {
                    Date = $"{endDate.Year}-{endDate.Month}-{endDate.Day}",
                    Value = 0
                },
                SpecialistCallPerWeek = new ResearchDynamicsStatisticPointPerWeekDto
                {
                    Date = $"{endDate.Year}-{endDate.Month}-{endDate.Day}",
                    Value = 0
                },
                VisitsPerWeek = new ResearchDynamicsStatisticPointPerWeekDto
                {
                    Date = $"{endDate.Year}-{endDate.Month}-{endDate.Day}",
                    Value = 0
                },
                DoctorsApointmentPerWeek = new ResearchDynamicsStatisticPointPerWeekDto
                {
                    Date = $"{endDate.Year}-{endDate.Month}-{endDate.Day}",
                    Value = 0
                },
                SendEmiasPerWeek = new ResearchDynamicsStatisticPointPerWeekDto
                {
                    Date = $"{endDate.Year}-{endDate.Month}-{endDate.Day}",
                    Value = 0
                }
            };
            return researchDynamics;
        }

        private List<ResearchDynamicsDescriptionDto> GetDefaultResearchDynamicsDescriptionDto()
        {
            var result = new List<ResearchDynamicsDescriptionDto>
                    {
                        new ResearchDynamicsDescriptionDto
                        {
                            title = "MfcCorner Count",
                            Color = "#783291",
                            count_0 = 0,
                            count_1 = 0,
                            show = true
                        },
                        new ResearchDynamicsDescriptionDto
                        {
                            title = "visits per week",
                            Color = "#ED9937",
                            count_0 = 0,
                            count_1 = 0,
                            show = true
                        },
                        new ResearchDynamicsDescriptionDto
                        {
                            title = "Average attendance per week",
                            Color = "#FD49C0",
                            count_0 = 0,
                            count_1 = 0,
                            show = true
                        },
                        new ResearchDynamicsDescriptionDto
                        {
                            title = "Doctor's appointment",
                            Color = "#31C824",
                            count_0 = 0,
                            count_1 = 0,
                            show = true
                        },
                        new ResearchDynamicsDescriptionDto
                        {
                            title = "Specialist Call",
                            Color = "#DA4747",
                            count_0 = 0,
                            count_1 = 0,
                            show = true
                        },
                        new ResearchDynamicsDescriptionDto
                        {
                            title =  "Emias",
                            Color = "#00ADB8",
                            count_0 = 0,
                            count_1 = 0,
                            show = true
                        },
                    };
            return result;
        }

        private ResearchDynamicsDto GetDefautResearchDynamicsDto()
        {
            ResearchDynamicsDto researchDynamics = new ResearchDynamicsDto
            {
                DynamicResearch = GetDefaultResearchDynamicsDescriptionDto(),
                AverageAttendancePerWeek = new List<ResearchDynamicsStatisticPointPerWeekDto>(),
                CornerCountPerWeek = new List<ResearchDynamicsStatisticPointPerWeekDto>(),
                VisitsPerWeek = new List<ResearchDynamicsStatisticPointPerWeekDto>(),
                SpecialistCallPerWeek = new List<ResearchDynamicsStatisticPointPerWeekDto>(),
                DoctorsAppointmentPerWeek = new List<ResearchDynamicsStatisticPointPerWeekDto>(),
                SendEmiasToEmiasPerWeek = new List<ResearchDynamicsStatisticPointPerWeekDto>()
            };

            return researchDynamics;
        }

        public async Task<OperationResult<List<CornerPopularityDto>>> GetMfcPopularityDataDto(string jwt)
        {
            try
            {
                var requestUserId = GetUserIdFromJwt(jwt);
                User requestUser = null;

                if (string.IsNullOrWhiteSpace(requestUserId))
                {
                    return OperationResult.Error<List<CornerPopularityDto>>("Invalid Claims", OperationCode.ValidationError);
                }
                else
                {
                    requestUser = await _userRepository.GetUserByIdAsync(requestUserId);
                    if (requestUser == null)
                    {
                        return OperationResult.Error<List<CornerPopularityDto>>("User with current token not exist", OperationCode.EntityWasNotFound);
                    }
                }

                var AdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "Admin" })).FirstOrDefault().Id;
                var SuperAdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "SuperAdmin" })).FirstOrDefault().Id;
                var headOfDivisionRoleId =
                   (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;
                var HeadOfMfcRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;
                var UserManagementRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "UserManagement" })).FirstOrDefault().Id;

                var userRoles = await _userRoleRepository.GetUserRolesByUserIdsAsync(
                    new List<string> { requestUserId });
                if (userRoles.Where(x => x.RoleId.Equals(AdminId)).Count() > 0 ||
                    userRoles.Where(x => x.RoleId.Equals(SuperAdminId)).Count() > 0)
                {
                    var allMfcCorners = await _mfcCornerRepository.GetAllMfcAsync();
                    var result = await GetPopularityDataForListMfc(allMfcCorners);
                    return OperationResult<List<CornerPopularityDto>>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).First();
                    var headOfDivision = await _headOfDivisionRepository.GetHeadOfDivisionByUserRoleId(userRole.Id);
                    var divisionMfcCorners = await _mfcCornerRepository.GetDivisionMfcCornersAsync(headOfDivision.DistrictId);
                    var result = await GetPopularityDataForListMfc(divisionMfcCorners);
                    return OperationResult<List<CornerPopularityDto>>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).First();
                    var HeadOfMfc = await _headOfMfcRepository.GetHeadOfMfcByUserRoleId(userRole.Id);
                    List<CornerPopularityDto> result = new List<CornerPopularityDto>();
                    var singleMfcData = await GetPopularityDataForSingleMfc(HeadOfMfc.MfcCornerId);
                    result.Add(singleMfcData);
                    return OperationResult<List<CornerPopularityDto>>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).First();
                    var userManagement = await _userManagementRepository.GetUserManagementUserRoleId(userRole.Id);
                    List<CornerPopularityDto> result = new List<CornerPopularityDto>();
                    var singleMfcData = await GetPopularityDataForSingleMfc(userManagement.MfcCornerId);
                    result.Add(singleMfcData);
                    return OperationResult<List<CornerPopularityDto>>.Ok(result);
                }
                throw new ArgumentNullException(" CurrentUserRole ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<List<CornerPopularityDto>> GetPopularityDataForListMfc(List<MfcCorner> divisionMfcCorners)
        {
            try
            {
                List<CornerPopularityDto> result = new List<CornerPopularityDto>();
                foreach (var corner in divisionMfcCorners)
                {
                    var conerData = await GetPopularityDataForSingleMfc(corner.Id);
                    result.Add(conerData);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<CornerPopularityDto> GetPopularityDataForSingleMfc(string mfcCornerId)
        {
            try
            {
                var data = await _mfcCorenerStatisticPerDayRepository.GetStatisticForPeriod(null, null, mfcCornerId);
                var mfc = await _mfcCornerRepository.GetMfcAsync(mfcCornerId);
                CornerPopularityDto cornerPopularity = new CornerPopularityDto
                {
                    Title = mfc.Name,
                    Average = 0,
                    Devices = new DeviceInfoDto
                    {
                        Analyzer = 0,
                        Bpbio = 0,
                        Bsm = 0,
                        Gaz = 0,
                        Pulse = 0
                    },
                    Full = new ExamCountsForTypeDto
                    {
                        full = 0,
                        unfull = 0,
                    },
                    Total = 0

                };
                foreach (var elem in data)
                {
                    cornerPopularity.Devices.Analyzer += elem.AnalyzerCount;
                    cornerPopularity.Devices.Bpbio += elem.BPBIOCount;
                    cornerPopularity.Devices.Bsm += elem.BsmCount;
                    cornerPopularity.Devices.Gaz += elem.GazCount;
                    cornerPopularity.Devices.Pulse += elem.PulseCount;
                    cornerPopularity.Full.full += elem.FullExamCount;
                    cornerPopularity.Full.unfull += elem.NotFullExamCount;
                    cornerPopularity.Total += elem.NotFullExamCount + elem.FullExamCount;
                }

                cornerPopularity.Average = cornerPopularity.Total / 7;

                return cornerPopularity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<StockCountResearchDto> GetStockCountResearchForMfcCornerList(List<MfcCorner> divisionMfcCorners)
        {
            StockCountResearchDto stockCountResearchResult = null;

            foreach (var corner in divisionMfcCorners)
            {
                if (stockCountResearchResult == null)
                {
                    stockCountResearchResult = await GetStockCountResearchForSingleMfc(corner.Id);
                }
                else
                {
                    var cornerData = await GetStockCountResearchForSingleMfc(corner.Id);
                    for (int i = 0; i < stockCountResearchResult.countResearchDeviceInfo.Count; i++)
                    {
                        stockCountResearchResult.countResearchDeviceInfo[i].Analyzer += cornerData.countResearchDeviceInfo[i].Analyzer;
                        stockCountResearchResult.countResearchDeviceInfo[i].Bpbio += cornerData.countResearchDeviceInfo[i].Bpbio;
                        stockCountResearchResult.countResearchDeviceInfo[i].Bsm += cornerData.countResearchDeviceInfo[i].Bsm;
                        stockCountResearchResult.countResearchDeviceInfo[i].Gaz += cornerData.countResearchDeviceInfo[i].Gaz;
                        stockCountResearchResult.countResearchDeviceInfo[i].Pulse += cornerData.countResearchDeviceInfo[i].Pulse;

                        stockCountResearchResult.countResearchFullUnfullInfo[i].Full += cornerData.countResearchFullUnfullInfo[i].Full;
                        stockCountResearchResult.countResearchFullUnfullInfo[i].Unfull += cornerData.countResearchFullUnfullInfo[i].Unfull;
                    }
                }
            }
            return stockCountResearchResult;
        }

        private async Task<StockCountResearchDto> GetStockCountResearchForSingleMfc(string mfcCornerId)
        {
            try
            {
                var end = DateTime.Today.AddHours(23).AddMinutes(59);
                var start = DateTime.Today.AddDays(-30);

                StockCountResearchDto stockCountResearchResult = new StockCountResearchDto
                {
                    countResearchDeviceInfo = new List<StockCountResearchDeviceInfoDto>(),
                    countResearchFullUnfullInfo = new List<StockCountResearchFullUnfullInfoDto>()
                };

                var data = await _mfcCorenerStatisticPerDayRepository.GetStatisticForPeriod(start, end, mfcCornerId);
                for (int i = 0; i <= 30; i++)
                {
                    int dayIndexToAdd = -30 + i;
                    var currentDatestart = DateTime.Today.AddDays(dayIndexToAdd);
                    var currentDateEnd = DateTime.Today.AddDays(dayIndexToAdd).AddHours(23).AddMinutes(59);
                    var currentDayData = data.Where(x => x.Date >= currentDatestart && x.Date <= currentDateEnd).FirstOrDefault();
                    if (currentDayData == null)
                    {
                        stockCountResearchResult.countResearchDeviceInfo.Add(
                           new StockCountResearchDeviceInfoDto
                           {
                               Analyzer = 0,
                               Bpbio = 0,
                               Bsm = 0,
                               Gaz = 0,
                               Pulse = 0,
                               Group = currentDatestart.Day.ToString()
                           });

                        stockCountResearchResult.countResearchFullUnfullInfo.Add(
                            new StockCountResearchFullUnfullInfoDto
                            {
                                Full = 0,
                                Unfull = 0,
                                Group = currentDatestart.Day.ToString()
                            });
                    }
                    else
                    {
                        stockCountResearchResult.countResearchDeviceInfo.Add(
                            new StockCountResearchDeviceInfoDto
                            {
                                Analyzer = currentDayData.AnalyzerCount,
                                Bpbio = currentDayData.BPBIOCount,
                                Bsm = currentDayData.BsmCount,
                                Gaz = currentDayData.GazCount,
                                Pulse = currentDayData.PulseCount,
                                Group = currentDatestart.Day.ToString()
                            });
                        stockCountResearchResult.countResearchFullUnfullInfo.Add(
                            new StockCountResearchFullUnfullInfoDto
                            {
                                Full = currentDayData.FullExamCount,
                                Unfull = currentDayData.NotFullExamCount,
                                Group = currentDatestart.Day.ToString()
                            });
                    }
                }
                return stockCountResearchResult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OperationResult<UpdateStockCountResearchDto>> UpdateStockDiagramByMedDevice(string jwt)
        {
            try
            {
                var requestUserId = GetUserIdFromJwt(jwt);
                User requestUser = null;

                if (string.IsNullOrWhiteSpace(requestUserId))
                {
                    return OperationResult.Error<UpdateStockCountResearchDto>("Invalid Claims", OperationCode.ValidationError);
                }
                else
                {
                    requestUser = await _userRepository.GetUserByIdAsync(requestUserId);
                    if (requestUser == null)
                    {
                        return OperationResult.Error<UpdateStockCountResearchDto>("User with current token not exist", OperationCode.EntityWasNotFound);
                    }
                }

                var AdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "Admin" })).FirstOrDefault().Id;
                var SuperAdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "SuperAdmin" })).FirstOrDefault().Id;
                var headOfDivisionRoleId =
                   (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;
                var HeadOfMfcRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;
                var UserManagementRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "UserManagement" })).FirstOrDefault().Id;

                var userRoles = await _userRoleRepository.GetUserRolesByUserIdsAsync(
                    new List<string> { requestUserId });
                if (userRoles.Where(x => x.RoleId.Equals(AdminId)).Count() > 0 ||
                    userRoles.Where(x => x.RoleId.Equals(SuperAdminId)).Count() > 0)
                {
                    var allMfcCorners = await _mfcCornerRepository.GetAllMfcAsync();
                    var result = await UpdateStockCountResearchForMfcCornerList(allMfcCorners);
                    return OperationResult<UpdateStockCountResearchDto>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).First();
                    var headOfDivision = await _headOfDivisionRepository.GetHeadOfDivisionByUserRoleId(userRole.Id);
                    var divisionMfcCorners = await _mfcCornerRepository.GetDivisionMfcCornersAsync(headOfDivision.DistrictId);
                    var result = await UpdateStockCountResearchForMfcCornerList(divisionMfcCorners);
                    return OperationResult<UpdateStockCountResearchDto>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).First();
                    var HeadOfMfc = await _headOfMfcRepository.GetHeadOfMfcByUserRoleId(userRole.Id);
                    var result = await UpdateStockCountResearchForSingleMfc(HeadOfMfc.MfcCornerId);
                    return OperationResult<UpdateStockCountResearchDto>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).First();
                    var userManagement = await _userManagementRepository.GetUserManagementUserRoleId(userRole.Id);
                    var result = await UpdateStockCountResearchForSingleMfc(userManagement.MfcCornerId);
                    return OperationResult<UpdateStockCountResearchDto>.Ok(result);
                }
                throw new ArgumentNullException(" CurrentUserRole ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<UpdateStockCountResearchDto> UpdateStockCountResearchForMfcCornerList(List<MfcCorner> divisionMfcCorners)
        {
            UpdateStockCountResearchDto stockCountResearchResult = GetGefaultUpdateStockCountResearchDto();

            foreach (var corner in divisionMfcCorners)
            {
                var cornerData = await UpdateStockCountResearchForSingleMfc(corner.Id);

                stockCountResearchResult.countResearchDeviceInfo.Analyzer += cornerData.countResearchDeviceInfo.Analyzer;
                stockCountResearchResult.countResearchDeviceInfo.Bpbio += cornerData.countResearchDeviceInfo.Bpbio;
                stockCountResearchResult.countResearchDeviceInfo.Bsm += cornerData.countResearchDeviceInfo.Bsm;
                stockCountResearchResult.countResearchDeviceInfo.Gaz += cornerData.countResearchDeviceInfo.Gaz;
                stockCountResearchResult.countResearchDeviceInfo.Pulse += cornerData.countResearchDeviceInfo.Pulse;
                stockCountResearchResult.countResearchFullUnfullInfo.Full += cornerData.countResearchFullUnfullInfo.Full;
                stockCountResearchResult.countResearchFullUnfullInfo.Unfull += cornerData.countResearchFullUnfullInfo.Unfull;
            }
            return stockCountResearchResult;
        }

        private async Task<UpdateStockCountResearchDto> UpdateStockCountResearchForSingleMfc(string mfcCornerId)
        {
            try
            {
                UpdateStockCountResearchDto stockCountResearchResult = GetGefaultUpdateStockCountResearchDto();
                var data = await _mfcCorenerStatisticPerDayRepository.GetTodayStatistic(mfcCornerId);
                if (data != null)
                {
                    stockCountResearchResult.countResearchDeviceInfo =
                        new StockCountResearchDeviceInfoDto
                        {
                            Analyzer = data.AnalyzerCount,
                            Bpbio = data.BPBIOCount,
                            Bsm = data.BsmCount,
                            Gaz = data.GazCount,
                            Pulse = data.PulseCount,
                            Group = DateTime.Today.Day.ToString()
                        };
                    stockCountResearchResult.countResearchFullUnfullInfo =
                        new StockCountResearchFullUnfullInfoDto
                        {
                            Full = data.FullExamCount,
                            Unfull = data.NotFullExamCount,
                            Group = DateTime.Today.Day.ToString()
                        };
                }

                return stockCountResearchResult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private UpdateStockCountResearchDto GetGefaultUpdateStockCountResearchDto()
        {
            UpdateStockCountResearchDto stockCountResearchResult = new UpdateStockCountResearchDto
            {
                countResearchDeviceInfo = new StockCountResearchDeviceInfoDto
                {
                    Analyzer = 0,
                    Bpbio = 0,
                    Bsm = 0,
                    Gaz = 0,
                    Pulse = 0,
                    Group = DateTime.Today.Day.ToString()
                },
                countResearchFullUnfullInfo = new StockCountResearchFullUnfullInfoDto
                {
                    Full = 0,
                    Unfull = 0,
                    Group = DateTime.Today.Day.ToString()
                }
            };
            return stockCountResearchResult;
        }

        private async Task<CommonCircleDiagramData> GetCircleDateForMfcCornerList(List<MfcCorner> divisionMfcCorners)
        {
            try
            {
                var commonResult = GetDefaultCommonCircleDiagramData();
                foreach (var corner in divisionMfcCorners)
                {
                    var cornerCircleData = await GetCircleDateForSingleMfc(corner.Id);

                    commonResult.CountResearch[0].Count += cornerCircleData.CountResearch[0].Count;
                    commonResult.CountResearch[1].Count += cornerCircleData.CountResearch[1].Count;
                    commonResult.CountResearch[2].Count += cornerCircleData.CountResearch[2].Count;
                    commonResult.CountResearch[3].Count += cornerCircleData.CountResearch[3].Count;
                    commonResult.CountResearch[4].Count += cornerCircleData.CountResearch[4].Count;

                    commonResult.CountResearchFull[0].Count += cornerCircleData.CountResearchFull[0].Count;
                    commonResult.CountResearchFull[1].Count += cornerCircleData.CountResearchFull[1].Count;
                }
                return commonResult;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<CommonCircleDiagramData> GetCircleDateForSingleMfc(string mfcCornerId)
        {
            try
            {
                var end = DateTime.Today.AddHours(23).AddMinutes(59);
                var start = DateTime.Today.AddDays(-30);

                var data = await _mfcCorenerStatisticPerDayRepository.GetStatisticForPeriod(start, end, mfcCornerId);
                var circleDiagramData = GetDefaultCommonCircleDiagramData();
                foreach (var elem in data)
                {
                    circleDiagramData.CountResearch[0].Count += elem.AnalyzerCount;
                    circleDiagramData.CountResearch[1].Count += elem.BsmCount;
                    circleDiagramData.CountResearch[2].Count += elem.GazCount;
                    circleDiagramData.CountResearch[3].Count += elem.PulseCount;
                    circleDiagramData.CountResearch[4].Count += elem.BPBIOCount;

                    circleDiagramData.CountResearchFull[0].Count += elem.FullExamCount;
                    circleDiagramData.CountResearchFull[1].Count += elem.NotFullExamCount;
                }

                return circleDiagramData;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private CommonCircleDiagramData CalculateProcents(CommonCircleDiagramData circleDiagramData)
        {
            double fullProcent = 0;
            double notFull = 0;
            if (circleDiagramData.CountResearchFull[0].Count + circleDiagramData.CountResearchFull[1].Count != 0)
            {
                double examSumm = circleDiagramData.CountResearchFull[0].Count + circleDiagramData.CountResearchFull[1].Count;
                fullProcent = Convert.ToDouble(circleDiagramData.CountResearchFull[0].Count) / (examSumm) * 100;
                fullProcent = Math.Round(fullProcent, 2);
                notFull = Math.Round(((double) (100 - fullProcent)), 2);

            }
            var analyzerProcent = Math.Round(GetApparatProcent(circleDiagramData.CountResearch[0].Count,
                circleDiagramData.CountResearch[0].Count,
                circleDiagramData.CountResearch[1].Count,
                circleDiagramData.CountResearch[2].Count,
                circleDiagramData.CountResearch[3].Count,
                circleDiagramData.CountResearch[4].Count
                ), 2);

            var bpbioProcent = Math.Round(GetApparatProcent(circleDiagramData.CountResearch[4].Count,
                circleDiagramData.CountResearch[0].Count,
                circleDiagramData.CountResearch[1].Count,
                circleDiagramData.CountResearch[2].Count,
                circleDiagramData.CountResearch[3].Count,
                circleDiagramData.CountResearch[4].Count
                ), 2);

            var bsmProcent = Math.Round(GetApparatProcent(circleDiagramData.CountResearch[1].Count,
                circleDiagramData.CountResearch[0].Count,
                circleDiagramData.CountResearch[1].Count,
                circleDiagramData.CountResearch[2].Count,
                circleDiagramData.CountResearch[3].Count,
                circleDiagramData.CountResearch[4].Count
                ), 2);
            var GazProcent = Math.Round(GetApparatProcent(circleDiagramData.CountResearch[2].Count,
                circleDiagramData.CountResearch[0].Count,
                circleDiagramData.CountResearch[1].Count,
                circleDiagramData.CountResearch[2].Count,
                circleDiagramData.CountResearch[3].Count,
                circleDiagramData.CountResearch[4].Count
                ), 2);
            var PulseProcent = Math.Round(GetApparatProcent(circleDiagramData.CountResearch[3].Count,
                circleDiagramData.CountResearch[0].Count,
                circleDiagramData.CountResearch[1].Count,
                circleDiagramData.CountResearch[2].Count,
                circleDiagramData.CountResearch[3].Count,
                circleDiagramData.CountResearch[4].Count
                ), 2);

            circleDiagramData.CountResearchFull[0].Procent = $"{fullProcent}%";
            circleDiagramData.CountResearchFull[1].Procent = $"{notFull}%";

            circleDiagramData.CountResearch[0].Procent = $"{analyzerProcent}%";
            circleDiagramData.CountResearch[1].Procent = $"{bsmProcent}%";
            circleDiagramData.CountResearch[2].Procent = $"{GazProcent}%";
            circleDiagramData.CountResearch[3].Procent = $"{PulseProcent}%";
            circleDiagramData.CountResearch[4].Procent = $"{bpbioProcent}%";

            return circleDiagramData;
        }

        private double GetApparatProcent(int apparat, int AnalyzerCount, int BsmCount, int GazCount, int PulseCount, int BPBIOCount)
        {
            double apparatSum = AnalyzerCount + BsmCount + GazCount + PulseCount + BPBIOCount;
            double result = 0;
            if (apparatSum > 0)
            {
                result = apparat / (apparatSum) * 100;
            }
            return result;
        }

        private CommonCircleDiagramData GetDefaultCommonCircleDiagramData()
        {
            CommonCircleDiagramData circleDiagramData = new CommonCircleDiagramData
            {
                CountResearch = new List<CircleDiagramDataDto>
                    {
                       new CircleDiagramDataDto
                       {
                           Count = 0,
                           Procent = "0%",
                           Tittle = "Analyzer"
                       },
                       new CircleDiagramDataDto
                       {
                           Count = 0,
                           Procent = "0%",
                           Tittle = "Bsm"
                       },
                       new CircleDiagramDataDto
                       {
                           Count = 0,
                           Procent = "0%",
                           Tittle = "Gaz"
                       },
                       new CircleDiagramDataDto
                       {
                           Count = 0,
                           Procent = "0%",
                           Tittle = "Pulse"
                       },
                       new CircleDiagramDataDto
                       {
                           Count = 0,
                           Procent = "0%",
                           Tittle = "Bpbio"
                       }
                    },
                CountResearchFull = new List<CircleDiagramDataDto>
                    {
                        new CircleDiagramDataDto
                       {
                           Count = 0,
                           Procent = "0%",
                           Tittle = "Full"
                       },
                        new CircleDiagramDataDto
                       {
                           Count = 0,
                           Procent = "0%",
                           Tittle = "UnFull"
                       },
                    }
            };
            return circleDiagramData;
        }

        private string GetUserIdFromJwt(string jwtString)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(jwtString);
                var tokenS = jsonToken as JwtSecurityToken;

                var id = tokenS.Claims.
                    Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid").
                    Select(claim => claim.Value).FirstOrDefault();
                return id;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<OperationResult<List<ZabbixTopTriggerDto>>> GetTopTriggers(string jwt)
        {
            try
            {
                var requestUserId = GetUserIdFromJwt(jwt);
                User requestUser = null;

                if (string.IsNullOrWhiteSpace(requestUserId))
                {
                    return OperationResult.Error<List<ZabbixTopTriggerDto>>("Invalid Claims", OperationCode.ValidationError);
                }
                else
                {
                    requestUser = await _userRepository.GetUserByIdAsync(requestUserId);
                    if (requestUser == null)
                    {
                        return OperationResult.Error<List<ZabbixTopTriggerDto>>("User with current token not exist", OperationCode.EntityWasNotFound);
                    }
                }

                var AdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "Admin" })).FirstOrDefault().Id;
                var SuperAdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "SuperAdmin" })).FirstOrDefault().Id;
                var headOfDivisionRoleId =
                   (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;
                var HeadOfMfcRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;
                var UserManagementRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "UserManagement" })).FirstOrDefault().Id;

                var userRoles = await _userRoleRepository.GetUserRolesByUserIdsAsync(
                    new List<string> { requestUserId });
                if (userRoles.Where(x => x.RoleId.Equals(AdminId)).Count() > 0 ||
                    userRoles.Where(x => x.RoleId.Equals(SuperAdminId)).Count() > 0)
                {
                    var allMfcCorners = await _mfcCornerRepository.GetAllMfcAsync();
                    var result = await _triggersRepository.GetTopTriggers();
                    return OperationResult<List<ZabbixTopTriggerDto>>.Ok(await MfcIdsToName(result));
                }
                else if (userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).First();
                    var headOfDivision = await _headOfDivisionRepository.GetHeadOfDivisionByUserRoleId(userRole.Id);
                    var divisionMfcCorners = await _mfcCornerRepository.GetDivisionMfcCornersAsync(headOfDivision.DistrictId);
                    var result = await _triggersRepository.GetTopTriggers();
                    return OperationResult<List<ZabbixTopTriggerDto>>.Ok(await MfcIdsToName(result));
                }
                else if (userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).First();
                    var HeadOfMfc = await _headOfMfcRepository.GetHeadOfMfcByUserRoleId(userRole.Id);
                    var result = await _triggersRepository.GetTopTriggers();
                    //await GetResearchDynamicsDtoForSingleMfc(HeadOfMfc.MfcCornerId);
                    return OperationResult<List<ZabbixTopTriggerDto>>.Ok(await MfcIdsToName(result));
                }
                else if (userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).First();
                    var userManagement = await _userManagementRepository.GetUserManagementUserRoleId(userRole.Id);
                    var result = await _triggersRepository.GetTopTriggers();
                    //await GetResearchDynamicsDtoForSingleMfc(userManagement.MfcCornerId);
                    return OperationResult<List<ZabbixTopTriggerDto>>.Ok(await MfcIdsToName(result));
                }
                throw new ArgumentNullException(" CurrentUserRole ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OperationResult<List<JournalEventsTime>>> GetJournalEventsTimeByDate(string jwt, DateTime? eventLogDate = null)
        {
            try
            {
                var requestUserId = GetUserIdFromJwt(jwt);
                User requestUser = null;

                DateTime start = eventLogDate != null ? (DateTime)eventLogDate : DateTime.Today;
                DateTime end = start.AddHours(23).AddMinutes(59);

                if (string.IsNullOrWhiteSpace(requestUserId))
                {
                    return OperationResult.Error<List<JournalEventsTime>>("Invalid Claims", OperationCode.ValidationError);
                }
                else
                {
                    requestUser = await _userRepository.GetUserByIdAsync(requestUserId);
                    if (requestUser == null)
                    {
                        return OperationResult.Error<List<JournalEventsTime>>("User with current token not exist", OperationCode.EntityWasNotFound);
                    }
                }

                var AdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "Admin" })).FirstOrDefault().Id;
                var SuperAdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "SuperAdmin" })).FirstOrDefault().Id;
                var headOfDivisionRoleId =
                   (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;
                var HeadOfMfcRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;
                var UserManagementRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "UserManagement" })).FirstOrDefault().Id;

                var userRoles = await _userRoleRepository.GetUserRolesByUserIdsAsync(
                    new List<string> { requestUserId });
                if (userRoles.Where(x => x.RoleId.Equals(AdminId)).Count() > 0 ||
                    userRoles.Where(x => x.RoleId.Equals(SuperAdminId)).Count() > 0)
                {
                    var allMfcCorners = await _mfcCornerRepository.GetAllMfcAsync();
                    var allMfcCornerIds = allMfcCorners.Select(x => x.Id).ToList();
                    var resultJournalEventsTime = await _triggersRepository.GetEventLogByDay(start, end, allMfcCornerIds);
                    return OperationResult<List<JournalEventsTime>>.Ok((await MfcIdsToName(resultJournalEventsTime)));
                }
                else if (userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).First();
                    var headOfDivision = await _headOfDivisionRepository.GetHeadOfDivisionByUserRoleId(userRole.Id);
                    var divisionMfcCorners = await _mfcCornerRepository.GetDivisionMfcCornersAsync(headOfDivision.DistrictId);
                    var divisionMfcIds = divisionMfcCorners.Select(x => x.Id).ToList();
                    var resultJournalEventsTime = await _triggersRepository.GetEventLogByDay(start, end, divisionMfcIds);
                    return OperationResult<List<JournalEventsTime>>.Ok((await MfcIdsToName(resultJournalEventsTime)));
                }
                else if (userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).First();
                    var HeadOfMfc = await _headOfMfcRepository.GetHeadOfMfcByUserRoleId(userRole.Id);
                    var mfcId = new List<string> { HeadOfMfc.MfcCornerId };
                    var resultJournalEventsTime = await _triggersRepository.GetEventLogByDay(start, end, mfcId);
                    return OperationResult<List<JournalEventsTime>>.Ok((await MfcIdsToName(resultJournalEventsTime)));

                }
                else if (userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).First();
                    var userManagement = await _userManagementRepository.GetUserManagementUserRoleId(userRole.Id);
                    var mfcId = new List<string> { userManagement.MfcCornerId };
                    var resultJournalEventsTime = await _triggersRepository.GetEventLogByDay(start, end, mfcId);
                    return OperationResult<List<JournalEventsTime>>.Ok((await MfcIdsToName(resultJournalEventsTime)));
                }
                throw new ArgumentNullException(" CurrentUserRole ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OperationResult<EventLog>> GetEventLog(string jwt, DateTime? eventLogDate = null)
        {
            try
            {
                var requestUserId = GetUserIdFromJwt(jwt);
                User requestUser = null;

                DateTime start = eventLogDate != null ? (DateTime)eventLogDate : DateTime.Today;
                DateTime end = start.AddHours(23).AddMinutes(59);

                if (string.IsNullOrWhiteSpace(requestUserId))
                {
                    return OperationResult.Error<EventLog>("Invalid Claims", OperationCode.ValidationError);
                }
                else
                {
                    requestUser = await _userRepository.GetUserByIdAsync(requestUserId);
                    if (requestUser == null)
                    {
                        return OperationResult.Error<EventLog>("User with current token not exist", OperationCode.EntityWasNotFound);
                    }
                }

                var AdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "Admin" })).FirstOrDefault().Id;
                var SuperAdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "SuperAdmin" })).FirstOrDefault().Id;
                var headOfDivisionRoleId =
                   (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;
                var HeadOfMfcRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;
                var UserManagementRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "UserManagement" })).FirstOrDefault().Id;

                var userRoles = await _userRoleRepository.GetUserRolesByUserIdsAsync(
                    new List<string> { requestUserId });
                if (userRoles.Where(x => x.RoleId.Equals(AdminId)).Count() > 0 ||
                    userRoles.Where(x => x.RoleId.Equals(SuperAdminId)).Count() > 0)
                {
                    var allMfcCorners = await _mfcCornerRepository.GetAllMfcAsync();
                    var allMfcCornerIds = allMfcCorners.Select(x => x.Id).ToList();
                    var resultJournalEventsTime = await _triggersRepository.GetEventLogByDay(start, end, allMfcCornerIds);
                    var resultJournalEvents = await GetJournalEvents(allMfcCornerIds);
                    var eventLog = new EventLog
                    {
                        total = GetTotalInfo(resultJournalEvents),
                        JournalEventsTime = (await MfcIdsToName(resultJournalEventsTime)),
                        journalEvents = resultJournalEvents
                    };

                    return OperationResult<EventLog>.Ok(eventLog);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).First();
                    var headOfDivision = await _headOfDivisionRepository.GetHeadOfDivisionByUserRoleId(userRole.Id);
                    var divisionMfcCorners = await _mfcCornerRepository.GetDivisionMfcCornersAsync(headOfDivision.DistrictId);
                    var divisionMfcIds = divisionMfcCorners.Select(x => x.Id).ToList();
                    var resultJournalEventsTime = await _triggersRepository.GetEventLogByDay(start, end, divisionMfcIds);
                    var resultJournalEvents = await GetJournalEvents(divisionMfcCorners.Select(x => x.Id).ToList());
                    var eventLog = new EventLog
                    {
                        total = GetTotalInfo(resultJournalEvents),
                        JournalEventsTime = (await MfcIdsToName(resultJournalEventsTime)),
                        journalEvents = resultJournalEvents
                    };

                    return OperationResult<EventLog>.Ok(eventLog);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).First();
                    var HeadOfMfc = await _headOfMfcRepository.GetHeadOfMfcByUserRoleId(userRole.Id);
                    var mfcId = new List<string> { HeadOfMfc.MfcCornerId };
                    var resultJournalEventsTime = await _triggersRepository.GetEventLogByDay(start, end, mfcId);
                    var resultJournalEvents = await GetJournalEvents(new List<string> { HeadOfMfc.MfcCornerId });
                    var eventLog = new EventLog
                    {
                        total = GetTotalInfo(resultJournalEvents),
                        JournalEventsTime = (await MfcIdsToName(resultJournalEventsTime)),
                        journalEvents = resultJournalEvents
                    };

                    return OperationResult<EventLog>.Ok(eventLog);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).First();
                    var userManagement = await _userManagementRepository.GetUserManagementUserRoleId(userRole.Id);
                    var mfcId = new List<string> { userManagement.MfcCornerId };

                    var resultJournalEventsTime = await _triggersRepository.GetEventLogByDay(start, end, mfcId);
                    var resultJournalEvents = await GetJournalEvents(new List<string> { userManagement.MfcCornerId });
                    var eventLog = new EventLog
                    {
                        total = GetTotalInfo(resultJournalEvents),
                        JournalEventsTime = (await MfcIdsToName(resultJournalEventsTime)),
                        journalEvents = resultJournalEvents
                    };

                    return OperationResult<EventLog>.Ok(eventLog);
                }
                throw new ArgumentNullException(" CurrentUserRole ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private TotalInfo GetTotalInfo(List<JournalEvents> journalEvents)
        {
            var total = new TotalInfo
            {
                errors = 0,
                info = 0,
                warnings = 0
            };

            foreach (var jEvent in journalEvents)
            {
                total.warnings += jEvent.total.warnings;
                total.info += jEvent.total.info;
                total.errors += jEvent.total.errors;
            }
            return total;
        }

        public async Task<List<JournalEvents>> GetJournalEvents(List<string> mfcCornerIds)
        {
            try
            {
                var result = await GetJournalEventsForSingleMfc(mfcCornerIds.First());
                if (mfcCornerIds.Count == 1)
                {
                    return result;
                }
                else
                {
                    for (int i = 1; i < mfcCornerIds.Count(); i++)
                    {
                        var tmp = await GetJournalEventsForSingleMfc(mfcCornerIds[i]);

                        for (int j = 0; j < result.Count; j++)
                        {
                            result[j].total.errors += tmp[j].total.errors;
                            result[j].total.warnings += tmp[j].total.warnings;
                            result[j].total.info += tmp[j].total.info;
                        }
                    }
                    result.Reverse();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OperationResult<SystemStatusDto>> GetSystemStatusInMinutes(string jwt)
        {
            try
            {
                DateTime start = DateTime.Now.AddHours(3).AddHours(-1);
                DateTime end = DateTime.Now.AddHours(3);

                var requestUserId = GetUserIdFromJwt(jwt);
                User requestUser = null;

                if (string.IsNullOrWhiteSpace(requestUserId))
                {
                    return OperationResult.Error<SystemStatusDto>("Invalid Claims", OperationCode.ValidationError);
                }
                else
                {
                    requestUser = await _userRepository.GetUserByIdAsync(requestUserId);
                    if (requestUser == null)
                    {
                        return OperationResult.Error<SystemStatusDto>("User with current token not exist", OperationCode.EntityWasNotFound);
                    }
                }

                var AdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "Admin" })).FirstOrDefault().Id;
                var SuperAdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "SuperAdmin" })).FirstOrDefault().Id;
                var headOfDivisionRoleId =
                   (await _roleRepository.GetRolesByRoleNamesAsync(
                       new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;
                var HeadOfMfcRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;
                var UserManagementRoleId =
                    (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "UserManagement" })).FirstOrDefault().Id;

                var userRoles = await _userRoleRepository.GetUserRolesByUserIdsAsync(
                    new List<string> { requestUserId });
                if (userRoles.Where(x => x.RoleId.Equals(AdminId)).Count() > 0 ||
                    userRoles.Where(x => x.RoleId.Equals(SuperAdminId)).Count() > 0)
                {
                    var allMfcCorners = await _mfcCornerRepository.GetAllMfcAsync();

                    var result = await GetSystemStatusForGroupOfMfc(allMfcCorners.Select(x => x.Id).ToList(), start, end);
                    result.mfcCondition = result.MfcDatas.Select(x => x.Name).ToList();
                    return OperationResult<SystemStatusDto>.Ok(result/*AddFutureMinutes(result,end,new TimeSpan(0,0,30),2)*/);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).First();
                    var headOfDivision = await _headOfDivisionRepository.GetHeadOfDivisionByUserRoleId(userRole.Id);
                    var divisionMfcCorners = await _mfcCornerRepository.GetDivisionMfcCornersAsync(headOfDivision.DistrictId);

                    var result = await GetSystemStatusForGroupOfMfc(divisionMfcCorners.Select(x => x.Id).ToList(), start, end);
                    result.mfcCondition = result.MfcDatas.Select(x => x.Name).ToList();
                    return OperationResult<SystemStatusDto>.Ok(result/*AddFutureMinutes(result,end,new TimeSpan(0,0,30),2)*/);

                }
                else if (userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).First();
                    var HeadOfMfc = await _headOfMfcRepository.GetHeadOfMfcByUserRoleId(userRole.Id);

                    var statisticByTime = await _triggersRepository.GetMfcCornerDeviceInfoDto(start, end, HeadOfMfc.MfcCornerId);
                    var result = await GetSystemStatusForSingleMfc(statisticByTime);
                    result.mfcCondition = result.MfcDatas.Select(x => x.Name).ToList();
                    return OperationResult<SystemStatusDto>.Ok(result/*AddFutureMinutes(result,end,new TimeSpan(0,0,30),2)*/);

                }
                else if (userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).First();
                    var userManagement = await _userManagementRepository.GetUserManagementUserRoleId(userRole.Id);

                    var statisticByTime = await _triggersRepository.GetMfcCornerDeviceInfoDto(start, end, userManagement.MfcCornerId);

                    var result = await GetSystemStatusForSingleMfc(statisticByTime);
                    result.mfcCondition = result.MfcDatas.Select(x => x.Name).ToList();
                    return OperationResult<SystemStatusDto>.Ok(result/*AddFutureMinutes(result,end,new TimeSpan(0,0,30),2)*/);
                }
                throw new ArgumentNullException(" CurrentUserRole ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private SystemStatusDto AddFutureMinutes(SystemStatusDto systemStatus, DateTime nowTime, TimeSpan chartInterval, int countOfMinutes)
        {
            var endTime = nowTime.AddMinutes(countOfMinutes);
            while (nowTime < endTime)
            {
                var time = (nowTime.AddHours(-3) + chartInterval).ToString("HH:mm:ss");  //ToShortTimeString();

                var stack = new StackChart
                {
                    group = time,
                    unwork = 0,
                    work = 0
                };

                var bar = new BarChart
                {
                    group = time,
                    value = 0
                };

                systemStatus.BarCharts.Add(bar);
                systemStatus.StackCharts.Add(stack);
                nowTime += chartInterval;
            }

            //for (int i = 1; i<= 2;i++)
            //{
            //    var time = nowTime.AddHours(-3).AddMinutes().ToString("HH:mm:ss");  //ToShortTimeString();

            //    var stack = new StackChart { 
            //        group = time,
            //        unwork = 0,
            //        work = 0
            //    };

            //    var bar = new BarChart
            //    {
            //        group = time,
            //        value = 0
            //    };

            //    systemStatus.BarCharts.Add(bar);
            //    systemStatus.StackCharts.Add(stack);

            //}

            return systemStatus;
        }

        private async Task<SystemStatusDto> GetSystemStatusForGroupOfMfc(List<string> mfcCorners, DateTime start, DateTime end)
        {
            try
            {
                List<SystemStatusDto> systemStatuses = new List<SystemStatusDto>();
                foreach (var mcCornerId in mfcCorners)
                {
                    var statisticByTime = await _triggersRepository.GetMfcCornerDeviceInfoDto(start, end, mcCornerId);
                    var systemStatus = await GetSystemStatusForSingleMfc(statisticByTime);
                    systemStatuses.Add(systemStatus);
                }

                if (mfcCorners.Count == 1)
                {
                    return systemStatuses.First();
                }
                else
                {
                    var commonResult = systemStatuses.First();
                    for (int i = 1; i < systemStatuses.Count(); i++)
                    {
                        commonResult.MfcDatas.Add(systemStatuses[i].MfcDatas.First());
                        for (int j = 0; j < systemStatuses.First().StackCharts.Count(); j++)
                        {
                            commonResult.BarCharts[j].value += systemStatuses[i].BarCharts[j].value;
                            commonResult.StackCharts[j].work += systemStatuses[i].StackCharts[j].work;
                            commonResult.StackCharts[j].unwork += systemStatuses[i].StackCharts[j].unwork;
                        }
                    }

                    for (int j = 0; j < systemStatuses.First().StackCharts.Count(); j++)
                    {
                        commonResult.StackCharts[j].work /= systemStatuses.Count();
                        commonResult.StackCharts[j].unwork /= systemStatuses.Count();
                    }

                    return commonResult;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<SystemStatusDto> GetSystemStatusForSingleMfc(MfcCornerDeviceInfoDto statistic)
        {
            try
            {
                var mfc = await _mfcCornerRepository.GetMfcAsync(statistic.Host);
                int localTimeIndex = 3;
                var result = new SystemStatusDto
                {
                    BarCharts = new List<BarChart>(),
                    StackCharts = new List<StackChart>(),
                    MfcDatas = new List<MfcData>
                    {
                        new MfcData
                        {
                            Name = mfc.Name,
                            Statuses = new List<StatusWithTime>()
                        }
                    }
                };
                var start = DateTime.Now.AddHours(-1);
                var end = DateTime.Now;
                var span = new TimeSpan(0, 0, 30);

                var runner = start;
                var runnerEnd = start + span;

                while (runnerEnd <= end)
                {
                    var currentGroupString = runnerEnd.ToString("HH:mm:ss");    //ToShortTimeString(); ;
                    var StatByInterval = statistic.Data.
                        Where(x => x.DateTime >= runner
                        && x.DateTime <= runnerEnd).ToList();

                    // var value = StatByInterval.Select(x => x.DeviceStatusInfo.SYSTEM_STATUS).Distinct()
                    //     .Where(x => x.ToLower().Contains("start")).Count();

                    if (StatByInterval.Count == 0)
                    {
                        var bar = new BarChart
                        {
                            group = currentGroupString,
                            value = 0
                        };

                        var stack = new StackChart
                        {
                            group = currentGroupString,
                            work = 0,
                            unwork = 100
                        };

                        var status = new StatusWithTime
                        {
                            group = currentGroupString,
                            analyzer = -1,
                            bpbio = -1,
                            bsm = -1,
                            gaz = -1,
                            pulse = -1
                        };
                        result.BarCharts.Add(bar);
                        result.StackCharts.Add(stack);
                        result.MfcDatas.First().Statuses.Add(status);
                    }
                    else
                    {
                        var bar = new BarChart
                        {
                            group = currentGroupString,
                            value = getCommonTestCount(StatByInterval)
                        };

                        var workProcent = GetWorkProcent(StatByInterval);
                        var stack = new StackChart
                        {
                            group = currentGroupString,
                            work = workProcent,
                            unwork = 100 - workProcent
                        };

                        var status = GetStatusWithTime(StatByInterval, currentGroupString);
                        result.BarCharts.Add(bar);
                        result.StackCharts.Add(stack);
                        result.MfcDatas.First().Statuses.Add(status);
                    }

                    runner += span;
                    runnerEnd += span;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private int getCommonTestCount(List<DeviceInfoWithTimeDto> StatByInterval)
        {
            var analyzerCount = StatByInterval.
                Where(x => x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("analyzer start"))
                .Count() > 0 ? 1 : 0;
            if (analyzerCount == 0)
            {
                analyzerCount = StatByInterval.
                    Where(x => x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("analyzer progress"))
                    .Count() > 0 ? 1 : 0; ;
            }

            var bsmCount = StatByInterval.
                Where(x => x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("bsm start"))
                .Count() > 0 ? 1 : 0; ;
            if (bsmCount == 0)
            {
                bsmCount = StatByInterval.
                    Where(x => x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("bsm progress"))
                    .Count() > 0 ? 1 : 0; ;
            }

            var pulseCount = StatByInterval.
        Where(x => x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("pulse start"))
        .Count() > 0 ? 1 : 0; ;
            if (pulseCount == 0)
            {
                pulseCount = StatByInterval.
                    Where(x => x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("pulse progress"))
                    .Count() > 0 ? 1 : 0; ;
            }

            var gazCount = StatByInterval.
                Where(x => x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("gaz start"))
                .Count() > 0 ? 1 : 0; ;
            if (gazCount == 0)
            {
                gazCount = StatByInterval.
                    Where(x => x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("gaz progress"))
                    .Count() > 0 ? 1 : 0; ;
            }

            var bpbioCount = StatByInterval.
                Where(x => x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("bpbio start"))
                .Count() > 0 ? 1 : 0; ;
            if (bpbioCount == 0)
            {
                bpbioCount = StatByInterval.
                    Where(x => x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("bpbio progress"))
                    .Count() > 0 ? 1 : 0; ;
            }

            int commonCount = analyzerCount + bpbioCount + bsmCount + gazCount + pulseCount;
            return commonCount;
        }

        private StatusWithTime GetStatusWithTime(List<DeviceInfoWithTimeDto> dtos, string currentGroupString)
        {
            StatusWithTime statusWithTime = new StatusWithTime
            {
                group = currentGroupString,
                analyzer = dtos.Where(x => x.DeviceStatusInfo.ANALYZER).Count() > (dtos.Count() / 2) ? 0 : -1,
                bpbio = dtos.Where(x => x.DeviceStatusInfo.BPBIO).Count() > (dtos.Count() / 2) ? 0 : -1,
                gaz = dtos.Where(x => x.DeviceStatusInfo.GAZ).Count() > (dtos.Count() / 2) ? 0 : -1,
                pulse = dtos.Where(x => x.DeviceStatusInfo.PULSE).Count() > (dtos.Count() / 2) ? 0 : -1,
                bsm = dtos.Where(x => x.DeviceStatusInfo.BSM).Count() > (dtos.Count() / 2) ? 0 : -1
            };
            statusWithTime.analyzer = dtos.
                Where(x => x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("analyzer start") ||
                        x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("analyzer progress")).Count() > 0 ?
                1 : statusWithTime.analyzer;

            statusWithTime.bpbio = dtos.
                Where(x => x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("bpbio start") ||
                        x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("bpbio progress")).Count() > 0 ?
                1 : statusWithTime.bpbio;

            statusWithTime.bsm = dtos.
                Where(x => x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("bsm start") ||
                        x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("bsm progress")).Count() > 0 ?
                1 : statusWithTime.bsm;

            statusWithTime.gaz = dtos.
                Where(x => x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("gaz start") ||
                        x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("gaz progress")).Count() > 0 ?
                1 : statusWithTime.gaz;

            statusWithTime.pulse = dtos.
                Where(x => x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("pulse start") ||
                        x.DeviceStatusInfo.SYSTEM_STATUS.ToLower().Contains("pulse progress")).Count() > 0 ?
                1 : statusWithTime.pulse;
            return statusWithTime;
        }

        private int GetWorkProcent(List<DeviceInfoWithTimeDto> dtos)
        {
            double analyzerWorkCount = dtos.Where(x => x.DeviceStatusInfo.ANALYZER).Count();
            double bsmWorkCount = dtos.Where(x => x.DeviceStatusInfo.BSM).Count();
            double gazWorkCount = dtos.Where(x => x.DeviceStatusInfo.GAZ).Count();
            double pulseWorkCount = dtos.Where(x => x.DeviceStatusInfo.PULSE).Count();
            double bpbioWorkCount = dtos.Where(x => x.DeviceStatusInfo.BPBIO).Count();

            double commonDeviceCount = analyzerWorkCount + bsmWorkCount + gazWorkCount + pulseWorkCount + bpbioWorkCount;
            double commonCount = dtos.Count() * 5;

            double qq = commonDeviceCount / commonCount;
            qq *= 100;
            int result = Convert.ToInt32(Math.Round(qq));

            return result;
        }

        public async Task<List<JournalEvents>> GetJournalEventsForSingleMfc(string mfcCornerId)
        {
            try
            {
                var start = DateTime.Today.AddMonths(-1);
                var end = DateTime.Today.AddHours(23).AddMinutes(59);
                var eventLogs = await _triggersRepository.GetEventLogByPeriodFromHost(start, end, mfcCornerId);
                List<JournalEvents> journalEvents = new List<JournalEvents>();
                var stepDate = start;
                while (stepDate < end)
                {
                    var newJournalEvent = new JournalEvents
                    {
                        date = stepDate.ToShortDateString(),
                        total = new TotalInfo
                        {
                            errors = 0,
                            warnings = 0,
                            info = 0,
                        }
                    };
                    var stepDateEventLog = eventLogs.Where(e => e.Clock >= stepDate && e.Clock <= stepDate.AddHours(23).AddMinutes(59)).ToList();
                    foreach (var log in stepDateEventLog)
                    {
                        switch (log.Priority)
                        {
                            case 0:
                                newJournalEvent.total.info++;
                                break;
                            case 1:
                                newJournalEvent.total.info++;
                                break;
                            case 2:
                                newJournalEvent.total.info++;
                                break;
                            case 3:
                                newJournalEvent.total.info++;
                                break;
                            case 4:
                                newJournalEvent.total.warnings++;
                                break;
                            case 5:
                                newJournalEvent.total.errors++;
                                break;
                            default:
                                break;
                        }
                    }

                    journalEvents.Add(newJournalEvent);
                    stepDate = stepDate.AddDays(1);
                }
                return journalEvents;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        private async Task<List<JournalEventsTime>> MfcIdsToName(List<JournalEventsTime> journalEvents)
        {
            for (int i = 0; i < journalEvents.Count(); i++)
            {
                var mfcString = journalEvents[i].Mfc.Replace("mfc_corner_", "");
                var mfc = await _mfcCornerRepository.GetMfcAsync(mfcString);
                journalEvents[i].Mfc = mfc.Name;

            }
            return journalEvents;
        }

        private async Task<List<ZabbixTopTriggerDto>> MfcIdsToName(List<ZabbixTopTriggerDto> topTriggers)
        {
            for (int i = 0; i < topTriggers.Count(); i++)
            {
                for (int j = 0; j < topTriggers[i].Mfcs.Count(); j++)
                {
                    var mfcString = topTriggers[i].Mfcs[j].Replace("mfc_corner_", "");
                    var mfc = await _mfcCornerRepository.GetMfcAsync(mfcString);
                    topTriggers[i].Mfcs[j] = mfc.Name;
                }
            }
            return topTriggers;
        }

    }
}
