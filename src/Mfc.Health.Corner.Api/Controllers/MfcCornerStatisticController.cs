using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Api.Controllers
{
    /// <summary>
    /// Контроллер получения статистических данный на опрелделенном уголке здоровья
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MfcCornerStatisticController : ControllerBase
    {
        private readonly IMfcCornerStatisticService _mfcCornerStatisticService;

        /// <summary>
        /// Конструктор MfcCornerStatisticController
        /// </summary>
        /// <param name="mfcCornerStatisticService"></param>
        public MfcCornerStatisticController(IMfcCornerStatisticService mfcCornerStatisticService)
        {
            _mfcCornerStatisticService = mfcCornerStatisticService;
        }

        /// <summary>
        /// Метод получения статистики количества обследований,  приходящихся на каждый час дня
        /// </summary>
        /// <param name="mfcCornerId">Идентификатор уголка здоровья</param>
        /// <returns></returns>
        [HttpGet("getMfcCornerStatisticByHours")]
        public async Task<ActionResult<OperationResult<MfcCornerStatisticByHoursDto>>> GetMfcCornerStatisticByHours(string mfcCornerId)
        {
            try
            {
                var result = await _mfcCornerStatisticService.GetMfcCornerStatisticByHours(mfcCornerId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Метод получения Метод получения статистики количества обследований, приходящихся на каждый день недели
        /// </summary>
        /// <param name="mfcCornerId">Идентификатор уголка здоровья</param>
        /// <returns></returns>
        [HttpGet("GetMfcCornerStatisticByWeek")]
        public async Task<ActionResult<OperationResult<MfcCornerStatisticsByWeekDto>>> GetMfcCornerStatisticByWeek(string mfcCornerId)
        {
            try
            {
                var result = await _mfcCornerStatisticService.GetMfcCornerStatisticByWeek(mfcCornerId);
                    return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Метод получения статистики количества обследований, приходящихся на каждый месяц года
        /// </summary>
        /// <param name="mfcCornerId">Идентификатор уголка здоровья</param>
        /// <returns></returns>
        [HttpGet("GetMfcCornerStatisticByMonth")]
        public async Task<ActionResult<OperationResult<MfcCornerStatisticsByMonthsDto>>> GetMfcCornerStatisticByMonth(string mfcCornerId)
        {
            try
            {
                var result = await _mfcCornerStatisticService.GetMfcCornerStatisticByMonth(mfcCornerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Метод получения статистики количества обследований за каждый год существования уголка здоровья
        /// </summary>
        /// <param name="mfcCornerId">Идентификатор уголка здоровья</param>
        /// <returns></returns>
        [HttpGet("getMfcCornerStatisticByYears")]
        public async Task<ActionResult<OperationResult<MfcCornerStatisticsByYearsDto>>> GetMfcCornerStatisticByYears(string mfcCornerId)
        {
            try
            {
                var result = await _mfcCornerStatisticService.GetMfcCornerStatisticByYears(mfcCornerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Метод получения процента популярности использования приборов на уголке здоровья
        /// </summary>
        /// <param name="mfcCornerId">Идентификатор уголка здоровья</param>
        /// <returns></returns>
        [HttpGet("getDevicePopularity")]
        public async Task<ActionResult<OperationResult<DevicePopularityDto>>> GetDevicePopularity(string mfcCornerId)
        {
            try
            {
                var result = await _mfcCornerStatisticService.GetDevicePopularity(mfcCornerId);
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Метод получения информации об использовании приборов в последних 10 обследованиях на уголке здоровья
        /// </summary>
        /// <param name="mfcCornerId">Идентификатор уголка здоровья</param>
        /// <returns></returns>
        [HttpGet("getLastTenExamination")]
        public async Task<ActionResult<OperationResult<List<ExaminationInfoDto>>>> GetLastTenExamination(string mfcCornerId)
        {
            try
            {
                var result = await _mfcCornerStatisticService.GetLastTenExamination(mfcCornerId);
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Метод получения средних значений количества и длительности исследований.
        /// </summary>
        /// <param name="mfcCornerId">Идентификатор уголка здоровья</param>
        /// <returns></returns>
        [HttpGet("getAverageValues")]
        public async Task<ActionResult<OperationResult<ExaminationAverageValuesDto>>> GetAverageValues(string mfcCornerId)
        {
            try
            {
                var result = await _mfcCornerStatisticService.GetAverageValues(mfcCornerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Метод получения количества обследований, произведенных на каждом из приборов за всё время существования уголка.
        /// </summary>
        /// <param name="mfcCornerId"> Идентификатор уголка здоровья </param>
        /// <returns></returns>
        [HttpGet("getStatisticCount")]
        public async Task<ActionResult<OperationResult<MfcCornersStatisticCounts>>> GetStatisticCount(string mfcCornerId)
        {
            try
            {
                var result = await _mfcCornerStatisticService.GetStatisticCount(mfcCornerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
