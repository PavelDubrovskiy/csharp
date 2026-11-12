using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Api.Controllers
{
    /// <summary>
    /// Контроллер для отправки команд на уголок здоровья в МФЦ
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CommandDeviceController : ControllerBase
    {
        private readonly ICommandDeviceService _commandDeviceService;

        /// <summary>
        /// Конструктор AccountController
        /// </summary>
        /// <param name="commandDeviceService"></param>
        public CommandDeviceController(ICommandDeviceService commandDeviceService)
        {
            _commandDeviceService = commandDeviceService;
        }

        /// <summary>
        /// Метод создания команды для управления уголком здоровья
        /// Command => содержит неаосредственно команду, которую необходимо выполнить
        /// Group  => содержит базовый адрес уголка, на котором нужно выполеить команду.
        /// Содержится в парпметре Ip сущности MfcCorner  
        /// </summary>
        /// <param name="createCommandDeviceDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task CreateCommondDeviceAsync(CreateCommandDeviceDto createCommandDeviceDto)
        {
            await _commandDeviceService.CreateCommondDeviceAsync(createCommandDeviceDto);
        }
    }
}
