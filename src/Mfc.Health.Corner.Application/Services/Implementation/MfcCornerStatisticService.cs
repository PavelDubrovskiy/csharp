using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class MfcCornerStatisticService : IMfcCornerStatisticService
    {
        private readonly IMedicalExaminationRepository _medicalExaminationRepository;
        private readonly IMfcCornerRepository _mfcCornerRepository;
        private readonly IMfcCorenerStatisticPerDayRepository _mfcCorenerStatisticPerDayRepository;

        public MfcCornerStatisticService(
            IMedicalExaminationRepository medicalExaminationRepository,
            IMfcCornerRepository mfcCornerRepository,
            IMfcCorenerStatisticPerDayRepository mfcCorenerStatisticPerDayRepository
            )
        {
            _medicalExaminationRepository = medicalExaminationRepository;
            _mfcCornerRepository = mfcCornerRepository;
            _mfcCorenerStatisticPerDayRepository = mfcCorenerStatisticPerDayRepository;
        }
        public async Task<OperationResult<MfcCornerStatisticByHoursDto>> GetMfcCornerStatisticByHours(string mfcCornerId)
        {
            try
            {
                var statistic = new MfcCornerStatisticByHoursDto
                {
                    Hours = new List<MfcCornerStatisticByHourDto>()
                };
                for (int i = 0; i < 24; i++)
                {
                    var hourStatistic = await _medicalExaminationRepository.GetExaminationCountForHour(mfcCornerId, i);
                    statistic.Hours.Add(new MfcCornerStatisticByHourDto
                    {
                        Hour = i + 1,
                        Count = hourStatistic
                    });
                }
                return OperationResult<MfcCornerStatisticByHourDto>.Ok(statistic);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OperationResult<MfcCornerStatisticsByWeekDto>> GetMfcCornerStatisticByWeek(string mfcCornerId)
        {
            try
            {
                var statistic = new MfcCornerStatisticsByWeekDto
                {
                    Week = new List<MfcCornerStatisticsByDayOfWeekDto>()
                };
                var nameOfDays = new List<string> { "Вс", "Пн", "Вт", "Ср", "Чт", "Пт", "Сб" };
                for (int i = 1; i < nameOfDays.Count; i++)
                {
                    statistic.Week.Add(
                        new MfcCornerStatisticsByDayOfWeekDto
                        {
                            Name = nameOfDays[i],
                            Count = await _medicalExaminationRepository.GetExaminationCountForDayOfWeek(mfcCornerId, (DayOfWeek)i)
                        });
                }
                statistic.Week.Add(
                    new MfcCornerStatisticsByDayOfWeekDto
                    {
                        Name = nameOfDays[0],
                        Count = await _medicalExaminationRepository.GetExaminationCountForDayOfWeek(mfcCornerId, DayOfWeek.Sunday)
                    });

                return OperationResult<MfcCornerStatisticsByWeekDto>.Ok(statistic);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OperationResult<MfcCornerStatisticsByMonthsDto>> GetMfcCornerStatisticByMonth(string mfcCornerId)
        {
            try
            {
                var statistic = new MfcCornerStatisticsByMonthsDto
                {
                    Month = new List<MfcCornerStatisticsByDayOfMonthDto>()
                };
                var nameOfMonths = new List<string>
                {
                    "Дек", "Янв", "Фев", "Март", "Апр", "Май", "Июнь", "Июль", "Авг", "Снт", "Окт", "Ноя"
                };
                for (int i = 1; i < nameOfMonths.Count; i++)
                {
                    statistic.Month.Add(
                        new MfcCornerStatisticsByDayOfMonthDto
                        {
                            Name = nameOfMonths[i],
                            Count = await _medicalExaminationRepository.GetExaminationCountForMonth(mfcCornerId, i)
                        });
                }
                statistic.Month.Add(
                    new MfcCornerStatisticsByDayOfMonthDto
                    {
                        Name = nameOfMonths[0],
                        Count = await _medicalExaminationRepository.GetExaminationCountForMonth(mfcCornerId, 12)
                    });

                return OperationResult<MfcCornerStatisticsByDayOfMonthDto>.Ok(statistic);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OperationResult<MfcCornerStatisticsByYearsDto>> GetMfcCornerStatisticByYears(string mfcCornerId)
        {
            try
            {
                var statistic = new MfcCornerStatisticsByYearsDto
                {
                    Year = new List<MfcCornerStatisticsByYearDto>()
                };

                var corner = await _mfcCornerRepository.GetMfcAsync(mfcCornerId);
                int startYear = corner.CreatedAt.Year;
                int endYear = DateTime.Now.Year;

                for (int i = startYear; i <= endYear; i++)
                {
                    statistic.Year.Add(
                        new MfcCornerStatisticsByYearDto
                        {
                            Year = i,
                            Count = await _medicalExaminationRepository.GetExaminationCountForYear(mfcCornerId, i)
                        });
                }

                return OperationResult<MfcCornerStatisticsByYearDto>.Ok(statistic);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OperationResult<DevicePopularityDto>> GetDevicePopularity(string mfcCornerId)
        {
            try
            {
                var popylarity = new DevicePopularityDto
                {
                    AnalyzerProcent = 0,
                    BpbioProcent = 0,
                    BsmProcent = 0,
                    GazProcent = 0,
                    PulseProcent = 0
                };

                int total = 0;
                var corner = await _mfcCornerRepository.GetMfcAsync(mfcCornerId);
                var start = corner.CreatedAt;
                var end = DateTime.Now;

                var data = await _mfcCorenerStatisticPerDayRepository.GetStatisticForPeriod(start, end, mfcCornerId);

                foreach (var elem in data)
                {
                    popylarity.AnalyzerProcent += elem.AnalyzerCount;
                    popylarity.BpbioProcent += elem.BPBIOCount;
                    popylarity.BsmProcent += elem.BsmCount;
                    popylarity.GazProcent += elem.GazCount;
                    popylarity.PulseProcent += elem.PulseCount;
                    total += elem.FullExamCount + elem.NotFullExamCount;
                }

                popylarity.AnalyzerProcent = Math.Round((popylarity.AnalyzerProcent / total * 100), 2);
                popylarity.BpbioProcent = Math.Round((popylarity.BpbioProcent / total * 100), 2);
                popylarity.BsmProcent = Math.Round((popylarity.BsmProcent / total * 100), 2);
                popylarity.GazProcent = Math.Round((popylarity.GazProcent / total * 100), 2);
                popylarity.PulseProcent = Math.Round((popylarity.PulseProcent / total * 100), 2);

                return OperationResult<DevicePopularityDto>.Ok(popylarity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OperationResult<List<ExaminationInfoDto>>> GetLastTenExamination(string mfcCornerId)
        {
            try
            {
                var data = await _medicalExaminationRepository.GetLastTenExamination(mfcCornerId);
                var result = new List<ExaminationInfoDto>();

                foreach (var elem in data)
                {
                    var examinationInfoDto = new ExaminationInfoDto
                    {
                        Id = elem.Id,
                        Date = $"{elem.CreateDate.LocalDateTime.AddHours(3).ToShortTimeString()} {elem.CreateDate.LocalDateTime.ToShortDateString()}",       // $"{elem.CreateDate.DateTime.Hour}:{elem.CreateDate.DateTime.Minute} {elem.CreateDate.DateTime.Day}-{elem.CreateDate.DateTime.Month}-{elem.CreateDate.DateTime.Year}",
                        Age = elem.Age,
                        Phone = elem.PhoneNumber,
                        IsAnalyzerUsed = elem.ComplitedTestIds?.Contains("ANALYZER") ?? false,
                        IsBpbioUsed = elem.ComplitedTestIds?.Contains("BPBIO") ?? false,
                        IsBsmUsed = elem.ComplitedTestIds?.Contains("BSM") ?? false,
                        IsGazUsed = elem.ComplitedTestIds?.Contains("GAZ") ?? false,
                        IsPulseUsed = elem.ComplitedTestIds?.Contains("PULSE") ?? false
                    };
                    result.Add(examinationInfoDto);
                }

                return OperationResult<ExaminationInfoDto>.Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OperationResult<ExaminationAverageValuesDto>> GetAverageValues(string mfcCornerId)
        {
            try
            {
                var corner = await _mfcCornerRepository.GetMfcAsync(mfcCornerId);

                var examinationWithAnalyzer = await _medicalExaminationRepository.GetAnalyzerExaminationForMfcCorner(mfcCornerId, null, null);
                double totalMinutes = 0;
                double averageMinutes = 0;
                double averageCount = 0;
                double totalDays = (DateTime.Now - corner.CreatedAt).TotalDays;
                foreach (var elem in examinationWithAnalyzer)
                {
                    if (elem.CompleteDate != null && elem.CreateDate != null && elem.CompleteDate>elem.CreateDate)
                    {
                        totalMinutes += (elem.CompleteDate.DateTime - elem.CreateDate.DateTime).TotalMinutes;
                    }
                }
                if (totalMinutes != 0)
                {
                    averageMinutes = totalMinutes / examinationWithAnalyzer.Count;
                }
                if (totalDays >= 1)
                {
                    averageCount = examinationWithAnalyzer.Count / totalDays;
                }
                else
                {
                    averageCount = examinationWithAnalyzer.Count;
                }
                var result = new ExaminationAverageValuesDto
                {
                    AverageCount = Math.Round(averageCount, 2),
                    AverageMinutes = Math.Round(averageMinutes, 2)
                };

                return OperationResult<ExaminationAverageValuesDto>.Ok(result);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<OperationResult<MfcCornersStatisticCounts>> GetStatisticCount(string mfcCornerId)
        {
            try
            {
                var staristicResult = new MfcCornersStatisticCounts
                {
                    AllTestsCount = 0,
                    AnalyzerCount = 0,
                    BpbioCount = 0,
                    BsmCount = 0,
                    GazCount = 0,
                    PulseCount = 0
                };

                var corner = await _mfcCornerRepository.GetMfcAsync(mfcCornerId);
                if (corner != null)
                {
                    var allStatistic = await _mfcCorenerStatisticPerDayRepository.GetStatisticForPeriod(null, null, mfcCornerId);

                    foreach (var statistic in allStatistic)
                    {
                        staristicResult.AllTestsCount += statistic.NotFullExamCount + statistic.FullExamCount;
                        staristicResult.AnalyzerCount += statistic.AnalyzerCount;
                        staristicResult.BpbioCount += statistic.BPBIOCount;
                        staristicResult.BsmCount += statistic.BsmCount;
                        staristicResult.GazCount += statistic.GazCount;
                        staristicResult.PulseCount += statistic.PulseCount;
                    }
                }

                return OperationResult<MfcCornersStatisticCounts>.Ok(staristicResult);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
