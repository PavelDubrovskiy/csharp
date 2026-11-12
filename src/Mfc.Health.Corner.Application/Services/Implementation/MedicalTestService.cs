using System;
using System.Threading.Tasks;
using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Mfc.Health.Corner.RabbitMqMessager.Sender.Interfaces;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class MedicalTestService : IMedicalTestService
    {
        private readonly IMedicalExaminationRepository _medicalExaminationRepository;
        private readonly IMassTransitCommonSender _massTransitCommonSender;
        private readonly IMfcCorenerStatisticPerDayRepository _mfcCorenerStatisticPerDayRepository;
        private readonly IMfcCornerRepository _mfcCornerRepository;


        public MedicalTestService(IMedicalExaminationRepository medicalExaminationRepository,
            IMassTransitCommonSender massTransitCommonSender,
            IMfcCorenerStatisticPerDayRepository mfcCorenerStatisticPerDayRepository,
            IMfcCornerRepository mfcCornerRepository)
        {
            _medicalExaminationRepository = medicalExaminationRepository;
            _massTransitCommonSender = massTransitCommonSender;
            _mfcCorenerStatisticPerDayRepository = mfcCorenerStatisticPerDayRepository;
            _mfcCornerRepository = mfcCornerRepository;
        }

        public async Task FinishExamination()
        {
            var noShowedExamination = await _medicalExaminationRepository.GetNoShowedExamination();
            if (noShowedExamination != null)
            {
                noShowedExamination.IsCompleted = true;
                noShowedExamination.IsExaminationResultShowed = true;
                await _medicalExaminationRepository.SaveExaminationAsync(noShowedExamination);
                await _massTransitCommonSender.SendEntity(noShowedExamination);
            }
        }

        //need refactoring
        public async Task<OperationResult> IsShowedUpdate()
        {
            var noShowedExamination = await _medicalExaminationRepository.GetNoShowedExamination();
            if (noShowedExamination != null)
            {
                
                noShowedExamination.TestNames = noShowedExamination.ComplitedTestIds;
                //noShowedExamination = await InicializeNullReferencesInUserMedicalExamination(noShowedExamination);

                noShowedExamination.Examination.Data.CountDone = -10000;
                await _medicalExaminationRepository.SaveExaminationAsync(noShowedExamination);
                
                //if (noShowedExamination.ComplitedTestIds == null || noShowedExamination.ComplitedTestIds.Count == 0)
                //{
                //    return OperationResult.Error("medical examinations have not been carried out", OperationCode.Error);
                //}

                if (noShowedExamination!=null &&  noShowedExamination.TestNames.Count > 0)
                {
                    await _massTransitCommonSender.SendEntity(noShowedExamination);
                    return OperationResult.Ok();
                }
                return OperationResult.Error("medical examinations have not been carried out", OperationCode.EntityWasNotFound);

            }
            else
            {
                return OperationResult.Error("Examination not found", OperationCode.EntityWasNotFound);
            }
        }

        private async Task<UserMedicalExamination> InicializeNullReferencesInUserMedicalExamination(UserMedicalExamination userMedicalExamination)
        {
            try
            {
                if (userMedicalExamination.Examination == null)
                {
                    var localMfc = await _mfcCornerRepository.GetLocalMfcAsync();
                    userMedicalExamination.Examination = new Examination
                    {
                        Group = "1",
                        Ip = localMfc.Ip,
                        Data = new Data
                        {
                            Analyzer = true,
                            Bpbio = true,
                            Bsm = true,
                            Gaz = true,
                            Pulse = true,
                            CountDone = -10000,
                            Result = new Result
                            {
                                Analyzer = null,
                                Pulse = null,
                                Bpbio = null,
                                Bsm = null,
                                Gaz = null
                            }
                        }
                    };
                }
                else
                {
                    if(userMedicalExamination.Examination.Data ==null)
                    {
                        userMedicalExamination.Examination.Data = new Data
                        {
                            Analyzer = true,
                            Bpbio = true,
                            Bsm = true,
                            Gaz = true,
                            Pulse = true,
                            CountDone = -10000,
                            Result = new Result
                            {
                                Analyzer = null,
                                Pulse = null,
                                Bpbio = null,
                                Bsm = null,
                                Gaz = null
                            }
                        };
                    }
                }

                return userMedicalExamination;
            }
            catch(Exception ex)
            {
                throw;
            }
        }


        public async Task<OperationResult> ProcessMedicalTests()
        {
            try
            {
                var incompleteMedicalExamination = await _medicalExaminationRepository.FindIncompleteMedicalExamination();
                var testId = incompleteMedicalExamination.Id ?? null;
                var mfcCornerid = incompleteMedicalExamination.MfcCornerId ?? null;
                while (incompleteMedicalExamination != null)
                {
                    await Task.Delay(1000);
                    incompleteMedicalExamination = await _medicalExaminationRepository.FindIncompleteMedicalExamination();
                    if (incompleteMedicalExamination != null)
                    {
                        testId = incompleteMedicalExamination.Id ?? null;
                        mfcCornerid = incompleteMedicalExamination.MfcCornerId ?? null;
                    }
                }

                if (testId != null && mfcCornerid != null)
                {
                    var todayStatistic = await _mfcCorenerStatisticPerDayRepository.GetTodayStatistic(mfcCornerid);
                    var examination = await _medicalExaminationRepository.GetMedicalExaminationById(testId);
                    if(examination!=null)
                    {
                        if (todayStatistic == null)
                        {
                            MfcCorenerStatisticPerDay mfcCorenerStatisticPerDay = new MfcCorenerStatisticPerDay
                            {
                                MfcCornerId = mfcCornerid,

                                AnalyzerCount = examination.ComplitedTestIds.Contains("ANALYZER") ? 1 : 0,
                                BPBIOCount = examination.ComplitedTestIds.Contains("BPBIO") ? 1 : 0,
                                BsmCount = examination.ComplitedTestIds.Contains("BSM") ? 1 : 0,
                                GazCount = examination.ComplitedTestIds.Contains("GAZ") ? 1 : 0,
                                PulseCount = examination.ComplitedTestIds.Contains("PULSE") ? 1 : 0,
                                FullExamCount = examination.ComplitedTestIds.Count == 5 ? 1 : 0,
                                NotFullExamCount = examination.ComplitedTestIds.Count == 5 ? 0 : 1,
                                SpecialistCall = 0,
                                DoctorsAppointmentCount = 0,
                                SendEmiasCount = 0,
                                Date = DateTime.Today
                            };
                            mfcCorenerStatisticPerDay = await _mfcCorenerStatisticPerDayRepository.CreateStatistic(mfcCorenerStatisticPerDay);
                            await _massTransitCommonSender.SendEntity(mfcCorenerStatisticPerDay);
                        }
                        else
                        {
                            todayStatistic.AnalyzerCount = examination.ComplitedTestIds.Contains("ANALYZER") ?
                                todayStatistic.AnalyzerCount + 1 : todayStatistic.AnalyzerCount;
                            todayStatistic.BPBIOCount = examination.ComplitedTestIds.Contains("BPBIO") ?
                                todayStatistic.BPBIOCount + 1 : todayStatistic.BPBIOCount;
                            todayStatistic.BsmCount = examination.ComplitedTestIds.Contains("BSM") ?
                                todayStatistic.BsmCount + 1 : todayStatistic.BsmCount;
                            todayStatistic.GazCount = examination.ComplitedTestIds.Contains("GAZ") ?
                                todayStatistic.GazCount + 1 : todayStatistic.GazCount;
                            todayStatistic.PulseCount = examination.ComplitedTestIds.Contains("PULSE") ?
                                todayStatistic.GazCount + 1 : todayStatistic.GazCount;
                            todayStatistic.FullExamCount = examination.ComplitedTestIds.Count == 5 ?
                              todayStatistic.FullExamCount + 1 : todayStatistic.FullExamCount;
                            todayStatistic.NotFullExamCount = examination.ComplitedTestIds.Count == 5 ?
                                todayStatistic.NotFullExamCount : todayStatistic.NotFullExamCount + 1;

                            todayStatistic = await _mfcCorenerStatisticPerDayRepository.UpdateStatistic(todayStatistic);
                            await _massTransitCommonSender.SendEntity(todayStatistic);
                        }
                    }

                }

                return OperationResult.Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
