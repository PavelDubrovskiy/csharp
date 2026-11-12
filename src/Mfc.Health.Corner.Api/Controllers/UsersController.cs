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
    /// <summary>
    /// Контроллер для взаимодействия с сущностю "Пользователь"
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        /// <summary>
        /// Конструктор UsersController
        /// </summary>
        /// <param name="accountService"></param>
        /// <param name="userService"></param>
        public UsersController(IAccountService accountService, IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        /// <summary>
        /// Метод получения списка пользователей с применением пагинации
        /// </summary>
        /// <param name="pageNumber"> Номер страницы с которой нужно начать показывать пользователей </param>
        /// <param name="pageSize"> Колличество элементов в странице </param>
        /// <param name="name"> Имя пользователя или его часть. Необязательный параметр. Используется для поиска </param>
        /// <returns></returns>
        
        [HttpGet]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<OperationResult<PagedCollection<UserDto>>> GetAllUsersAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20, [FromQuery] string name = null)
        {
            return await _userService.GetAllUsersAsync(name, pageNumber, pageSize);
        }

        /// <summary>
        /// Метод получения текущего пользователя по заголовку авторизации
        /// </summary>
        /// <returns></returns>
        [HttpGet("getCurrentUser")]
        public async Task<OperationResult<UserDto>>GetCurrentUser()
        {
            var jwt = Request.Headers.GetJwt();
            return await _userService.GetCurrentUserAsync(jwt);
        }

        /// <summary>
        /// Метод создания пользователя
        /// </summary>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<ActionResult<OperationResult<string>>> CreateUserAccountAsync(CreateUserDto userDto)
        {
            var jwt = Request.Headers.GetJwt();
            var operationResult = await _accountService.CreateAccountAsync(userDto, jwt);

            return Ok(operationResult);
        }

        /// <summary>
        /// Метод обновления пользователя
        /// </summary>
        /// <param name="updateUserDto"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<ActionResult<OperationResult>> UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            return await _userService.UpdateUserAsync(updateUserDto);
        }

        /// <summary>
        /// Метод удаления пользователя
        /// </summary>
        /// <param name="id">Идентификатор удаляемого пользователя</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<ActionResult<OperationResult>> DeleteUserAsync(string id)
        {
            return await _userService.DeleteUserByIdAsync(id);
        }

        /// <summary>
        /// Метод генерации XLSX-файла содержащий список пользователей и их данные.
        /// Опционально для фильтрации списка, созданных в определенный промежуток времени, можно задать интервал поиска.
        /// </summary>
        /// <param name="startDate">Необязательный параметр. Начало интервала поиска, в котором создавались пользователи </param>
        /// <param name="endDate">Необязательный параметр.  Конец  интервала поиска, в котором создавались пользователи</param>
        /// <returns></returns>
        [HttpGet("report/excel")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<ActionResult> ExportXlsAsync(DateTime? startDate, DateTime? endDate)
        {
            var stream = await _userService.ExportUserToXlsAsync(startDate, endDate);

            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"export_{DateTime.UtcNow.ToString("dd.MM.yyyy")}.xlsx");
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
