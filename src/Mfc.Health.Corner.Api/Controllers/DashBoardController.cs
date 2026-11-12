using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Common.Extension;
using Mfc.Health.Corner.ZabbixIntegration.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "SuperAdmin,Admin,HeadOfMfc,HeadOfTheMfcDivision,UserManagement")]
    public class DashBoardController : ControllerBase
    {
        private readonly IDashBordService _dashBoaardService;
        

        public DashBoardController(IDashBordService dashBoaardService)
        {
            _dashBoaardService = dashBoaardService;
            
        }
        [HttpGet("getCircleDiagramsData")]
        public async Task<ActionResult<OperationResult<CommonCircleDiagramData>>> GetCircleDiagramsData()
        {
            try
            {
                var jwt = Request.Headers.GetJwt();
                var result = await _dashBoaardService.GetCircleDiagramsData(jwt);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("getStockDiagramByMedDevice")]
        public async Task<ActionResult<OperationResult<StockCountResearchDto>>> GetStockDiagramByMedDevice()
        {
            try
            {
                var jwt = Request.Headers.GetJwt();
                var result = await _dashBoaardService.GetStockDiagramByMedDevice(jwt);
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpGet("GetResearchDynamics")]
        public async Task<ActionResult<OperationResult<ResearchDynamicsDto>>> GetResearchDynamics()
        {
            try
            {
                var jwt = Request.Headers.GetJwt();
                var result = await _dashBoaardService.GetResearchDynamics(jwt);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("getMfcPopularityDataDto")]
        public async Task<ActionResult<OperationResult<List<CornerPopularityDto>>>> GetMfcpopularityData()
        {
            try
            {
                var jwt = Request.Headers.GetJwt();
                var result = await _dashBoaardService.GetMfcPopularityDataDto(jwt);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("getTopTriggers")]
        public async Task<ActionResult<OperationResult<List<ZabbixTopTriggerDto>>>> GetTopTriggers()
        {
            try
            {
                var jwt = Request.Headers.GetJwt();
                var result = await _dashBoaardService.GetTopTriggers(jwt);
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        [HttpGet("getEventLog")]
        public async Task<ActionResult<OperationResult<EventLog>>> GetEventLog([FromQuery] DateTime? eventLogDate = null)
        {
            try
            {
                var jwt = Request.Headers.GetJwt();
                var result = await _dashBoaardService.GetEventLog(jwt,eventLogDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Мутод получения даннывх журнала событий за определенный день 
        /// </summary>
        /// <param name="eventLogDate"> Дата за которую будут получены подробные данные журнала событий. Промер даты => 02-21-2022 </param>
        /// <returns></returns>
        [HttpGet("getJournalEventsTimeByDate")]
        public async Task<ActionResult<OperationResult<List<JournalEventsTime>>>> GetJournalEventsTimeByDate([FromQuery] DateTime? eventLogDate = null)
        {
            try
            {
                var jwt = Request.Headers.GetJwt();
                var result = await _dashBoaardService.GetJournalEventsTimeByDate(jwt, eventLogDate);
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw;
            }
        }


        [HttpGet("getSystemStatusInMinutes")]
        public async Task<ActionResult<OperationResult<SystemStatusDto>>> GetSystemStatusInMinutes()
        {
            try
            {
                var jwt = Request.Headers.GetJwt();
                var result = await _dashBoaardService.GetSystemStatusInMinutes(jwt);
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw;
            }
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
