using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Application.Validators;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Common.Extension;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Mfc.Health.Corner.RabbitMqMessager.Sender.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class MedicalExaminationService : IMedicalExaminationService
    {
        private readonly IMedicalExaminationRepository _medicalExaminationRepository;
        private readonly IMfcCornerRepository _mfcCornerRepository;
        private readonly IMassTransitCommonSender _massTransitCommonSender;

        public MedicalExaminationService(IMedicalExaminationRepository medicalExaminationRepository,
            IMfcCornerRepository mfcCornerRepository,
            IMassTransitCommonSender massTransitCommonSender)
        {
            _medicalExaminationRepository = medicalExaminationRepository;
            _mfcCornerRepository = mfcCornerRepository;
            _massTransitCommonSender = massTransitCommonSender;
        }
        //TODO RabbitMq
        public async Task<OperationResult<ExaminationDto>> CreateMedicalExaminationAsync(CreateMedicalExaminationDto createMedicalExaminationDto)
        {
            var validator = new CreateMedicalExaminationDtoValidator();

            var validationResult = validator.Validate(createMedicalExaminationDto);

            if (!validationResult.IsValid)
            {
                return OperationResult.Error<ExaminationDto>(validationResult.ToString(), OperationCode.ValidationError);
            }
            var mfc = await _mfcCornerRepository.GetLocalMfcAsync();

            var сreateMedicalExamination = new UserMedicalExamination
            {
                PhoneNumber = createMedicalExaminationDto.PhoneNumber,
                Age = createMedicalExaminationDto.Age,
                Male = createMedicalExaminationDto.Male,
                MfcCornerId = mfc.Id,
                TestNames = createMedicalExaminationDto.TestNames,
                CreateDate = DateTimeOffset.Now,
                IsCompleted = false,
                IsExaminationResultShowed = false,
                Examination = new Examination
                {
                    Data = new Data
                    {
                        Result = new Result()
                    }
                },
                ComplitedTestIds = new List<string>(),
                FailedAttempts = new List<FailedAttemptsCount>()
        };

            ExaminationDto resut = new ExaminationDto();
            сreateMedicalExamination.Id = await _medicalExaminationRepository.CreateMedicalExaminationAsync(сreateMedicalExamination);
            resut.ExaminationId = сreateMedicalExamination.Id;
            await _massTransitCommonSender.SendEntity(сreateMedicalExamination);
            return OperationResult<ExaminationDto>.Ok(resut);
        }

        public async Task<OperationResult<FullDeviceDataDto>> GetExaminationFullDeviceDataById(string id)
        {
            try
            {
                var examination = await _medicalExaminationRepository.GetMedicalExaminationById(id);
                FullDeviceDataDto result = new FullDeviceDataDto();
                if (examination!= null)
                {
                    result.Analyzer = examination.Examination?.Data?.Result?.Analyzer?.FullDeviceData??"";
                    result.Bpbio = examination.Examination?.Data.Result?.Bpbio?.FullDeviceData ?? "";
                    result.Bsm = examination.Examination?.Data?.Result?.Bsm?.FullDeviceData ?? "";
                    result.Gaz = examination.Examination?.Data?.Result?.Gaz?.FullDeviceData ?? "";
                    result.Pulse = examination.Examination?.Data?.Result?.Pulse?.FullDeviceData ?? "";
                }
                return OperationResult<FullDeviceDataDto>.Ok(result);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<OperationResult<LastExaminationAnalyzerBsmDto>> GetLastExaminationAnalyzerBsmData()
        {
            var mfc = await _mfcCornerRepository.GetLocalMfcAsync();
            var lastExam = await _medicalExaminationRepository.GetLastMedicalExamination();

            if (lastExam != null && lastExam.Examination!=null &&
                lastExam.Examination.Data.Result.Analyzer != null &&
                lastExam.Examination.Data.Result.Bsm != null)
            {
                var bmr = lastExam.Male ?
                    10 * lastExam.Examination.Data.Result.Analyzer.Wt +
                    6.25 * lastExam.Examination.Data.Result.Bsm.Height -
                    5 * int.Parse(lastExam.Age) + 5 :
                    10 * lastExam.Examination.Data.Result.Analyzer.Wt +
                    6.25 * lastExam.Examination.Data.Result.Bsm.Height -
                    5 * int.Parse(lastExam.Age) - 161;

                var result = new LastExaminationAnalyzerBsmDto
                {
                    nameComplex = mfc.Name,
                    AGE = lastExam.Age,
                    BMI = lastExam.Examination.Data.Result.Analyzer.Bmi,
                    WT = lastExam.Examination.Data.Result.Analyzer.Wt,
                    GENDER = lastExam.Male ? "M" : "W",
                    idClient = lastExam.PhoneNumber,
                    HT = lastExam.Examination.Data.Result.Bsm.Height,
                    BMR = bmr
                };
                return OperationResult<FullDeviceDataDto>.Ok(result);
            }
            else
            {
                return OperationResult.Error<LastExaminationAnalyzerBsmDto>(
                    "The last medical examination does not contain analyzer and BSM data", 
                    OperationCode.EntityWasNotFound);
            }
        }
    }
}
