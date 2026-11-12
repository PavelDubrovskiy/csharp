using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Api.Controllers
{
    /// <summary>
    /// Контроллер для взаимодействия с сущностю "Роль"
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        /// <summary>
        /// Конструктор RolesController
        /// </summary>
        /// <param name="roleService"></param>
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Метод получения списка ролей
        /// Неявно используется формат обмена данными OperationResult.
        /// Возможно возникновение ошибок. 
        /// Необходим рефакторинг со стороны frontend и backend.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<RoleDto>>> GetAllRolesAsync()
        {
            var operationResult = await _roleService.GetAllRolesAsync();
            return Ok(operationResult);
        }
    }
}
