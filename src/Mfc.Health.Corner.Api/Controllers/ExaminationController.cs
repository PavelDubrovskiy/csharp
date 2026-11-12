using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Api.Controllers
{
    /// <summary>
    /// Контроллер для взаимодействия c управляющим устройством.
    /// Используется только на локальном уголке здоровья в МФЦ.
    /// </summary>
    [Route("/api/v1/ping")]
    [ApiController]
    public class ExaminationController : ControllerBase
    {
        private readonly IExaminationService _examinationService;

        /// <summary>
        /// Конструктор ExaminationController
        /// </summary>
        /// <param name="examinationService"></param>
        public ExaminationController(IExaminationService examinationService)
        {
            _examinationService = examinationService;
        }

        /// <summary>
        /// Метод для отправки команд и обмена информацией с управляющим устройством.
        /// Используется только на локальном уголке МФЦ.
        /// </summary>
        /// <param name="createExamDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Ping([FromForm] CreateExamDto createExamDto)
        {
            try
            {
                var result = await _examinationService.ProcessDataFromControlDevice(createExamDto);
                var iActionresul = Ok(result);            

                return iActionresul;
            }
            catch(Exception e)
            {
                var msg = e.Message;
                throw;
            }
            
        }
    }



}
