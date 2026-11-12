using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Api.Controllers
{
    /// <summary>
    ///  Контроллер для взаимодействия экстренного завершения всех обследований на уголке здоровья.
    ///  Используется только на локальном уголке в МФЦ
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LocalMfcEngineController : ControllerBase
    {
        private readonly IExaminationService _examinationService;

        /// <summary>
        /// Конструктор LocalMfcEngineController
        /// </summary>
        /// <param name="examinationService"></param>
        public LocalMfcEngineController(IExaminationService examinationService)
        {
            _examinationService = examinationService;
        }
        /// <summary>
        /// Завершает все обследования в используемой БД
        /// Используется только на локальном уголке в МФЦ.
        /// </summary>
        /// <returns></returns>
        [HttpGet("finishLocalExaminations")]
        public async Task<ActionResult<OperationResult>> FinishLocalExaminations()
        {
            try
            {
                var result = await _examinationService.FinishAllExaminations();
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

    }
}
