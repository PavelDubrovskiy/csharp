using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Application.Validators;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Common.Extension;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailConfirmationTokenRepository _emailConfirmationTokenRepository;
        private readonly IEmailService _emailService;
        private readonly IUserIdentity _userIdentity;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserManagementRepository _userManagementRepository;
        private readonly IHeadOfMfcRepository _headOfMfcRepository;
        private readonly IHeadOfDivisionRepository _headOfDivisionRepository;

        private readonly EmailSettings _emailSettings;
        private readonly WebSiteLinks _webSiteLinks;
        private string stream;

        public AccountService(IUserRepository userRepository,
            IEmailConfirmationTokenRepository emailConfirmationTokenRepository,
            IEmailService emailService,
            IUserIdentity userIdentity,
            IUserRoleRepository userRoleRepository,
            IRoleRepository roleRepository,
            IUserManagementRepository userManagementRepository,
            IHeadOfMfcRepository headOfMfcRepository,
            IHeadOfDivisionRepository headOfDivisionRepository,
        IOptions<EmailSettings> emailSettingsOptions,
            IOptions<WebSiteLinks> webSiteLinksOptions
            )
        {
            _userIdentity = userIdentity;
            _userRepository = userRepository;
            _emailConfirmationTokenRepository = emailConfirmationTokenRepository;
            _emailService = emailService;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _userManagementRepository = userManagementRepository;
            _headOfMfcRepository = headOfMfcRepository;
            _headOfDivisionRepository = headOfDivisionRepository;
            _emailSettings = emailSettingsOptions.Value;
            _webSiteLinks = webSiteLinksOptions.Value;
        }

        public async Task<OperationResult<string>> CreateAccountAsync(CreateUserDto createUserDto, string jwt)
        {
            var validator = new CreateUserDtoValidator();

            var validationResult = validator.Validate(createUserDto);

            if (!validationResult.IsValid)
            {
                var msg = validationResult.ToString();
                return OperationResult.Error<string>(msg, OperationCode.ValidationError);
            }

            var smtpConnectionctatus = await _emailService.CheckSmtpConnection(_emailSettings);

            if (!smtpConnectionctatus.Success)
            {
                return OperationResult.Error<string>(smtpConnectionctatus.Message);
            }

            if (createUserDto.RoleNames.Contains("SuperAdmin") || createUserDto.RoleNames.Contains("Admin"))
            {
                var requestUserId = GetUserIdFromJwt(jwt);
                if (string.IsNullOrWhiteSpace(requestUserId))
                {
                    return OperationResult.Error<string>("Invalid Claims", OperationCode.ValidationError);
                }
                else
                {
                    var requestUser = await _userRepository.GetUserByIdAsync(requestUserId);
                    if (requestUser == null)
                    {
                        return OperationResult.Error<string>("User with current token not exist", OperationCode.EntityWasNotFound);
                    }
                    else
                    {
                        var requestUserRoles = await _userRoleRepository.GetUserRolesByUserIdsAsync(new List<string> { requestUser.Id });
                        var requestUserRoleIds = requestUserRoles.Select(x => x.RoleId).ToList();
                        var requestRoles = await _roleRepository.GetRolesByIdsAsync(requestUserRoleIds);
                        var requestUserRoleNames = requestRoles.Select(x => x.Name).ToList();
                        if (!requestUserRoleNames.Contains("SuperAdmin"))
                        {
                            return OperationResult.Error<string>("Insufficient access rights", OperationCode.ValidationError);
                        }
                    }
                }
            }

            var user = new User
            {
                FullName = createUserDto.FullName,
                Phone = createUserDto.Phone,
                Email = createUserDto.Email,
                Login = createUserDto.Login,
                Blocked = createUserDto.Blocked,
            };

            user = await _userRepository.CreateUserAsync(user);
            var roles = await _roleRepository.GetRolesByRoleNamesAsync(createUserDto.RoleNames);
            var userRoles = roles.Select(x => new UserRole() { UserId = user.Id, RoleId = x.Id }).ToList();

            for (int i = 0; i < userRoles.Count; i++)
            {
                userRoles[i] = await _userRoleRepository.CreateUserRoleAsync(userRoles[i]);
            }
            var userDto = new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Phone = user.Phone,
                Email = user.Email,
                Roles = roles.Select(x => new RoleDto { Id = x.Id, Name = x.Name }).ToList(),
                Login = user.Login,
                Blocked = user.Blocked,
                CreatedAt = user.CreatedAt
            };

            var HeadOfDivisionRoleId =
                (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;
            var HeadOfMfcRoleId =
                (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;
            var UserManagementRoleId =
                (await _roleRepository.GetRolesByRoleNamesAsync(
                    new List<string> { "UserManagement" })).FirstOrDefault().Id;

            foreach (var userRole in userRoles)
            {
                if (userRole.RoleId.Equals(HeadOfDivisionRoleId))
                {
                    var newHeadOfDivision = new HeadOfDivision
                    {
                        DistrictId = createUserDto.DistrictId,
                        UserRoleId = userRole.Id
                    };
                    newHeadOfDivision = await _headOfDivisionRepository.CreateHeadOfDivision(newHeadOfDivision);

                    userDto.HeadOfDivision = new HeadOfDivisionDto
                    {
                        Id = newHeadOfDivision.Id,
                        DistrictId = newHeadOfDivision.DistrictId,
                        UserRoleId = newHeadOfDivision.UserRoleId
                    };

                }
                else if (userRole.RoleId.Equals(HeadOfMfcRoleId))
                {
                    var newHeadOfMfc = new HeadOfMfc
                    {
                        MfcCornerId = createUserDto.MfcCornerId,
                        UserRoleId = userRole.Id
                    };
                    newHeadOfMfc = await _headOfMfcRepository.CreateHeadOfMfc(newHeadOfMfc);
                    userDto.HeadOfMfc = new HeadOfMfcDto
                    {
                        Id = newHeadOfMfc.Id,
                        MfcCornerId = newHeadOfMfc.MfcCornerId,
                        UserRoleId = newHeadOfMfc.UserRoleId
                    };

                }
                else if (userRole.RoleId.Equals(UserManagementRoleId))
                {
                    var newUserManagement = new UserManagement
                    {
                        MfcCornerId = createUserDto.MfcCornerId,
                        UserRoleId = userRole.Id
                    };
                    newUserManagement = await _userManagementRepository.CreateUserManagement(newUserManagement);

                    userDto.HeadOfMfc = new HeadOfMfcDto
                    {
                        Id = newUserManagement.Id,
                        MfcCornerId = newUserManagement.MfcCornerId,
                        UserRoleId = newUserManagement.UserRoleId
                    };
                }
            }

            var token = await _emailConfirmationTokenRepository.GenerateEmailConfirmationTokenAsync(user.Id);

            var param = new Dictionary<string, string>
                {
                    {"token", token.ToString() }
                };

            //TODO change localhost
            var callback = QueryHelpers.AddQueryString(_webSiteLinks.ConfirmEmailUrl, param);
            var emailSendResult = await _emailService.SendEmailAsync(_emailSettings, user.Email, "Подтвердить свой аккаунт",
                $"Подтвердите регистрацию, перейдя по ссылке: <a href='{callback}'>link</a>");

            return emailSendResult.Success ? OperationResult<string>.Ok(userDto.Id) :
                OperationResult.Error<string>(emailSendResult.Message, emailSendResult.Code);
        }

        public async Task<OperationResult> ConfirmEmailAsync(ConfirmEmailDto confirmEmailDto)
        {

            var validator = new ConfirmEmailDtoValidator();

            var validationResult = validator.Validate(confirmEmailDto);

            if (!validationResult.IsValid)
            {
                return OperationResult.Error(validationResult.ToString(), OperationCode.ValidationError);
            }

            var userId = await _emailConfirmationTokenRepository.GetUserIdByTokenAsync(confirmEmailDto.Token);

            if (string.IsNullOrEmpty(userId))
            {
                return OperationResult.Error("Token not found");
            }

            var user = await _userRepository.GetUserByIdAsync(userId);

            user.Active = true;

            await _emailConfirmationTokenRepository.DeleteEmailConfirmationTokenAsync(confirmEmailDto.Token);

            var passwordHashed = PasswordHasher.HashPassword(confirmEmailDto.Password);

            user.Password = passwordHashed;

            await _userRepository.UpdateUserAsync(user);

            return OperationResult.Ok();
        }

        public async Task<OperationResult> RecoveryPasswordAsync(RecoveryPasswordDto recoveryPasswordDto)
        {
            var validator = new RecoveryPasswordDtoValidator();

            var validationResult = validator.Validate(recoveryPasswordDto);

            if (!validationResult.IsValid)
            {
                return OperationResult.Error(validationResult.ToString(), OperationCode.ValidationError);
            }

            var user = await _userRepository.GetUserByEmailAsync(recoveryPasswordDto.Email);

            if (user == null)
            {
                return OperationResult.Error("Email not found");
            }

            var token = await _emailConfirmationTokenRepository.GenerateEmailConfirmationTokenAsync(user.Id);

            var param = new Dictionary<string, string>
             {
                 {"token", token.ToString() }
             };
            //TODO change localhost
            var callback = QueryHelpers.AddQueryString(_webSiteLinks.RecoveryEmailUrl, param);
            var emailSendResult = await _emailService.SendEmailAsync(_emailSettings, user.Email, "Восстановление пароля ",
                $"Подтвердите свой пароль, перейдя по ссылке: <a href='{callback}'>link</a>");

            return emailSendResult.Success ? OperationResult.Ok() : OperationResult.Error(emailSendResult.Message, emailSendResult.Code);
        }

        public async Task<OperationResult> ChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            var validator = new ChangePasswordDtoValidator();

            var validationResult = validator.Validate(changePasswordDto);

            if (!validationResult.IsValid)
            {
                return OperationResult.Error(validationResult.ToString(), OperationCode.ValidationError);
            }

            var user = await _userRepository.GetUserByIdAsync(_userIdentity.Id);

            if (user == null)
            {
                return OperationResult.Error("User not found");
            }

            var passwordVerify = PasswordHasher.VerifyPassword(changePasswordDto.OldPassword, user.Password);

            if (!passwordVerify)
            {
                return OperationResult.Error("Password doesn't match");
            }
            var passwordHash = PasswordHasher.HashPassword(changePasswordDto.NewPassword);

            user.Password = passwordHash;

            await _userRepository.UpdateUserAsync(user);

            return OperationResult.Ok();
        }


        private string GetUserIdFromJwt(string jwtString)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtString);
            var tokenS = jsonToken as JwtSecurityToken;


            var id = tokenS.Claims.
                Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid").
                Select(claim => claim.Value).FirstOrDefault();
            return id;
        }
    }
}
