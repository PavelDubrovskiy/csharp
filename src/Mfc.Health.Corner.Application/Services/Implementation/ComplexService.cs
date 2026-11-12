using ClosedXML.Excel;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Application.Validators;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using System.Data;
using Mfc.Health.Corner.Application.Common.Excel;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Mfc.Health.Corner.Domain.Models;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    class ComplexService : IComplexService
    {
        private readonly IMfcCornerRepository _mfcCornerRepository;
        private readonly IMedicalExaminationRepository _medicalExaminationRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IMfcCorenerStatisticPerDayRepository _mfcCorenerStatisticPerDayRepository;
        private readonly IDashBordService _dashBordService;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserManagementRepository _userManagementRepository;
        private readonly IHeadOfMfcRepository _headOfMfcRepository;
        private readonly IHeadOfDivisionRepository _headOfDivisionRepository;

        public ComplexService(
            IMfcCornerRepository mfcCornerRepository,
            IMedicalExaminationRepository medicalExaminationRepository,
            IMfcCorenerStatisticPerDayRepository mfcCorenerStatisticPerDayRepository,
            IDashBordService dashBordService,
            IUserRoleRepository userRoleRepository,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUserManagementRepository userManagementRepository,
            IHeadOfMfcRepository headOfMfcRepository,
            IHeadOfDivisionRepository headOfDivisionRepository,

        IDistrictRepository districtRepository)
        {
            _mfcCornerRepository = mfcCornerRepository;
            _medicalExaminationRepository = medicalExaminationRepository;
            _districtRepository = districtRepository;
            _mfcCorenerStatisticPerDayRepository = mfcCorenerStatisticPerDayRepository;
            _dashBordService = dashBordService;
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userManagementRepository = userManagementRepository;
            _headOfMfcRepository = headOfMfcRepository;
            _headOfDivisionRepository = headOfDivisionRepository;
        }

        public async Task<MemoryStream> ExportComplexListToXlsAsync(string jwt, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var mfcList = await _mfcCornerRepository.GetAllMfcAsync();

                DateTimeOffset? startOffset = startDate == null ? null :
                    new DateTimeOffset((DateTime)startDate, DateTimeOffset.Now.Offset);
                DateTimeOffset? endOffset = endDate == null ? null :
                    new DateTimeOffset((DateTime)endDate, DateTimeOffset.Now.Offset);

                DataTable excelUsers = new DataTable("MFCs");

                excelUsers.Columns.AddRange(new DataColumn[7] {
                        new DataColumn("Название"),
                        new DataColumn("Всего"),
                        new DataColumn("Ростомер"),
                        new DataColumn("Анализатор"),
                        new DataColumn("Пульсоксиметр"),
                        new DataColumn("Тонометр"),
                        new DataColumn("Смокилайзер") });

                var total = new MfcCormerExaminationDataCountsDto
                {
                    MfcCormerName = "Итого",
                    Analyzer = 0,
                    Gaz = 0,
                    Bpbio = 0,
                    Bsm = 0,
                    Pulse = 0,
                    TotalExaminationCount = 0
                };

                var allData = await GetReportData(jwt, startDate, endDate);

                foreach (var data in allData.Object)
                {
                    total.TotalExaminationCount += data.Total;
                    total.Bsm += data.Devices.Bsm;
                    total.Analyzer += data.Devices.Analyzer;
                    total.Bpbio += data.Devices.Bpbio;
                    total.Pulse += data.Devices.Pulse;
                    total.Gaz += data.Devices.Gaz;

                    excelUsers.Rows.Add(
                        data.Title,
                        data.Total,
                        data.Devices.Bsm,
                        data.Devices.Analyzer,
                        data.Devices.Pulse,
                        data.Devices.Bpbio,
                        data.Devices.Gaz);
                }

                excelUsers.Rows.Add();
                excelUsers.Rows.Add(total.MfcCormerName,
                    total.TotalExaminationCount,
                    total.Bsm,
                    total.Analyzer,
                    total.Bpbio,
                    total.Pulse,
                    total.Gaz);
                excelUsers.Rows.Add();

                var totalDays = startOffset != null&& endOffset!=null?
                    ((TimeSpan)(endOffset - startOffset)).Days :
                    allData.Object[0].DaysCount;
                totalDays = totalDays == 0 ? 1 : totalDays;

                var arithmeticMean = total.TotalExaminationCount / totalDays;

                excelUsers.Rows.Add($"Среднее значение по всем ФМЦ за {totalDays} д. ", arithmeticMean);

                var weekExaminations = await GetReportData(jwt, DateTime.Today.AddDays(-7), DateTime.Now);
                long weekExaminationCount = 0;
                foreach(var weekExamination in weekExaminations.Object)
                {
                    weekExaminationCount += weekExamination.Total;
                }

                var weekString = $"Всего тестирований за неделю с {DateTime.Now.AddDays(-7).ToShortDateString()} по {DateTime.Now.ToShortDateString()}";

                excelUsers.Rows.Add(weekString, weekExaminationCount);

                using (XLWorkbook workBook = new XLWorkbook())
                {
                    workBook.Worksheets.Add(excelUsers);
                    foreach (var Worksheet in workBook.Worksheets)
                    {
                        foreach (var Table in Worksheet.Tables)
                        {
                            Table.ShowAutoFilter = false;
                        }
                    }
                    return workBook.ToMemoryStream();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<OperationResult<List<CornerReportDataDto>>> GetReportData(string jwt, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var requestUserId = GetUserIdFromJwt(jwt);
                User requestUser = null;

                if (string.IsNullOrWhiteSpace(requestUserId))
                {
                    return OperationResult.Error<List<CornerReportDataDto>>("Invalid Claims", OperationCode.ValidationError);
                }
                else
                {
                    requestUser = await _userRepository.GetUserByIdAsync(requestUserId);
                    if (requestUser == null)
                    {
                        return OperationResult.Error<List<CornerReportDataDto>>("User with current token not exist", OperationCode.EntityWasNotFound);
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
                    var result = await GetCornerReportDataDtoForListMfc(allMfcCorners, startDate, endDate);
                    return OperationResult<List<CornerReportDataDto>>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).First();
                    var headOfDivision = await _headOfDivisionRepository.GetHeadOfDivisionByUserRoleId(userRole.Id);
                    var divisionMfcCorners = await _mfcCornerRepository.GetDivisionMfcCornersAsync(headOfDivision.DistrictId);
                    var result = await GetCornerReportDataDtoForListMfc(divisionMfcCorners, startDate, endDate);
                    return OperationResult<List<CornerReportDataDto>>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).First();
                    var HeadOfMfc = await _headOfMfcRepository.GetHeadOfMfcByUserRoleId(userRole.Id);
                    var result = new List<CornerReportDataDto>();
                    var singleMfcData = await GetCornerReportDataDtoForSingleMfc(HeadOfMfc.MfcCornerId, startDate, endDate);
                    result.Add(singleMfcData);
                    return OperationResult<List<CornerReportDataDto>>.Ok(result);
                }
                else if (userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).Count() > 0)
                {
                    var userRole = userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).First();
                    var userManagement = await _userManagementRepository.GetUserManagementUserRoleId(userRole.Id);
                    var result = new List<CornerReportDataDto>();
                    var singleMfcData = await GetCornerReportDataDtoForSingleMfc(userManagement.MfcCornerId, startDate, endDate);
                    result.Add(singleMfcData);
                    return OperationResult<List<CornerReportDataDto>>.Ok(result);
                }
                throw new ArgumentNullException(" CurrentUserRole ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<List<CornerReportDataDto>> GetCornerReportDataDtoForListMfc(List<MfcCorner> mfcCorners, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var cornerReportDataList = new List<CornerReportDataDto>();
                int maxDayCount = 0;
                foreach (var mfc in mfcCorners)
                {
                    var cornerData = await GetCornerReportDataDtoForSingleMfc(mfc.Id, startDate, endDate);
                    cornerReportDataList.Add(cornerData);
                    maxDayCount = maxDayCount < cornerData.DaysCount ? cornerData.DaysCount : maxDayCount;
                }
                    foreach (var cornerReportData in cornerReportDataList)
                    {
                        cornerReportData.DaysCount = maxDayCount;
                    }
                     
                return cornerReportDataList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<CornerReportDataDto> GetCornerReportDataDtoForSingleMfc(string mfcCornerId, DateTime? startDate, DateTime? endDate)
        {
            try
            {
                var data = await _mfcCorenerStatisticPerDayRepository.GetStatisticForPeriod(startDate, endDate, mfcCornerId);
                var mfc = await _mfcCornerRepository.GetMfcAsync(mfcCornerId);
                var reportData = new CornerReportDataDto
                {
                    Title = mfc.Name,
                    DaysCount = data.Count,
                    Devices = new DeviceInfoDto
                    {
                        Analyzer = 0,
                        Bpbio = 0,
                        Bsm = 0,
                        Gaz = 0,
                        Pulse = 0
                    },
                    Total = 0

                };
                foreach (var el in data)
                {
                    reportData.Devices.Analyzer += el.AnalyzerCount;
                    reportData.Devices.Bpbio += el.BPBIOCount;
                    reportData.Devices.Bsm += el.BsmCount;
                    reportData.Devices.Gaz += el.GazCount;
                    reportData.Devices.Pulse += el.PulseCount;
                    reportData.Total += el.NotFullExamCount + el.FullExamCount;
                }
                return reportData;
            }
            catch (Exception ex)
            {
                throw;
            }
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


        public async Task<OperationResult<PagedCollection<ComplexDto>>> GetComplexList(int pageNumber, int pageSize,
            DateTime? startDate = null, DateTime? endDate = null)
        {
            var datesValidator = new DatesIntervalValidator();
            if (startDate != null && endDate != null)
            {
                var validationResult = datesValidator.Validate(new DatesIntervalDto
                {
                    StartDate = (DateTime)startDate,
                    EndDate = (DateTime)endDate
                });

                if (!validationResult.IsValid)
                {
                    return OperationResult.Error<PagedCollection<ComplexDto>>(validationResult.ToString(), OperationCode.ValidationError);
                }
            }
            var paggingValidator = new PaggingValidator();
            var paggingValidationResult = paggingValidator.Validate(new PaggingDto
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            });
            if (!paggingValidationResult.IsValid)
            {
                return OperationResult.Error<PagedCollection<ComplexDto>>(paggingValidationResult.ToString(), OperationCode.ValidationError);
            }

            var mfcCorners = await _mfcCornerRepository.GetAllMfcAsync(pageNumber, pageSize, null);
            var mfcComplexDtos = mfcCorners.Items.Select(mfc => new ComplexDto()
            {
                MfcCorner = new MfcCornerDto
                {
                    Id = mfc.Id,
                    Name = mfc.Name,
                    Address = mfc.Address,
                    CreatedAt = mfc.CreatedAt,
                    Latitude = mfc.Latitude,
                    Longitude = mfc.Longitude,
                    TelegtamChatId = mfc.TelegtamChatId,
                    District = new DistrictDto
                    {
                        Id = mfc.DistrictId
                    },
                    Group = mfc.Group,
                    Ip = mfc.Ip,
                    Port = mfc.Port
                },
                EquipmentCondition = new EquipmentConditionDto
                {
                    Analyzer = mfc.EquipmentCondition.Analyzer,
                    Bpbio = mfc.EquipmentCondition.Bpbio,
                    Bsm = mfc.EquipmentCondition.Bsm,
                    Gaz = mfc.EquipmentCondition.Gaz,
                    Pulse = mfc.EquipmentCondition.Pulse
                },
                AllExaminationCount = 0,
                TodayExaminationCount = 0
            }).ToList();

            foreach (var mfcComplexDto in mfcComplexDtos)
            {
                var districtId = mfcCorners.Items.Where(x => x.Id == mfcComplexDto.MfcCorner.Id).First().DistrictId;
                var district = await _districtRepository.GetDistrictAsync(districtId);
                mfcComplexDto.MfcCorner.District.Name = district.Name;
                DateTimeOffset? startOffset = startDate == null ?
                    null : new DateTimeOffset((DateTime)startDate, DateTimeOffset.Now.Offset);
                DateTimeOffset? endOffset = endDate == null ?
                    null : new DateTimeOffset((DateTime)endDate, DateTimeOffset.Now.Offset);
                mfcComplexDto.AllExaminationCount =
                    await _medicalExaminationRepository.GetAllExaminationCountForMfcCorner(mfcComplexDto.MfcCorner.Id, startOffset, endOffset);
                mfcComplexDto.TodayExaminationCount =
                    await _medicalExaminationRepository.GetTodayExaminationCountForMfcCorner(mfcComplexDto.MfcCorner.Id);
            }

            return OperationResult<PagedCollection<ComplexDto>>.Ok(new PagedCollection<ComplexDto> { Total = mfcCorners.Total, Items = mfcComplexDtos });
        }
    }
}
