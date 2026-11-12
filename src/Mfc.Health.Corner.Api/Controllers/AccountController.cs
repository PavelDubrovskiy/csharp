using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Common.Extension;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiConventionType(typeof(DefaultApiConventions))]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IAuthService _services;

        /// <summary>
        /// Конструктор AccountController
        /// </summary>
        /// <param name="accountService"></param>
        /// <param name="services"></param>
        public AccountController(IAccountService accountService, IAuthService services)
        {
            _accountService = accountService;
            _services = services;
        }

        [HttpPost("confirm-email")]
        public async Task<OperationResult> ConfirmEmailAsync(ConfirmEmailDto confirmEmailDto)
        {
            return await _accountService.ConfirmEmailAsync(confirmEmailDto);
        }

        [HttpPost("recovery-password")]
        public async Task<ActionResult<OperationResult>> RecoveryPasswordAsync(RecoveryPasswordDto recoveryPasswordDto)
        {
            var operationResult = await _accountService.RecoveryPasswordAsync(recoveryPasswordDto);

            return Ok(operationResult);
        }

        [Authorize]
        [HttpPost("change-password")]
        public async Task<ActionResult<OperationResult>> ChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            var operationResult = await _accountService.ChangePasswordAsync(changePasswordDto);

            return Ok(operationResult);
        }

        /// <summary>
        /// Метод авторизации пользователя в системе
        /// </summary>
        /// <param name="loginDto"> Сущность для авторизации. Содержит логин и пароль авторизующегося пользователя </param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<ActionResult<OperationResult>> LoginAsync(LoginDto loginDto)
        {
            var operationResult = await _services.AuthenticateAsync(loginDto);

            return Ok(operationResult);
        }
        /// <summary>
        /// Метод проверки валидности токена в хедере Authorization 
        /// </summary>
        /// <returns></returns>
        [HttpGet("checkuser")]
        public async Task<ActionResult<OperationResult>> CheckUser()
        {
            var jwt = Request.Headers.GetJwt();
            var result = await _services.CheckUser(jwt);
            return Ok(result);
        }

        //private string GetJwt(IHeaderDictionary header)
        //{
        //    var authorizationHeader = Request.Headers.ContainsKey("authorization")
        //        ? Request.Headers["authorization"]
        //        : Request.Headers["Authorization"];
        //    if (!String.IsNullOrWhiteSpace(authorizationHeader))
        //    {
        //        return authorizationHeader.ToString().Replace("Bearer ", "");
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
    }
}








