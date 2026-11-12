using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Mfc.Health.Corner.RabbitMqMessager.Sender.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class ExpertService : IExpertService
    {
        private readonly IMfcCornerRepository _mfcCornerRepository;
        private readonly TelegramBotSettings _telegramBotSettings;
        private readonly ExamResultSendMailSettings _examResultSendMailSettings;
        private readonly IMedicalExaminationRepository _medicalExaminationRepository;
        private readonly IMedExamMailSegmentRepository _medExamMailSegmentRepository;
        private readonly IEmailService _emailService;
        private readonly IMfcCorenerStatisticPerDayRepository _mfcCorenerStatisticPerDayRepository;
        private readonly IMassTransitCommonSender _massTransitCommonSender;


        public ExpertService(IMfcCornerRepository mfcCornerRepository,
            IOptions<TelegramBotSettings> telegramBotSettings,
            IOptions<ExamResultSendMailSettings> examResultSendMailSettings,
            IMedExamMailSegmentRepository medExamMailSegmentRepository,
            IMedicalExaminationRepository medicalExaminationRepository,
            IMfcCorenerStatisticPerDayRepository mfcCorenerStatisticPerDayRepository,
            IEmailService emailService,
            IMassTransitCommonSender massTransitCommonSender)
        {
            _telegramBotSettings = telegramBotSettings.Value;
            _examResultSendMailSettings = examResultSendMailSettings.Value;
            _mfcCornerRepository = mfcCornerRepository;
            _medicalExaminationRepository = medicalExaminationRepository;
            _medExamMailSegmentRepository = medExamMailSegmentRepository;
            _emailService = emailService;
            _massTransitCommonSender = massTransitCommonSender;
            _mfcCorenerStatisticPerDayRepository = mfcCorenerStatisticPerDayRepository;
        }

        public async Task<OperationResult> CallSpecialist()
        {
            await UpdateCallSpecialistCount();

            var urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";

            var apiToken = _telegramBotSettings.ApiToken;
            var text = _telegramBotSettings.Text;

            var mfc = await _mfcCornerRepository.GetLocalMfcAsync();
            if (mfc == null)
            {
                return OperationResult.Error($"Local MfcCorner not found", OperationCode.EntityWasNotFound);
            }
            urlString = String.Format(urlString, _telegramBotSettings.ApiToken,
                mfc.TelegtamChatId, _telegramBotSettings.Text);
            var client = new RestClient(urlString)
            {
                Timeout = -1
            };
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var responceContent = JObject.Parse(response.Content);
                var errorCode = GetJArrayValue(responceContent, "error_code");
                var description = GetJArrayValue(responceContent, "description");
                var errorString =
                    $"Request has failed with error {errorCode}: {description}";
                return OperationResult.Error(errorString);

            }
            return OperationResult.Ok();
        }

        private async Task UpdateCallSpecialistCount()
        {
            var localMfc = await _mfcCornerRepository.GetLocalMfcAsync();
            var noshowedExam = await _medicalExaminationRepository.GetNoShowedExamination();
            var todayStatistic = await _mfcCorenerStatisticPerDayRepository.GetTodayStatistic(localMfc.Id);
            if (todayStatistic == null)
            {
                MfcCorenerStatisticPerDay mfcCorenerStatisticPerDay = new MfcCorenerStatisticPerDay
                {
                    MfcCornerId = localMfc.Id,

                    AnalyzerCount = 0,
                    BPBIOCount = 0,
                    BsmCount = 0,
                    GazCount = 0,
                    PulseCount = 0,
                    FullExamCount = 0,
                    NotFullExamCount = 0,
                    SpecialistCall = 1,
                    Date = DateTime.Today
                };
                mfcCorenerStatisticPerDay = await _mfcCorenerStatisticPerDayRepository.CreateStatistic(mfcCorenerStatisticPerDay);
                await _massTransitCommonSender.SendEntity(mfcCorenerStatisticPerDay);

            }
            else
            {
                todayStatistic.SpecialistCall = todayStatistic.SpecialistCall + 1;
                todayStatistic = await _mfcCorenerStatisticPerDayRepository.UpdateStatistic(todayStatistic);
                await _massTransitCommonSender.SendEntity(todayStatistic);
            }
        }



        public async Task<OperationResult> SendMedicalExaminationResults(string emailAddres)
        {
            var medExamResult = await _medicalExaminationRepository.GetLastMedicalExamination();
            string mesage = await GenerateExamMailMessage(medExamResult);
            if (String.IsNullOrEmpty(mesage))
            {
                return OperationResult.Error("Email templates not found", OperationCode.SendEmailError);
            }
            var emailSendResult = await _emailService.SendEmailAsync(_examResultSendMailSettings, emailAddres, "Результаты диагностики в МФЦ", mesage);
            return emailSendResult.Success ? OperationResult.Ok() : OperationResult.Error(emailSendResult.Message, emailSendResult.Code);
        }

        private async Task<string> GenerateExamMailMessage(UserMedicalExamination medicalExamination)
        {
            string mailMessage = "";

            if (medicalExamination.Examination != null
                && medicalExamination.Examination.Data != null
                && medicalExamination.Examination.Data.Result != null)
            {
                if (medicalExamination.Examination.Data.Result.Bsm != null)
                {
                    mailMessage += " Ростомер <br/>";
                    mailMessage += "<br/>";
                    mailMessage += $" Weight: {medicalExamination.Examination.Data.Result.Bsm.Weight} <br/>\r\n ";
                    mailMessage += $" Height: {medicalExamination.Examination.Data.Result.Bsm.Height} <br/>\r\n ";
                    mailMessage += "<br/>";
                }
                if (medicalExamination.Examination.Data.Result.Analyzer != null)
                {
                    mailMessage += " Анализатор <br/>";
                    mailMessage += "<br/>";
                    mailMessage += $" Bmi: {medicalExamination.Examination.Data.Result.Analyzer.Bmi} <br/>\r\n ";
                    mailMessage += $" Hips_Circ: {medicalExamination.Examination.Data.Result.Analyzer.Hips_Circ} <br/>\r\n ";
                    mailMessage += $" Waist_Circ: {medicalExamination.Examination.Data.Result.Analyzer.Waist_Circ} <br/>\r\n ";
                    mailMessage += $" Whr: {medicalExamination.Examination.Data.Result.Analyzer.Whr} <br/>\r\n ";
                    mailMessage += $" Wt: {medicalExamination.Examination.Data.Result.Analyzer.Wt} <br/>\r\n ";
                    mailMessage += "<br/>";
                }
                if (medicalExamination.Examination.Data.Result.Bpbio != null)
                {
                    mailMessage += " Тонометр <br/>";
                    mailMessage += "<br/>";
                    mailMessage += $" Diastolic: {medicalExamination.Examination.Data.Result.Bpbio.Diastolic} <br/>\r\n ";
                    mailMessage += $" Pulse: {medicalExamination.Examination.Data.Result.Bpbio.Pulse} <br/>\r\n ";
                    mailMessage += $" Systolic: {medicalExamination.Examination.Data.Result.Bpbio.Systolic} <br/>\r\n ";
                    mailMessage += "<br/>";
                }
                if (medicalExamination.Examination.Data.Result.Pulse != null)
                {
                    mailMessage += " Пульсометр <br/>";
                    mailMessage += "<br/>";
                    mailMessage += $" Plethysm: {medicalExamination.Examination.Data.Result.Pulse.Plethysm} <br/>\r\n ";
                    mailMessage += $" Pulse {medicalExamination.Examination.Data.Result.Pulse.Pulse} <br/>\r\n ";
                    mailMessage += $" Spo2: {medicalExamination.Examination.Data.Result.Pulse.Spo2} <br/>\r\n ";
                    mailMessage += "<br/>";

                }
                if (medicalExamination.Examination.Data.Result.Gaz != null)
                {
                    mailMessage += " Газоанализотар <br/>";
                    mailMessage += "<br/>";
                    mailMessage += $" PPM CO: {medicalExamination.Examination.Data.Result.Gaz.Ppmco} <br/>\r\n ";
                    mailMessage += $" % HbCO: {medicalExamination.Examination.Data.Result.Gaz.Cohb} <br/>\r\n ";
                    mailMessage += "<br/>";
                }
            }


            //string mainContent = await _medExamMailSegmentRepository.GetHTMLSegmentByNameAsync("CommonStart");
            //if (!String.IsNullOrEmpty(mainContent))
            //{
            //    mainContent = mainContent.Replace("[InBodyId]", medicalExamination.Id);
            //    mainContent = mainContent.Replace("[age]", medicalExamination.Age);
            //    mainContent = mainContent.Replace("[gender]", medicalExamination.Male ? "Мужской" : "Женский");
            //    mainContent = mainContent.Replace("[sdate]", medicalExamination.CreateDate.ToLocalTime().ToString());
            //    mailMessage += mainContent;
            //    var resultContent = await GetExaminationResultContent(medicalExamination.Examination.Data.Result);
            //    mailMessage += resultContent;
            //    var commonEnd = await _medExamMailSegmentRepository.GetHTMLSegmentByNameAsync("CommonEnd");
            //    mailMessage += commonEnd;
            //}
            return mailMessage;
        }

        private async Task<string> GetExaminationResultContent(Result medicalExaminationResult)
        {
            var resultContent = "";
            if (medicalExaminationResult.Bpbio != null)
            {
                var bpbioString = medicalExaminationResult.Bpbio.GetType().Name;
                var bpbioContent = await _medExamMailSegmentRepository.GetHTMLSegmentByNameAsync(bpbioString);
                if (String.IsNullOrEmpty(bpbioContent))
                {
                    bpbioContent = bpbioContent.Replace("[bpbiosystolic]", medicalExaminationResult.Bpbio.Systolic.ToString());
                    bpbioContent = bpbioContent.Replace("[bpbiodiastolic]", medicalExaminationResult.Bpbio.Diastolic);
                    resultContent += bpbioContent;
                }
            }
            if (medicalExaminationResult.Analyzer != null)
            {
                var analizerString = medicalExaminationResult.Analyzer.GetType().Name;
                var analizerContent = await _medExamMailSegmentRepository.GetHTMLSegmentByNameAsync(analizerString);
                if (String.IsNullOrEmpty(analizerContent))
                {
                    resultContent += analizerContent;
                }
            }
            if (medicalExaminationResult.Pulse != null)
            {
                var pulseString = medicalExaminationResult.Pulse.GetType().Name;
                var pulseContent = await _medExamMailSegmentRepository.GetHTMLSegmentByNameAsync(pulseString);
                if (String.IsNullOrEmpty(pulseContent))
                {
                    pulseContent = pulseContent.Replace("[pulsespo2]", medicalExaminationResult.Pulse.Spo2.ToString());
                    pulseContent = pulseContent.Replace("[pulse]", medicalExaminationResult.Pulse.Pulse.ToString());
                    resultContent += pulseContent;
                }
            }
            if (medicalExaminationResult.Gaz != null)
            {
                var gazString = medicalExaminationResult.Gaz.GetType().Name;
                var gazContent = await _medExamMailSegmentRepository.GetHTMLSegmentByNameAsync(gazString);
                if (String.IsNullOrEmpty(gazContent))
                {
                    gazContent = gazContent.Replace("[gazppmco]", medicalExaminationResult.Gaz.Ppmco.ToString());
                    gazContent = gazContent.Replace("[gazcohb]", medicalExaminationResult.Gaz.Cohb);
                    resultContent += gazContent;
                }
            }
            return resultContent;
        }

        private string GetJArrayValue(JObject yourJArray, string key)
        {
            foreach (KeyValuePair<string, JToken> keyValuePair in yourJArray)
            {
                if (key == keyValuePair.Key)
                {
                    return keyValuePair.Value.ToString();
                }
            }

            return null;
        }

        public async Task<OperationResult> MakeAppointmentWithDoctor()
        {
            await UpdateMakeAppointmentWithDoctorCount();
            return OperationResult.Ok();
        }

        private async Task UpdateMakeAppointmentWithDoctorCount()
        {
            var localMfc = await _mfcCornerRepository.GetLocalMfcAsync();
            var todayStatistic = await _mfcCorenerStatisticPerDayRepository.GetTodayStatistic(localMfc.Id);
            if (todayStatistic == null)
            {
                MfcCorenerStatisticPerDay mfcCorenerStatisticPerDay = new MfcCorenerStatisticPerDay
                {
                    MfcCornerId = localMfc.Id,

                    AnalyzerCount = 0,
                    BPBIOCount = 0,
                    BsmCount = 0,
                    GazCount = 0,
                    PulseCount = 0,
                    FullExamCount = 0,
                    NotFullExamCount = 0,
                    SpecialistCall = 0,
                    DoctorsAppointmentCount = 1,
                    SendEmiasCount = 0,
                    Date = DateTime.Today
                };
                mfcCorenerStatisticPerDay = await _mfcCorenerStatisticPerDayRepository.CreateStatistic(mfcCorenerStatisticPerDay);
                await _massTransitCommonSender.SendEntity(mfcCorenerStatisticPerDay);

            }
            else
            {
                todayStatistic.DoctorsAppointmentCount = todayStatistic.DoctorsAppointmentCount + 1;
                todayStatistic = await _mfcCorenerStatisticPerDayRepository.UpdateStatistic(todayStatistic);
                await _massTransitCommonSender.SendEntity(todayStatistic);
            }
        }

        public async Task<OperationResult> SendToEmias()
        {
            await UpdateSendEmiasCount();
            return OperationResult.Ok();
        }

        private async Task UpdateSendEmiasCount()
        {
            var localMfc = await _mfcCornerRepository.GetLocalMfcAsync();
            var todayStatistic = await _mfcCorenerStatisticPerDayRepository.GetTodayStatistic(localMfc.Id);
            if (todayStatistic == null)
            {
                MfcCorenerStatisticPerDay mfcCorenerStatisticPerDay = new MfcCorenerStatisticPerDay
                {
                    MfcCornerId = localMfc.Id,

                    AnalyzerCount = 0,
                    BPBIOCount = 0,
                    BsmCount = 0,
                    GazCount = 0,
                    PulseCount = 0,
                    FullExamCount = 0,
                    NotFullExamCount = 0,
                    SpecialistCall = 0,
                    DoctorsAppointmentCount = 0,
                    SendEmiasCount = 1,
                    Date = DateTime.Today
                };
                mfcCorenerStatisticPerDay = await _mfcCorenerStatisticPerDayRepository.CreateStatistic(mfcCorenerStatisticPerDay);
                await _massTransitCommonSender.SendEntity(mfcCorenerStatisticPerDay);

            }
            else
            {
                todayStatistic.SendEmiasCount = todayStatistic.SendEmiasCount + 1;
                todayStatistic = await _mfcCorenerStatisticPerDayRepository.UpdateStatistic(todayStatistic);
                await _massTransitCommonSender.SendEntity(todayStatistic);
            }
        }
    }
}
