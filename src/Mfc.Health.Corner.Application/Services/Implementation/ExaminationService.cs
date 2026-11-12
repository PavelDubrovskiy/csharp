using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Mfc.Health.Corner.RabbitMqMessager.Sender.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Data = Mfc.Health.Corner.Domain.Models.Data;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class ExaminationService : IExaminationService
    {
        private readonly IMedicalExaminationRepository _medicalExaminationRepository;
        private readonly IMfcCornerRepository _mfcCornerRepository;
        private readonly ICommandDeviceRepository _commandDeviceRepository;
        private readonly SendStatusInfoSettings _sendStatusInfoSettings;
        private readonly IConnectionManager _webSocketConnectionManager;
        private readonly ISocketMessager _socketMessager;
        private readonly WebSocketsSettings _webSocketsSettings;
        private readonly IMfcCorenerStatisticPerDayRepository _mfcCorenerStatisticPerDayRepository;
        private readonly IMassTransitCommonSender _massTransitCommonSender;
        private readonly IWebSocketClientService _webSocketClientService;

        public ExaminationService(IMedicalExaminationRepository medicalExaminationRepository,
             IMfcCornerRepository mfcCornerRepository,
             IOptions<SendStatusInfoSettings> sendStatusInfoSettingsOptions,
             IOptions<WebSocketsSettings> webSocketsSettingsOptions,
             ICommandDeviceRepository commandDeviceRepository,
             IConnectionManager webSocketConnectionManager,
             IMfcCorenerStatisticPerDayRepository mfcCorenerStatisticPerDayRepository,
             ISocketMessager socketMessager,
             IMassTransitCommonSender massTransitCommonSender,
             IWebSocketClientService webSocketClientService)
        {
            _medicalExaminationRepository = medicalExaminationRepository;
            _mfcCornerRepository = mfcCornerRepository;
            _commandDeviceRepository = commandDeviceRepository;
            _sendStatusInfoSettings = sendStatusInfoSettingsOptions.Value;
            _webSocketsSettings = webSocketsSettingsOptions.Value;
            _mfcCorenerStatisticPerDayRepository = mfcCorenerStatisticPerDayRepository;
            _webSocketConnectionManager = webSocketConnectionManager;
            _socketMessager = socketMessager;
            _massTransitCommonSender = massTransitCommonSender;
            _webSocketClientService = webSocketClientService;
        }

        public async Task<ExaminationResponseDto> ProcessDataFromControlDevice(CreateExamDto createExamDto)
        {
            try
            {
                var responsedCommand = new ExaminationResponseDto()
                {
                    Data = "{}",
                    Status = "RESTART"
                };

                await CheckGroupParameter(createExamDto);
                var commandDeviceData = ParseCommandDeviceData(createExamDto);
                if (commandDeviceData != null)
                {
                    await SendEquipmentCondition(new EquipmentConditionDto
                    {
                        Analyzer = commandDeviceData.Data.Analyzer,
                        Bpbio = commandDeviceData.Data.Bpbio,
                        Bsm = commandDeviceData.Data.Bsm,
                        Gaz = commandDeviceData.Data.Gaz,
                        Pulse = commandDeviceData.Data.Pulse,
                        Status = commandDeviceData.Data.Status
                    });

                    //await SendStatusInfo(commandDeviceData);
                    responsedCommand = await ProcessControlDeviceCommand(commandDeviceData);
                }
                //await _webSocketClientService.SendStatus(responsedCommand.Status);
                return responsedCommand;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                throw;
            }
        }

        private CreateExaminationDto ParseCommandDeviceData(CreateExamDto createExamDto)
        {
            try
            {
                return new CreateExaminationDto
                {
                    Group = createExamDto.Group,
                    Ip = createExamDto.Ip,
                    Data = JsonConvert.DeserializeObject<DataDto>(createExamDto.Data)
                };

            }
            catch
            {
                return null;
            }
        }

        private async Task CheckGroupParameter(CreateExamDto createExamDto)
        {
            var localMfc = await _mfcCornerRepository.GetLocalMfcAsync();
            if (string.IsNullOrWhiteSpace(createExamDto.Group))
            {
                if (string.IsNullOrWhiteSpace(localMfc.Group) ||
                    localMfc.Group.Equals(createExamDto.Group.ToString()))
                {
                    localMfc.Group = createExamDto.Group.ToString();
                    await _mfcCornerRepository.UpdateMfcAsync(localMfc);
                }
            }
        }

        public async Task SendStatusInfo(CreateExaminationDto createExaminationDto)
        {
            try
            {
                Console.WriteLine(" SendStatusInfo method started ");
                if (_sendStatusInfoSettings != null && !String.IsNullOrWhiteSpace(_sendStatusInfoSettings.BaseUrl))
                {
                    var url = _sendStatusInfoSettings.BaseUrl + "/status/video_server.php?" + "" +
                        "status=" + createExaminationDto.Data.Status + "&" +
                        "BPBIO=" + createExaminationDto.Data.Bpbio.ToString().ToLower() + "&" +
                        "PULSE=" + createExaminationDto.Data.Pulse.ToString().ToLower() + "&" +
                        "ANALYSER=" + createExaminationDto.Data.Analyzer.ToString().ToLower() + "&" +
                        "GAZ=" + createExaminationDto.Data.Gaz.ToString().ToLower() + "&" +
                        "BSM=" + createExaminationDto.Data.Bsm.ToString().ToLower();
                    Console.WriteLine($"url => {url} ");

                    var client = new RestClient(url);
                    client.Timeout = -1;
                    var request = new RestRequest(Method.GET);
                    IRestResponse response = await client.ExecuteAsync(request);
                    Console.WriteLine($"responce is successful => {response.IsSuccessful} ");
                    Console.WriteLine($"Responce status => {response.StatusCode} ");
                    if (!String.IsNullOrWhiteSpace(response.ErrorMessage))
                    {
                        Console.WriteLine($"Responce Error Message => {response.StatusCode} ");
                    }
                }
                Console.WriteLine(" SendStatusInfo method ended ");
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task SendEquipmentCondition(EquipmentConditionDto equipmentCondition)
        {
            var equipmentConditionSockets = _webSocketConnectionManager.GetAll()
                .Where(x => x.SocketType == _webSocketsSettings.SendCommandDeviceStatusPathBase).ToList();
            foreach (var equipmentConditionSocket in equipmentConditionSockets)
            {
                var responce = JsonConvert.SerializeObject(equipmentCondition);
                await _socketMessager.SendMessageAsync(equipmentConditionSocket.Socket, responce);
            }
        }

        private async Task RestartExamenation()
        {
            var mediacalExamination = await _medicalExaminationRepository.GetLatest();
            if (mediacalExamination != null)
            {
                mediacalExamination.IsCompleted = true;
                mediacalExamination.IsExaminationResultShowed = true;
                await _medicalExaminationRepository.SaveExaminationAsync(mediacalExamination);

            }
        }

        public async Task<ExaminationResponseDto> ProcessControlDeviceCommand(CreateExaminationDto createExaminationDto)
        {
            try
            {
                #region Check & execute external commands
                if (createExaminationDto.Data.Status.Equals("STARTED") ||
                    createExaminationDto.Data.Status.Equals("RESTARTED"))
                {
                    return new ExaminationResponseDto()
                    {
                        Data = "{}",
                        Status = ""
                    };
                }

                var command = await _commandDeviceRepository.GetFirstCommandAsync();

                if (command != null)
                {
                    await _commandDeviceRepository.DeleteCommandDeviceByGroupNameAsync(command.Id);
                    if (command.Command.ToLower().Equals("restart"))
                    {
                        await RestartExamenation();
                    }

                    return new ExaminationResponseDto()
                    {
                        Data = "{}",
                        Status = command.Command
                    };
                }
                #endregion

                var mediacalExamination = await _medicalExaminationRepository.GetLatest();
                if (mediacalExamination == null)
                {
                    #region Finishing Examination
                    var isExaminationResultShowed = await _medicalExaminationRepository.LastExaminationResultShowed();
                    if (string.IsNullOrWhiteSpace(createExaminationDto.Data.Status) && !isExaminationResultShowed ||
                         createExaminationDto.Data.Status == "ALL DONE" && !isExaminationResultShowed)
                    {
                        return new ExaminationResponseDto()
                        {
                            Data = "{}",
                            Status = "ALL DONE"
                        };
                    }

                    if (string.IsNullOrWhiteSpace(createExaminationDto.Data.Status)
                        || createExaminationDto.Data.Status == "ALL DONE" && isExaminationResultShowed)
                    {
                        return new ExaminationResponseDto()
                        {
                            Data = "{}",
                            Status = ""
                        };
                    }

                    return new ExaminationResponseDto()
                    {
                        Data = "{}",
                        Status = createExaminationDto.Data.Status.Equals("ALL DONE") ? "" : "ALL DONE"
                    };
                    #endregion
                }
                else
                {
                    //Записываем в обследование статусы приборов
                    mediacalExamination = UpdateExaminationEquipmentCondition(mediacalExamination, createExaminationDto);
                    //Обновляем стытусы приборов у уголка
                    await UpdateMfcCornerEquipmentCondition(createExaminationDto, mediacalExamination.MfcCornerId);

                    #region Special conditions
                    //Удаляем обследование и перезагружаем уголок МФЦ случае если список тестов пуст
                    if (mediacalExamination.TestNames == null || mediacalExamination.TestNames.Count == 0)
                    {
                        await _medicalExaminationRepository.DeleteMedicalExaminationById(mediacalExamination.Id);
                        return new ExaminationResponseDto()
                        {
                            Data = "{}",
                            Status = "RESTART"
                        };
                    }

                    //ПЕРЕЗАГРУЖАЕМ УГОЛОК МФЦ В СЛУЧАЕ ПОЛУЧЕНИЯ СОКЕТОМ КОМАНДЫ НА ДОСРОЧНОЕ ЗАВЕРШЕНИЕ
                    if (mediacalExamination.Examination.Data.CountDone == -10000)
                    {
                        mediacalExamination.Examination.Data.CountDone = 0;
                        await _medicalExaminationRepository.SaveExaminationAsync(mediacalExamination);
                        return new ExaminationResponseDto()
                        {
                            Data = "{}",
                            Status = "RESTART"
                        };
                    }
                    #endregion

                    #region Executing "PROGRESS" commands
                    if (createExaminationDto.Data.Status.Contains("PROGRESS"))
                    {
                        return new ExaminationResponseDto()
                        {
                            Data = createExaminationDto.Data.Status.Contains("ANALYZER")
                                && mediacalExamination.Examination.Data.Result.Bsm != null ?
                                GetAnalyzerStartData(mediacalExamination) : "{}",
                            Status = createExaminationDto.Data.Status
                        };
                    }
                    #endregion

                    #region Save information about completed tests
                    if (!createExaminationDto.Data.Status.Equals("ALL DONE")
                        && createExaminationDto.Data.Status.Contains("DONE"))
                    {
                        var testName = createExaminationDto.Data.Status.Replace(" DONE", "").Trim();
                        var FailedDeviceAttempt = mediacalExamination.FailedAttempts.FirstOrDefault(x => x.DeviceName.Equals(testName));

                        //проверяем было ли совершено 2 попытки перезапуска прибора
                        if (FailedDeviceAttempt == null ||
                            FailedDeviceAttempt.Count < 2)
                        {
                            if (string.IsNullOrWhiteSpace(createExaminationDto.Data.Result.ToString()))
                            {
                                #region Test completed with an error
                                mediacalExamination = UpdateFailedAttemptsState(mediacalExamination, testName);
                                await _medicalExaminationRepository.SaveExaminationAsync(mediacalExamination);

                                return new ExaminationResponseDto
                                {
                                    Data = createExaminationDto.Data.Status.Equals("ANALYZER DONE") ?
                                        GetAnalyzerStartData(mediacalExamination) : "{}",
                                    Status = createExaminationDto.Data.Status.Replace("DONE", "START")
                                };
                                #endregion
                            }
                            else
                            {
                                #region Test completed successfully
                                switch (createExaminationDto.Data.Status)
                                {
                                    case "PULSE DONE":
                                        mediacalExamination.Examination.Data.Pulse = createExaminationDto.Data.Pulse;
                                        mediacalExamination.Examination.Data.Result.Pulse = DecodePulseResult(createExaminationDto.Data.Result);
                                        mediacalExamination.Examination.Data.Result.Pulse.FullDeviceData = createExaminationDto.Data.Result.ToString();
                                        break;
                                    case "GAZ DONE":
                                        mediacalExamination.Examination.Data.Gaz = createExaminationDto.Data.Gaz;
                                        mediacalExamination.Examination.Data.Result.Gaz = CalculateGaz(createExaminationDto.Data.Result.ToString());
                                        mediacalExamination.Examination.Data.Result.Gaz.FullDeviceData = createExaminationDto.Data.Result.ToString();
                                        break;
                                    case "BPBIO DONE":
                                        //Нормальная строка с корректными результатами не может быть больше 70.
                                        //Проверка длинны строки - это необходимый костыль для понимания того,
                                        //что обследования прошли именно с уголка
                                        if (((string)createExaminationDto.Data.Result).Length > 70)
                                        {
                                            return new ExaminationResponseDto()
                                            {
                                                Data = "{}",
                                                Status = "BPBIO CLEAR"
                                            };
                                        }
                                        else
                                        {
                                            mediacalExamination.Examination.Data.Bpbio = createExaminationDto.Data.Bpbio;
                                            mediacalExamination.Examination.Data.Result.Bpbio = DecodeBpbioResult((string)createExaminationDto.Data.Result);
                                            mediacalExamination.Examination.Data.Result.Bpbio.FullDeviceData = createExaminationDto.Data.Result.ToString();
                                        }
                                        break;
                                    case "ANALYZER DONE":

                                        mediacalExamination.Examination.Data.Analyzer = createExaminationDto.Data.Analyzer;
                                        mediacalExamination.Examination.Data.Result.Analyzer = DecodeAnalyzerResult((string)createExaminationDto.Data.Result);
                                        mediacalExamination.Examination.Data.Result.Analyzer.FullDeviceData = createExaminationDto.Data.Result.ToString();
                                        break;
                                    case "BSM DONE":
                                        mediacalExamination.Examination.Data.Bsm = createExaminationDto.Data.Bsm;
                                        mediacalExamination.Examination.Data.Result.Bsm = DecodeBsmResult((string)createExaminationDto.Data.Result);
                                        mediacalExamination.Examination.Data.Result.Bsm.FullDeviceData = createExaminationDto.Data.Result.ToString();
                                        break;
                                }
                                #endregion
                            }
                        }
                        mediacalExamination.ComplitedTestIds.Add(testName);
                    }
                    #endregion

                    #region Start next test OR Finish examination

                    #region Delete tests for disconnected Device & find next test
                    var nonCompletedTests = mediacalExamination.TestNames.Except(mediacalExamination.ComplitedTestIds).ToList();
                    var nextTest = nonCompletedTests.FirstOrDefault();

                    var disconnectedDevices = GetDisconnectedDevices(mediacalExamination.Examination.Data);

                    if (nextTest != null && disconnectedDevices.Count > 0)
                    {
                        foreach (var device in disconnectedDevices)
                        {
                            var index = nonCompletedTests.IndexOf(device);
                            if (index > -1)
                            {
                                nonCompletedTests.RemoveAt(nonCompletedTests.IndexOf(device));
                                mediacalExamination.ComplitedTestIds.Add(device);
                            }
                        }
                        nextTest = nonCompletedTests.FirstOrDefault();
                    }
                    #endregion

                    ExaminationResponseDto response;
                    if (!nonCompletedTests.Any())
                    {
                        #region Finish examination
                        if (mediacalExamination.TestNames == null || mediacalExamination.TestNames.Count == 0)
                        {
                            await _medicalExaminationRepository.DeleteMedicalExaminationById(mediacalExamination.Id);
                        }
                        else
                        {
                            mediacalExamination.IsCompleted = true;
                            mediacalExamination.CompleteDate = DateTimeOffset.Now;
                        }

                        response = new ExaminationResponseDto()
                        {
                            Data = "{}",
                            Status = "ALL DONE"
                        };
                        #endregion
                    }
                    else
                    {
                        #region Start next or finish examination 
                        if (nextTest == "ANALYZER")
                        {
                            if (mediacalExamination.Examination.Data.Result.Bsm != null)
                            {
                                response = new ExaminationResponseDto()
                                {
                                    Data = GetAnalyzerStartData(mediacalExamination),
                                    Status = $"{nextTest.ToUpper()} START"
                                };
                            }
                            else
                            {
                                //TODO убрать после показа
                                mediacalExamination.IsCompleted = true;
                                mediacalExamination.CompleteDate = DateTimeOffset.Now;
                                response = new ExaminationResponseDto()
                                {
                                    Data = "",
                                    Status = "ALL DONE"
                                };
                            }
                        }
                        else
                        {
                            response = new ExaminationResponseDto()
                            {
                                Data = "{}",
                                Status = $"{nextTest.ToUpper()} START"
                            };
                        }
                        #endregion
                    }
                    #endregion

                    await _medicalExaminationRepository.SaveExaminationAsync(mediacalExamination);

                    return response;
                }
            }
            catch (Exception e)
            {
                string msg = e.Message;
                throw;
            }
        }

        private async Task UpdateMfcCornerEquipmentCondition(CreateExaminationDto createExaminationDto, string mfcCornerId)
        {
            var newEquipmentCondition = new EquipmentCondition
            {
                Gaz = createExaminationDto.Data.Gaz,
                Bpbio = createExaminationDto.Data.Bpbio,
                Pulse = createExaminationDto.Data.Pulse,
                Analyzer = createExaminationDto.Data.Analyzer,
                Bsm = createExaminationDto.Data.Bsm
            };
            await _mfcCornerRepository.UpdateMfcCornerEquipmentCondition(mfcCornerId, newEquipmentCondition);
        }

        private UserMedicalExamination UpdateExaminationEquipmentCondition(UserMedicalExamination mediacalExamination, CreateExaminationDto createExaminationDto)
        {
            mediacalExamination.Examination.Data.Gaz = createExaminationDto.Data.Gaz;
            mediacalExamination.Examination.Data.Bpbio = createExaminationDto.Data.Bpbio;
            mediacalExamination.Examination.Data.Pulse = createExaminationDto.Data.Pulse;
            mediacalExamination.Examination.Data.Analyzer = createExaminationDto.Data.Analyzer;
            mediacalExamination.Examination.Data.Bsm = createExaminationDto.Data.Bsm;

            mediacalExamination.Examination.Group = createExaminationDto.Group;
            mediacalExamination.Examination.Ip = createExaminationDto.Ip;

            return mediacalExamination;
        }

        private UserMedicalExamination UpdateFailedAttemptsState(UserMedicalExamination mediacalExamination, string testName)
        {
            var deviceAttempt = mediacalExamination.FailedAttempts.FirstOrDefault(x => x.DeviceName.Equals(testName));
            if (deviceAttempt == null || mediacalExamination.FailedAttempts.Count == 0)
            {
                mediacalExamination.FailedAttempts.Add(new FailedAttemptsCount
                {
                    DeviceName = testName,
                    Count = 1
                });
            }
            else
            {
                var attemptIndex = mediacalExamination.FailedAttempts.IndexOf(deviceAttempt);
                mediacalExamination.FailedAttempts[attemptIndex].Count++;
            }
            return mediacalExamination;
        }

        private object GetAnalyzerStartData(UserMedicalExamination mediacalExamination)
        {
            return new
            {
                gender = mediacalExamination.Male ? "M" : "F",
                height = mediacalExamination.Examination.Data.Result.Bsm.Height.ToString(),
                age = mediacalExamination.Age,
                id = mediacalExamination.PhoneNumber.Replace("+7", "")
            };
        }

        private List<string> GetDisconnectedDevices(Data devicesData)
        {
            List<string> devices = new List<string>();

            if (!devicesData.Analyzer)
            {
                devices.Add(nameof(devicesData.Analyzer).ToUpper());
            }
            if (!devicesData.Bpbio)
            {
                devices.Add(nameof(devicesData.Bpbio).ToUpper());
            }
            if (!devicesData.Bsm)
            {
                devices.Add(nameof(devicesData.Bsm).ToUpper());
            }
            if (!devicesData.Gaz)
            {
                devices.Add(nameof(devicesData.Gaz).ToUpper());
            }
            if (!devicesData.Pulse)
            {
                devices.Add(nameof(devicesData.Pulse).ToUpper());
            }

            return devices;
        }

        #region Decode & Calculate ExaminationResults
        private Gaz CalculateGaz(string gazExaminationResult)
        {
            double ppmco = 0;
            double cohb = 0;

            if (double.TryParse(gazExaminationResult, out ppmco))
            {
                cohb = 0.4 + ppmco / 7;
            }

            return new Gaz
            {
                Cohb = cohb.ToString(),
                Ppmco = ppmco
            };
        }

        private Bpbio DecodeBpbioResult(string result)
        {
            var systolicResult = double.TryParse(result.Substring(result.IndexOf("S") + 1, 3), out double systolic);
            var diastolicResult = double.TryParse(result.Substring(result.IndexOf("D") + 1, 3), out double diastolic);
            var pulseResult = double.TryParse(result.Substring(result.IndexOf("P") + 1, 3), out double pulse);

            return new Bpbio
            {
                Systolic = systolicResult ? systolic : 0,
                Diastolic = diastolicResult ? diastolic.ToString() : "",
                Pulse = pulseResult ? pulse : 0
            };
        }

        private Analyzer DecodeAnalyzerResult(string result)
        {
            var resultArray = result.Split('');
            resultArray[0] = resultArray[0].Replace("d", "");

            var Bmi = "";
            if (resultArray.Length > 22)
            {
                Bmi = resultArray[22];
            }
            double Hips_Circ = 0;
            if (resultArray.Length > 232)
            {
                double.TryParse(resultArray[232], out Hips_Circ);
            }
            var Waist_Circ = "";
            if (resultArray.Length > 232)
            {
                Waist_Circ = resultArray[233];
            }

            var Whr = resultArray[24];
            if (resultArray.Length > 24)
            {
                Whr = resultArray[24];
            }

            double Wt = 0;
            if (resultArray.Length > 5)
            {
                double.TryParse(resultArray[5], out Wt);
            }

            return new Analyzer
            {
                Bmi = Bmi,
                Hips_Circ = Hips_Circ,
                Waist_Circ = Waist_Circ,
                Whr = Whr,
                Wt = Wt
            };
        }

        private Bsm DecodeBsmResult(string result)
        {
            var replacedResult = Regex.Replace(result, @"[\x00-\x1F\x7F]", "");
            double height = 0;
            double weight = 0;
            int bmi = 0;
            if (double.TryParse(replacedResult.Substring(3, 4), out height))
            {
                height = height / 10;
            }
            if (replacedResult.Length > 14)
            {
                if (double.TryParse(replacedResult.Substring(7, 3), out weight))
                {
                    weight = weight / 10;
                }
            }
            else
            {
                if (double.TryParse(replacedResult.Substring(7, 3), out weight))
                {
                    weight = weight / 10;
                }
            }
            bmi = (int)Math.Round(weight /
                (height / 100 * height / 100));
            return new Bsm
            {
                Bmi = bmi,
                Height = height,
                Weight = weight
            };
        }

        private Pulses DecodePulseResult(object result)
        {
            var pulseString = ((Newtonsoft.Json.Linq.JObject)result).ToString();
            var pulse = JsonConvert.DeserializeObject<Pulses>(pulseString);
            return pulse;
        }
        #endregion
        public async Task<OperationResult> FinishAllExaminations()
        {
            try
            {
                await _medicalExaminationRepository.FinishAllExaminations();
                return OperationResult.Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

