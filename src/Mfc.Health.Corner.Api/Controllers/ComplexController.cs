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
    /// Контроллер для получения информации об уголках здоровья
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin")]
    public class ComplexController : ControllerBase
    {
        private readonly IComplexService _complexService;

        /// <summary>
        /// Конструктор ComplexController
        /// </summary>
        /// <param name="complexService"></param>
        public ComplexController(IComplexService complexService)
        {
            _complexService = complexService;
        }

        /// <summary>
        /// Метод получения списка уголков здоровья с указанием их округа и текущих состояний приборов с применением пагинации.
        /// Опционально доступен поиск по интервалу дат создания уголков
        /// </summary>
        /// <param name="pageNumber">Обязательный параметр. Номер страницы с которой нужно начать показывать список уголков здоровья</param>
        /// <param name="pageSize">Обязательный параметр. Колличество элементов в странице</param>
        /// <param name="startDate">Необязательный параметр. Начало интервала поиска, в котором создавались уголки здоровья </param>
        /// <param name="endDate">Необязательный параметр.  Конец  интервала поиска, в котором создавались уголки здоровья </param>
        /// <returns></returns>
        [HttpGet("get-complexes")]
        public async Task<OperationResult<PagedCollection<ComplexDto>>> GetComplexesAsync(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 20,
            [FromQuery] DateTime? startDate = null,
            [FromQuery] DateTime? endDate = null)
        {
            return await _complexService.GetComplexList(pageNumber, pageSize, startDate,endDate);
        }

        /// <summary>
        /// Метод генерации XLSX-файла содержащий список уголков здоровья и их данные.
        /// Опционально для фильтрации списка уголков здоровья, созданных в определенный промежуток времени, можно задать интервал поиска.
        /// </summary>
        /// <param name="startDate">Необязательный параметр. Начало интервала поиска, в котором создавались уголки здоровья </param>
        /// <param name="endDate">Необязательный параметр.  Конец  интервала поиска, в котором создавались уголки здоровья </param>
        /// <returns></returns>
        [HttpGet("report/excel")]
        public async Task<ActionResult> ExportXlsAsync(DateTime? startDate, DateTime? endDate)
        {
            var jwt = Request.Headers.GetJwt();
            var stream = await _complexService.ExportComplexListToXlsAsync(jwt, startDate, endDate);
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
