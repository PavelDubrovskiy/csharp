using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Api.Controllers
{
    /// <summary>
    /// Контроллер для взаимодействия с сущностю "Уголок здоровья"
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
    public class MfcCornerController : ControllerBase
    {
        private readonly IMfcCornerService _mfcCornerService;

        /// <summary>
        /// Конструктор MfcCornerController
        /// </summary>
        /// <param name="mfcCornerService"></param>
        public MfcCornerController(IMfcCornerService mfcCornerService)
        {
            _mfcCornerService = mfcCornerService;
        }

        /// <summary>
        /// Метод получения списка уголков здоровья с применением пагинации.
        /// </summary>
        /// <param name="pageNumber">Обязательный параметр. Номер страницы с которой нужно начать показывать список уголков здоровья</param>
        /// <param name="pageSize">Обязательный параметр. Колличество элементов в странице</param>
        /// <param name="name">Необязательный параметр. Название уголка здоровья или его часть. Используется для поиска </param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<OperationResult<PagedCollection<MfcCornerDto>>>> GetAllMfcAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20, [FromQuery] string name = null)
        {
            var operationResult = await _mfcCornerService.GetAllMfcAsync(pageNumber, pageSize, name);
            return Ok(operationResult);
        }

        /// <summary>
        /// Метод получения списка всех уголков здоровья, находящихся в определенном округе.
        /// </summary>
        /// <param name="districtId"> Идентификатор Округа </param>
        /// <returns></returns>
        [HttpGet("getAllMfcByDistrictIdAsync")]
        public async Task<ActionResult<OperationResult<List<MfcCornerDto>>>> GetAllMfcByDistrictIdAsync( [FromQuery] string districtId)
        {
            var operationResult = await _mfcCornerService.GetAllMfcByDistrictIdAsync(districtId);
            return Ok(operationResult);
        }

        /// <summary>
        /// Метод создания уголка здоровья
        /// </summary>
        /// <param name="createMfcDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<OperationResult>> CreateMfcAsync(CreateMfcCornerDto createMfcDto)
        {
            var operationResult = await _mfcCornerService.CreateMfcAsync(createMfcDto);

            return Ok(operationResult);
        }

        /// <summary>
        /// Метод обновления уголка здоровья
        /// </summary>
        /// <param name="updateMfcDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<OperationResult>> UpdateMfcAsync(UpdateMfcDto updateMfcDto)
        {
            var operarionResult = await _mfcCornerService.UpdateMfcAsync(updateMfcDto);
            return Ok(operarionResult);
        }

        /// <summary>
        /// Метод удаления уголка здоровья
        /// </summary>
        /// <param name="id"> Идентификатор уголка здоровья </param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<OperationResult>> DeleteMfcAsync(string id)
        {
            return await _mfcCornerService.DeleteMfcByIdAsync(id);
        }

        /// <summary>
        /// Метод реинициализации уголка здоровья. 
        /// Заменяет данные локального уголка,
        /// обновляет идентификаторы статистики 
        /// и обследований и отсылает данные на сервер ДИТ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("reinit")]
        public async Task<OperationResult> Reinitialize(string id)
        {
            return await _mfcCornerService.Reinitialize(id);
        }
    }
}
