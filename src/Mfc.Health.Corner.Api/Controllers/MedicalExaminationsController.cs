using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Api.Controllers
{
    /// <summary>
    /// Контроллер для взаимодействия с сущностю "Медицинское обследование"
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalExaminationsController : ControllerBase
    {
        private readonly IMedicalExaminationService _medicalExaminationService;
        private readonly IExaminationService _examinationService;

        /// <summary>
        /// Конструктор MedicalExaminationsController
        /// </summary>
        /// <param name="medicalExaminationService"></param>
        /// <param name="examinationService"></param>
        public MedicalExaminationsController(IMedicalExaminationService medicalExaminationService, IExaminationService examinationService)
        {
            _medicalExaminationService = medicalExaminationService;
            _examinationService = examinationService;
        }

        /// <summary>
        /// Метод создания нового мед. обследования.
        /// Используется только на локальном уголке в МФЦ.
        /// </summary>
        /// <param name="createMedicalExaminationDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<OperationResult<ExaminationDto>>> CreateMedicalExaminationAsync(CreateMedicalExaminationDto createMedicalExaminationDto)
        {
            //var finishResult = await _examinationService.FinishAllExaminations();
            var operationResult = await _medicalExaminationService.CreateMedicalExaminationAsync(createMedicalExaminationDto);

            return Ok(operationResult);
        }

        /// <summary>
        /// Метод получения данных результатов обследования в необработанном виде.
        /// </summary>
        /// <param name="id"> Идентификатор обследования </param>
        /// <returns></returns>
        [HttpGet("getExaminationFullDeviceDataById")]
        public async Task<ActionResult<OperationResult<FullDeviceDataDto>>> GetExaminationFullDeviceDataById(string id)
        {
            try
            {
                var result = await _medicalExaminationService.GetExaminationFullDeviceDataById(id);
                return Ok(result);
            }
            catch(Exception Ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Метод получения данных ростомера и анализатора из последнего обследования.
        /// Используется только на локальном уголке МФЦ.
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-last-examination-analyzer-bsm-data")]
        public async Task<ActionResult<OperationResult<LastExaminationAnalyzerBsmDto>>> GetLastExaminationAnalyzerBsmData()
        {
            var result = await _medicalExaminationService.GetLastExaminationAnalyzerBsmData();
            return Ok(result);
        }
    }
}
