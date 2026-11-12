using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Api.Controllers
{
    /// <summary>
    /// Контроллер для взаимодействия с сущностю "Округ"
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        /// <summary>
        /// Конструктор DistrictController
        /// </summary>
        /// <param name="districtService"> Cервис для работы с округами </param>
        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        /// <summary>
        /// Метод получения списка всех округов с опциональным применением пагинации. 
        /// </summary>
        /// <param name="pageNumber">Необязательный параметр. Номер страницы с которой нужно начать показывать округа</param>
        /// <param name="pageSize">Необязательный параметр. Колличество элементов в странице</param>
        /// <param name="name">Необязательный параметр.  Имя пользователя или его часть. Используется для поиска </param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<OperationResult<PagedCollection<DistrictDto>>>> GetAllDistrictsAsync(
            [FromQuery] int? pageNumber, 
            [FromQuery] int? pageSize, 
            [FromQuery] string name = null)
        {
            var operationResult = await _districtService.GetAllDistrictsAsync(pageNumber, pageSize, name);
            return Ok(operationResult);
        }

        /// <summary>
        /// метод создания новой сущности "Округ" 
        /// </summary>
        /// <param name="createDistrictDto"> Сущность содержащая имя создаваемого округа</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<OperationResult<string>>> CreateDistrictAsync(CreateDistrictDto createDistrictDto)
        {
            var operationResult = await _districtService.CreateDistricAsync(createDistrictDto);

            return Ok(operationResult);
        }

        /// <summary>
        /// метод для обновления округа
        /// </summary>
        /// <param name="districtDto"> Обновляемый округ с измененным именем </param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<OperationResult>> UpdateDistrictAsync(DistrictDto districtDto)
        {
            var operarionResult = await _districtService.UpdateDistrictAsync(districtDto);
            return Ok(operarionResult);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<ActionResult<OperationResult>> DeleteDistrictAsync(string id)
        {
            return await _districtService.DeleteDistrictByIdAsync(id);
        }
    }
}
