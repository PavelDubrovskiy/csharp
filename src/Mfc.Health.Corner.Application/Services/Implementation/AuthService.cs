using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Application.Validators;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOptions<AuthOptions> _authOptions;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserService _userService;


        public AuthService(IOptions<AuthOptions> authOptions,
            IUserRepository userRepository,
            IUserRoleRepository userRoleRepository,
            IUserService userService,
            IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _authOptions = authOptions;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _userService = userService;
        }

        public async Task<OperationResult<string>> AuthenticateAsync(LoginDto loginDto)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);

            if (user == null)
            {
                return OperationResult.Error<string>("User not found", OperationCode.EntityWasNotFound);
            }

            if (user.Blocked)
            {
                return OperationResult.Error<string>("User blocked", OperationCode.UserBlocked);
            }

            var userHashed = PasswordHasher.VerifyPassword(loginDto.Password, user.Password);

            if (userHashed)
            {
                var token = await GenerateJwtToken(user);

                return OperationResult<string>.Ok(token);
            }
            else
            {
                return OperationResult.Error<string>("User not found", OperationCode.UserBlocked);
            }
        }

        public async Task<OperationResult> CheckUser(string jwt)
        {
            try
            {
                var userFindResult = await _userService.GetUserByJwt(jwt);
                if(userFindResult.Success)
                {
                    return OperationResult.Ok();
                }
                else
                {
                    return OperationResult.Error(userFindResult.Message, userFindResult.Code);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();

            var roleIds = await _userRoleRepository.GetRoleIdsByUserIdAsync(user.Id);

            var roles = await _roleRepository.GetRolesByIdsAsync(roleIds.ToList());

            var claims = new List<Claim>();

            claims.Add(new(ClaimTypes.Sid, user.Id));

            claims.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x.Name)));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.UtcNow.AddDays(authParams.TokenLifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
