using System.Threading.Tasks;
using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Common;
using Microsoft.AspNetCore.Mvc;

namespace Mfc.Health.Corner.Api.Controllers
{
    /// <summary>
    /// Используется только на локальном уголке в МФЦ.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertController: ControllerBase
    {
        private readonly IExpertService _expertService;

        /// <summary>
        /// Конструктор ExpertController
        /// </summary>
        /// <param name="expertService"></param>
        public ExpertController(IExpertService expertService)
        {
            _expertService = expertService;
        }

        /// <summary>
        /// Метод вызова специалиста.
        /// Используется только на уголке здоровья в МФЦ.
        /// Отправляет в телекграм-чатсообщение о том, что пользователю нужна помощ специалиста.
        /// </summary>
        /// <returns></returns>
        [HttpPost("call-specialist")]
        public async Task<OperationResult> CallSpecialist()
        {
            return  await _expertService.CallSpecialist();
        }

        /// <summary>
        /// Метод для увеличения счетчик количества записей к доктору.
        /// Используется только на уголке здоровья в МФЦ.
        /// </summary>
        /// <returns></returns>
        [HttpPost("make-appointment-with-doctor")]
        public async Task<ActionResult<OperationResult>> MakeAppointmentWithDoctor()
        {
            return await _expertService.MakeAppointmentWithDoctor();

        }

        /// <summary>
        /// Метод для увеличения счетчика отправленных сообщений в ЕМИАС.
        /// Используется только на уголке здоровья в МФЦ.
        /// </summary>
        /// <returns></returns>
        [HttpPost("send-to-emias")]
        public async Task<ActionResult<OperationResult>> SendToEmias()
        {
            return await _expertService.SendToEmias();
        }

        /// <summary>
        /// Deprecated (В данный момент не используется)
        /// метод для отправки результатов обследования пользователю на почту
        /// </summary>
        /// <param name="mailDto"></param>
        /// <returns></returns>
        [HttpPost("send-mail")]
        public async Task<OperationResult> SendMedicalExaminationResultsMail(SendMedicalExaminationResultsMailDto mailDto)
        {
            return await _expertService.SendMedicalExaminationResults(mailDto.emailAddres);
        }
    }
}
