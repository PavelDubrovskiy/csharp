using ClosedXML.Excel;
using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Common.Excel;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Application.Validators;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly DefaultAppsettingsUser _defaultAppsettingsUser = null;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserManagementRepository _userManagementRepository;
        private readonly IHeadOfMfcRepository _headOfMfcRepository;
        private readonly IHeadOfDivisionRepository _headOfDivisionRepository;
        private readonly IConfiguration _configuration;
        private readonly IDistrictRepository _districtRepository;
        private readonly IMfcCornerRepository _mfcCornerRepository;


        public UserService(IUserRepository userRepository,
            IUserManagementRepository userManagementRepository,
            IHeadOfMfcRepository headOfMfcRepository,
            IHeadOfDivisionRepository headOfDivisionRepository,
            IRoleRepository roleRepository,
            IConfiguration configuration,
            IUserRoleRepository userRoleRepository,
            IOptions<DefaultAppsettingsUser> defaultAppsettingsUser,
            IDistrictRepository districtRepository,
            IMfcCornerRepository mfcCornerRepository)

        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _userManagementRepository = userManagementRepository;
            _headOfMfcRepository = headOfMfcRepository;
            _headOfDivisionRepository = headOfDivisionRepository;
            _configuration = configuration;
            _districtRepository = districtRepository;
            _mfcCornerRepository = mfcCornerRepository;
            _defaultAppsettingsUser = defaultAppsettingsUser.Value;
        }

        public async Task<OperationResult<PagedCollection<UserDto>>> GetAllUsersAsync(string name, int pageNumber, int pageSize)
        {
            if (pageNumber == 0)
            {
                return OperationResult.Error<PagedCollection<UserDto>>("Page can not be null", OperationCode.ValidationError);
            }

            if (pageSize == 0)
            {
                return OperationResult.Error<PagedCollection<UserDto>>("Page size can not be null", OperationCode.ValidationError);
            }

            var pagedUsers = await _userRepository.GetAllUsersByQueryAsync(name, pageNumber, pageSize);

            var usersDto = new List<UserDto>();

            var HeadOfDivisionRoleId =
              (await _roleRepository.GetRolesByRoleNamesAsync(
                  new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;
            var HeadOfMfcRoleId =
                (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;
            var UserManagementRoleId =
                (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "UserManagement" })).FirstOrDefault().Id;


            foreach (var user in pagedUsers.Items)
            {
                var currentUserDto = await GetUserDtoAsync(user, HeadOfDivisionRoleId, HeadOfMfcRoleId, UserManagementRoleId);
                usersDto.Add(currentUserDto);
            }

            return OperationResult<PagedCollection<UserDto>>.Ok(new PagedCollection<UserDto> { Total = pagedUsers.Total, Items = usersDto });
        }

        public async Task<OperationResult<UserDto>> GetCurrentUserAsync(string jwt)
        {
            var userResut = await GetUserByJwt(jwt);

            if (!userResut.Success)
            {
                return new OperationResult<UserDto>(userResut.Code, userResut.Message);
            }

            var user = userResut.Object;

            var HeadOfDivisionRoleId =
              (await _roleRepository.GetRolesByRoleNamesAsync(
                  new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;

            var HeadOfMfcRoleId =
                (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;

            var UserManagementRoleId =
                (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "UserManagement" })).FirstOrDefault().Id;

            var userDto = await GetUserDtoAsync(user, HeadOfDivisionRoleId, HeadOfMfcRoleId, UserManagementRoleId);

            return OperationResult<PagedCollection<UserDto>>.Ok(userDto);
        }

        private async Task<UserDto> GetUserDtoAsync(User user,  string HeadOfDivisionRoleId, string HeadOfMfcRoleId, string UserManagementRoleId)
        {
            var userRoles = await _userRoleRepository.GetUserRolesByUserIdsAsync(new List<string> { user.Id });
            var roleIds = await _userRoleRepository.GetRoleIdsByUserIdAsync(user.Id);

            var roles = await _roleRepository.GetRolesByIdsAsync(roleIds);

            var currentUserRoles = userRoles.Where(x => x.UserId == user.Id).ToList();
            var currentRoleIds = currentUserRoles.Select(x => x.RoleId).ToList();

            var currentRoles = roles.Where(x => currentRoleIds.Contains(x.Id)).ToList();

            MfcCornerDto mfcCorner = null;
            DistrictDto districtDto = null;

            HeadOfMfcDto headOfMfcDto = await GetHeadOfMfcDto(currentUserRoles, HeadOfMfcRoleId);
            if (headOfMfcDto != null)
            {
                mfcCorner = await GetMfcCornerDtoAsync(headOfMfcDto);
            }

            HeadOfDivisionDto headOfDivisionDto = await GetHeadOfDivisionDto(currentUserRoles, HeadOfDivisionRoleId);
            if (headOfDivisionDto != null)
            {
                var district = await _districtRepository.GetDistrictAsync(headOfDivisionDto.DistrictId);
                districtDto = new DistrictDto { Id = district.Id, Name = district.Name };
            }

            UserManagementDto userManagementDto = await GetUserManagementDto(currentUserRoles, UserManagementRoleId);
            if (userManagementDto != null)
            {
                mfcCorner = await GetMfcCornerDtoAsync(userManagementDto);
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Phone = user.Phone,
                Email = user.Email,
                Login = user.Login,
                Roles = currentRoles.Select(x => new RoleDto { Id = x.Id, Name = x.Name }).ToList(),
                HeadOfDivision = headOfDivisionDto,
                HeadOfMfc = headOfMfcDto,
                UserManagement = userManagementDto,
                Blocked = user.Blocked,
                CreatedAt = user.CreatedAt,
                MfcCorner = mfcCorner,
                District = districtDto

            };

            return userDto;
        }



        private async Task<HeadOfMfcDto> GetHeadOfMfcDto(List<UserRole> currentUserRoles, string HeadOfMfcRoleId)
        {
            var headOfMfcUserRole = currentUserRoles.Where(x => x.RoleId == HeadOfMfcRoleId).FirstOrDefault();
            if (headOfMfcUserRole != null)
            {
                var headOfMfc = await _headOfMfcRepository.GetHeadOfMfcByUserRoleId(headOfMfcUserRole.Id);
                if (headOfMfc != null)
                {
                    return new HeadOfMfcDto
                    {
                        Id = headOfMfc.Id,
                        MfcCornerId = headOfMfc.MfcCornerId,
                        UserRoleId = headOfMfc.UserRoleId
                    };
                }
            }
            return null;
        }

        private async Task<HeadOfDivisionDto> GetHeadOfDivisionDto(List<UserRole> currentUserRoles, string HeadOfDivisionRoleId)
        {
            HeadOfDivisionDto headOfDivisionDto = null;
            var HeadOfDivisionUserRole = currentUserRoles.Where(x => x.RoleId == HeadOfDivisionRoleId).FirstOrDefault();
            if (HeadOfDivisionUserRole != null)
            {
                var headOfDivision = await _headOfDivisionRepository.GetHeadOfDivisionByUserRoleId(HeadOfDivisionUserRole.Id);
                if (headOfDivision != null)
                {
                    return new HeadOfDivisionDto
                    {
                        Id = headOfDivision.Id,
                        DistrictId = headOfDivision.DistrictId,
                        UserRoleId = headOfDivision.UserRoleId
                    };
                }
            }

            return null;
        }

        private async Task<UserManagementDto> GetUserManagementDto(List<UserRole> currentUserRoles, string UserManagementRoleId)
        {
            var userManagementUserRole = currentUserRoles.Where(x => x.RoleId == UserManagementRoleId).FirstOrDefault();
            if (userManagementUserRole != null)
            {
                var UserManagement = await _userManagementRepository.GetUserManagementById(userManagementUserRole.Id);
                if (UserManagement != null)
                {
                    return new UserManagementDto
                    {
                        Id = UserManagement.Id,
                        MfcCornerId = UserManagement.MfcCornerId,
                        UserRoleId = UserManagement.UserRoleId
                    };
                }
            }
            return null;
        }

        private async Task<MfcCornerDto> GetMfcCornerDtoAsync(UserManagementDto userManagementDto)
        {
            var corner = await _mfcCornerRepository.GetMfcAsync(userManagementDto.MfcCornerId);
            var district = await _districtRepository.GetDistrictAsync(corner.DistrictId);
            return new MfcCornerDto
            {
                Id = corner.Id,
                Address = corner.Address,
                CreatedAt = corner.CreatedAt,
                District = new DistrictDto
                {
                    Id = district.Id,
                    Name = district.Name
                },
                Group = corner.Group,
                Ip = corner.Ip,
                Latitude = corner.Latitude,
                Longitude = corner.Longitude,
                Name = corner.Name,
                Port = corner.Port,
                TelegtamChatId = corner.TelegtamChatId
            };
        }

        private async Task<MfcCornerDto> GetMfcCornerDtoAsync(HeadOfMfcDto headOfMfcDto)
        {
            var corner = await _mfcCornerRepository.GetMfcAsync(headOfMfcDto.MfcCornerId);
            var district = await _districtRepository.GetDistrictAsync(corner.DistrictId);
            return new MfcCornerDto
            {
                Id = corner.Id,
                Address = corner.Address,
                CreatedAt = corner.CreatedAt,
                District = new DistrictDto
                {
                    Id = district.Id,
                    Name = district.Name
                },
                Group = corner.Group,
                Ip = corner.Ip,
                Latitude = corner.Latitude,
                Longitude = corner.Longitude,
                Name = corner.Name,
                Port = corner.Port,
                TelegtamChatId = corner.TelegtamChatId
            };
        }

        public async Task<OperationResult> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            var validator = new UpdateUserDtoValidator();

            var validationResult = validator.Validate(updateUserDto);

            if (!validationResult.IsValid)
            {
                return OperationResult.Error(validationResult.ToString(), OperationCode.ValidationError);
            }

            if (updateUserDto.Id.Equals(_defaultAppsettingsUser.Id) && !updateUserDto.RoleNames[0].Equals("SuperAdmin"))
            {
                return OperationResult.Error("Current User cannot be updated");
            }

            var user = await _userRepository.GetUserByIdAsync(updateUserDto.Id);

            if (user == null)
            {
                return OperationResult.Error("User not found", OperationCode.EntityWasNotFound);
            }

            user.FullName = updateUserDto.FullName;
            user.Phone = updateUserDto.Phone;
            user.Email = updateUserDto.Email;
            user.Login = updateUserDto.Login;
            user.Blocked = updateUserDto.Blocked;

            await _userRepository.UpdateUserAsync(user);

            var HeadOfDivisionRoleId =
             (await _roleRepository.GetRolesByRoleNamesAsync(
                 new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;
            var HeadOfMfcRoleId =
                (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;
            var UserManagementRoleId =
                (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "UserManagement" })).FirstOrDefault().Id;

            var roles = await _roleRepository.GetRolesByRoleNamesAsync(updateUserDto.RoleNames);
            var userRoles = roles.Select(x => new UserRole() { UserId = user.Id, RoleId = x.Id }).ToList();


            //var roleIds = await _userRoleRepository.GetRoleIdsByUserIdAsync(user.Id);
            //var userRoles = await _userRoleRepository.GetUserRolesByUserIdsAsync(new List<string> { updateUserDto.Id });

            //var deletedRoleIds = userRoles[0]..Except(updateUserDto.RoleNames).ToList();
            if (userRoles[0].RoleId.Contains(HeadOfDivisionRoleId) ||
                userRoles[0].RoleId.Contains(HeadOfMfcRoleId) ||
                userRoles[0].RoleId.Contains(UserManagementRoleId))
            {
                //foreach (var deletedRoleId in deletedRoleIds)
                //{
                if (userRoles[0].RoleId.Equals(HeadOfDivisionRoleId))
                {
                    var deletedUserRole = userRoles.Where(u => u.RoleId == userRoles[0].RoleId).FirstOrDefault();
                    if (deletedUserRole != null)
                    {
                        await _headOfDivisionRepository.DeleteHeadOfDivisionByUserRoleId(deletedUserRole.Id);
                    }
                }
                else if (userRoles[0].RoleId.Equals(HeadOfMfcRoleId))
                {
                    var deletedUserRole = userRoles.Where(u => u.RoleId == userRoles[0].RoleId).FirstOrDefault();
                    if (deletedUserRole != null)
                        await _headOfMfcRepository.DeleteHeadOfMfcByUserRoleId(deletedUserRole.Id);
                }
                else if (userRoles[0].RoleId.Equals(UserManagementRoleId))
                {
                    var deletedUserRole = userRoles.Where(u => u.RoleId == userRoles[0].RoleId).FirstOrDefault();
                    if (deletedUserRole != null)
                    {
                        await _userManagementRepository.DeleteUserManagementByUserRoleId(deletedUserRole.Id);
                    }
                }
                // }
            }
            await _userRoleRepository.DeleteUserRoleByRoleIdsAsync(new List<string> { userRoles[0].RoleId }, user.Id);

            // var newRoleIds = updateUserDto.RoleNames.Except(roleIds).ToList();
            var newUserRoles = new List<UserRole> { new UserRole { UserId = user.Id, RoleId = userRoles[0].RoleId } };

            for (int i = 0; i < newUserRoles.Count; i++)
            {
                newUserRoles[i] = await _userRoleRepository.CreateUserRoleAsync(newUserRoles[i]);
            }

            if (userRoles[0].RoleId.Equals(HeadOfDivisionRoleId) ||
                userRoles[0].RoleId.Equals(HeadOfMfcRoleId) ||
                userRoles[0].RoleId.Equals(UserManagementRoleId))
            {
                foreach (var userRole in newUserRoles)
                {
                    if (userRole.RoleId.Equals(HeadOfDivisionRoleId))
                    {
                        var newHeadOfDivision = new HeadOfDivision
                        {
                            DistrictId = updateUserDto.DistrictId,
                            UserRoleId = userRole.Id
                        };
                        newHeadOfDivision = await _headOfDivisionRepository.CreateHeadOfDivision(newHeadOfDivision);
                    }
                    else if (userRole.RoleId.Equals(HeadOfMfcRoleId))
                    {
                        var newHeadOfMfc = new HeadOfMfc
                        {
                            MfcCornerId = updateUserDto.MfcCornerId,
                            UserRoleId = userRole.Id
                        };
                        newHeadOfMfc = await _headOfMfcRepository.CreateHeadOfMfc(newHeadOfMfc);

                    }
                    else if (userRole.RoleId.Equals(UserManagementRoleId))
                    {
                        var newUserManagement = new UserManagement
                        {
                            MfcCornerId = updateUserDto.MfcCornerId,
                            UserRoleId = userRole.Id
                        };
                        newUserManagement = await _userManagementRepository.CreateUserManagement(newUserManagement);
                    }
                }
            }

            foreach (var updatedRole in userRoles)
            {
                if (updatedRole.RoleId.Equals(HeadOfDivisionRoleId))
                {
                    if (string.IsNullOrWhiteSpace(updateUserDto.DistrictId))
                    {
                        var updateHeadOfDivision = await _headOfDivisionRepository.GetHeadOfDivisionByUserRoleId(updatedRole.Id);
                        updateHeadOfDivision.DistrictId = updateUserDto.DistrictId;
                        await _headOfDivisionRepository.UpdateHeadOfDivisionAsync(updateHeadOfDivision);
                    }
                }
                else if (updatedRole.Equals(HeadOfMfcRoleId))
                {
                    if (string.IsNullOrWhiteSpace(updateUserDto.MfcCornerId))
                    {
                        var updatedHeadOfMfc = await _headOfMfcRepository.GetHeadOfMfcByUserRoleId(updatedRole.Id);
                        updatedHeadOfMfc.MfcCornerId = updateUserDto.MfcCornerId;
                        await _headOfMfcRepository.UpdateHeadOfMfAsync(updatedHeadOfMfc);
                    }
                }
                else if (updatedRole.Equals(UserManagementRoleId))
                {
                    if (string.IsNullOrWhiteSpace(updateUserDto.MfcCornerId))
                    {
                        var updatedUserManagement = await _userManagementRepository.GetUserManagementUserRoleId(updatedRole.Id);
                        updatedUserManagement.MfcCornerId = updateUserDto.MfcCornerId;
                        await _userManagementRepository.UpdateuserManagementAsync(updatedUserManagement);

                    }
                }
            }

            return OperationResult.Ok();
        }

        public async Task<OperationResult> DeleteUserByIdAsync(string id)
        {

            if (string.IsNullOrEmpty(id))
            {
                return OperationResult.Error("Id can not be null or empty", OperationCode.ValidationError);
            }

            if (id.Equals(_defaultAppsettingsUser.Id))
            {
                return OperationResult.Error("CurrentUser cannot be deleted");
            }

            var userDeleted = await _userRepository.DeleteUserByIdAsync(id);


            if (!userDeleted)
            {
                return OperationResult.Error("User not found", OperationCode.EntityWasNotFound);
            }

            return OperationResult.Ok();
        }

        public async Task<MemoryStream> ExportUserToXlsAsync(DateTime? startDate, DateTime? endDate)
        {
            var users = await _userRepository.GetUsersByPeriodAsync(startDate, endDate);
            var roles = await _roleRepository.GetAllRolesAsync();
            DataTable excelUsers = new DataTable("Users");



            excelUsers.Columns.AddRange(new DataColumn[7] { new DataColumn("Id"),
                                        new DataColumn("FullName"),
                                        new DataColumn("Phone"),
                                        new DataColumn("Login"),
                                        new DataColumn("Email"),
                                        new DataColumn("Blocked"),
                                        new DataColumn("Role") });

            foreach (var user in users)
            {

                var userRoleId = (await _userRoleRepository.GetUserRolesByUserIdsAsync(new List<string> { user.Id })).FirstOrDefault()?.RoleId ?? null;
                var userRoleName = roles.Where(x => x.Id == userRoleId).FirstOrDefault()?.Name ?? "";
                excelUsers.Rows.Add(user.Id, user.FullName, user.Phone, user.Login, user.Email, user.Blocked, userRoleName);
            }

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

        public async Task<OperationResult<User>> GetUserByJwt(string jwt)
        {
            try
            {
                var userId = GetUserIdFromJwt(jwt);
                User user = null;
                if (string.IsNullOrWhiteSpace(userId))
                {
                    return OperationResult.Error<User>("Invalid Claims", OperationCode.ValidationError);
                }
                else
                {
                    user = await _userRepository.GetUserByIdAsync(userId);
                    if (user == null)
                    {
                        return OperationResult.Error<User>("User with current token not exist", OperationCode.EntityWasNotFound);
                    }
                }
                return OperationResult<User>.Ok(user);
            }
            catch
            {
                return OperationResult.Error<User>("User not found", OperationCode.EntityWasNotFound);
            }
        }


        private string GetUserIdFromJwt(string jwtString)
        {
            try
            {
                bool isValid = ValidateToken(jwtString);
                if (isValid)
                {
                    var handler = new JwtSecurityTokenHandler();
                    var jsonToken = handler.ReadToken(jwtString);
                    var tokenS = (JwtSecurityToken)jsonToken;

                    var id = tokenS.Claims.
                        Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid").
                        Select(claim => claim.Value).FirstOrDefault();
                    return id;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private bool ValidateToken(string authToken)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = GetValidationParameters();

                SecurityToken validatedToken;
                IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
                return true;
            }
            catch
            {
                return false;
            }

        }

        private TokenValidationParameters GetValidationParameters()
        {
            var autOp = _configuration.GetSection("Auth").Get<AuthOptions>();

            return new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = autOp.Issuer,
                ValidateAudience = true,
                ValidAudience = autOp.Audience,
                ValidateLifetime = true,
                IssuerSigningKey = autOp.GetSymmetricSecurityKey(),
                ValidateIssuerSigningKey = true,
            };
        }

    }
}
