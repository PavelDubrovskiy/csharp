using MassTransit;
using MassTransit.RabbitMqTransport;
using Mfc.Health.Corner.Application.Common.Sockets;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Mfc.Health.Corner.RabbitMqMessager.Models;
using Mfc.Health.Corner.RabbitMqMessager.Receiver.Implementation;
using Mfc.Health.Corner.RabbitMqMessager.ReceiveServices.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.RabbitMqMessager.ReceiveServices.Implementation
{
    class MfcCorenerStatisticPerDayReceiveService : AbstractCommonReceiveService, IMfcCorenerStatisticPerDayReceiveService
    {
        private readonly IMfcCorenerStatisticPerDayRepository _mfcCorenerStatisticPerDayRepository;
        private readonly IDashBordService _dashBordService;
        private readonly IConnectionManager _webSocketConnectionManager;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserManagementRepository _userManagementRepository;
        private readonly IHeadOfMfcRepository _headOfMfcRepository;
        private readonly IHeadOfDivisionRepository _headOfDivisionRepository;
        private readonly IMfcCornerRepository _mfcCornerRepository;
        private readonly ISocketMessager _socketMessager;
        private readonly WebSocketsSettings _webSocketsSettings;

        public MfcCorenerStatisticPerDayReceiveService(IOptions<RammitMqSettings> rammitMqSettingsOptions,
            IMfcCorenerStatisticPerDayRepository mfcCorenerStatisticPerDayRepository,
            IDashBordService dashBordService,
            IConnectionManager webSocketConnectionManager,
            IUserRoleRepository userRoleRepository,
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUserManagementRepository userManagementRepository,
            IHeadOfMfcRepository headOfMfcRepository,
            IOptions<WebSocketsSettings> webSocketsSettingsOptions,
            ISocketMessager socketMessager,
            IHeadOfDivisionRepository headOfDivisionRepository,
            IMfcCornerRepository mfcCornerRepository) : base(rammitMqSettingsOptions)
        {
            _mfcCorenerStatisticPerDayRepository = mfcCorenerStatisticPerDayRepository;
            _dashBordService = dashBordService;
            _webSocketConnectionManager = webSocketConnectionManager;
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _roleRepository = roleRepository;
            _userManagementRepository = userManagementRepository;
            _headOfMfcRepository = headOfMfcRepository;
            _headOfDivisionRepository = headOfDivisionRepository;
            _socketMessager = socketMessager;
            _mfcCornerRepository = mfcCornerRepository;
            _webSocketsSettings = webSocketsSettingsOptions.Value;
        }

        protected override string QueueName => nameof(MfcCorenerStatisticPerDay);

        protected override void ConfigureEndpoint(IRabbitMqReceiveEndpointConfigurator ep)
        {
            ep.Handler<MfcCorenerStatisticPerDay>(async context =>
            {
                try
                {
                    //TODO - add logs
                    var statisticPerDay = context.Message;
                    await SaveReceivedInfo(statisticPerDay);
                }
                catch (Exception ex)
                {
                    //TODO - add logs
                    var msg = ex.Message;
                    throw;
                }
            });
        }

        private async Task SaveReceivedInfo(MfcCorenerStatisticPerDay statisticPerDay)
        {
            try
            {
                var localMfcCorenerStatisticPerDay = await _mfcCorenerStatisticPerDayRepository.GetMfcCorenerStatisticPerDayById(statisticPerDay.Id);
                if (localMfcCorenerStatisticPerDay == null)
                {
                    await _mfcCorenerStatisticPerDayRepository.CreateStatistic(statisticPerDay);
                    localMfcCorenerStatisticPerDay = statisticPerDay;
                }
                else
                {
                    localMfcCorenerStatisticPerDay = await _mfcCorenerStatisticPerDayRepository.UpdateStatistic(statisticPerDay);
                }

                if (localMfcCorenerStatisticPerDay.Date >= DateTime.Today.AddDays(-1))
                {
                    var circleDiagramSockets = _webSocketConnectionManager.GetAll()
                        .Where(x => x.SocketType == _webSocketsSettings.CircleDiagramUpdate &&
                        !string.IsNullOrWhiteSpace(x.Jwt)).ToList();
                    foreach (var circleDiagramSocket in circleDiagramSockets)
                    {
                        await VereficateCircleSocketAndSendData(circleDiagramSocket, statisticPerDay);
                    }

                    var MfcPopularityDataUpdateSockets = _webSocketConnectionManager.GetAll()
                        .Where(x => x.SocketType == _webSocketsSettings.MfcPopularityDataUpdate &&
                        !string.IsNullOrWhiteSpace(x.Jwt)).ToList();
                    foreach (var mfcPopularityDataUpdateSocket in MfcPopularityDataUpdateSockets)
                    {
                        await VereficateMfcPopularityDataUpdateSocketSocketAndSendData(mfcPopularityDataUpdateSocket, statisticPerDay);
                    }

                    var ResearchDynamicsUpdateSockets = _webSocketConnectionManager.GetAll()
                        .Where(x => x.SocketType == _webSocketsSettings.ResearchDynamicsUpdate &&
                        !string.IsNullOrWhiteSpace(x.Jwt)).ToList();
                    foreach (var ResearchDynamicsUpdateSocket in ResearchDynamicsUpdateSockets)
                    {
                        await VereficateResearchDynamicsUpdateSocketsAndSendData(ResearchDynamicsUpdateSocket, statisticPerDay);
                    }

                    var StockDiagramByMedDeviceUpdateSockets = _webSocketConnectionManager.GetAll()
                        .Where(x => x.SocketType == _webSocketsSettings.StockDiagramByMedDeviceUpdate &&
                        !string.IsNullOrWhiteSpace(x.Jwt)).ToList();
                    foreach (var stockDiagramByMedDeviceUpdateSocket in StockDiagramByMedDeviceUpdateSockets)
                    {
                        await VereficateStockDiagramByMedDeviceUpdateSocketsAndSendData(stockDiagramByMedDeviceUpdateSocket, statisticPerDay);
                    }
                }
            }
            catch//(Exception ex)
            {
                throw;
            }
        }

        private async Task VereficateStockDiagramByMedDeviceUpdateSocketsAndSendData(WebSocketConnection webSocket,
           MfcCorenerStatisticPerDay statisticPerDay)
        {
            var requestUserId = GetUserIdFromJwt(webSocket.Jwt);
            User requestUser = null;

            if (!string.IsNullOrWhiteSpace(requestUserId))
            {
                requestUser = await _userRepository.GetUserByIdAsync(requestUserId);
                if (requestUser != null)
                {
                    var AdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                   new List<string> { "Admin" })).FirstOrDefault().Id;
                    var SuperAdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "SuperAdmin" })).FirstOrDefault().Id;
                    var headOfDivisionRoleId =
                       (await _roleRepository.GetRolesByRoleNamesAsync(
                           new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;
                    var HeadOfMfcRoleId =
                        (await _roleRepository.GetRolesByRoleNamesAsync(
                            new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;
                    var UserManagementRoleId =
                        (await _roleRepository.GetRolesByRoleNamesAsync(
                            new List<string> { "UserManagement" })).FirstOrDefault().Id;

                    var userRoles = await _userRoleRepository.GetUserRolesByUserIdsAsync(
                        new List<string> { requestUserId });
                    if (userRoles.Where(x => x.RoleId.Equals(AdminId)).Count() > 0 ||
                        userRoles.Where(x => x.RoleId.Equals(SuperAdminId)).Count() > 0)
                    {
                        var result = await _dashBordService.UpdateStockDiagramByMedDevice(webSocket.Jwt);
                        var responce = JsonConvert.SerializeObject(result);
                        await _socketMessager.SendMessageAsync(webSocket.Socket, responce);
                    }
                    else if (userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).Count() > 0)
                    {
                        var userRole = userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).First();
                        var headOfDivision = await _headOfDivisionRepository.GetHeadOfDivisionByUserRoleId(userRole.Id);
                        var divisionMfcCorners = await _mfcCornerRepository.GetDivisionMfcCornersAsync(headOfDivision.DistrictId);
                        if (divisionMfcCorners.Where(x => x.Id == statisticPerDay.MfcCornerId).Count() > 0)
                        {
                            var result = await _dashBordService.UpdateStockDiagramByMedDevice(webSocket.Jwt);
                            var responce = JsonConvert.SerializeObject(result);
                            await _socketMessager.SendMessageAsync(webSocket.Socket, responce);
                        }

                    }
                    else if (userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).Count() > 0)
                    {
                        var userRole = userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).First();
                        var HeadOfMfc = await _headOfMfcRepository.GetHeadOfMfcByUserRoleId(userRole.Id);
                        if (HeadOfMfc.Id == statisticPerDay.MfcCornerId)
                        {
                            var result = await _dashBordService.UpdateStockDiagramByMedDevice(webSocket.Jwt);
                            var responce = JsonConvert.SerializeObject(result);
                            await _socketMessager.SendMessageAsync(webSocket.Socket, responce);
                        }
                    }
                    else if (userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).Count() > 0)
                    {
                        var userRole = userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).First();
                        var userManagement = await _userManagementRepository.GetUserManagementUserRoleId(userRole.Id);
                        if (userManagement.Id == statisticPerDay.MfcCornerId)
                        {
                            var result = await _dashBordService.UpdateStockDiagramByMedDevice(webSocket.Jwt);
                            var responce = JsonConvert.SerializeObject(result);
                            await _socketMessager.SendMessageAsync(webSocket.Socket, responce);
                        }
                    }
                }
            }
        }


        private async Task VereficateResearchDynamicsUpdateSocketsAndSendData(WebSocketConnection webSocket,
            MfcCorenerStatisticPerDay statisticPerDay)
        {
            var requestUserId = GetUserIdFromJwt(webSocket.Jwt);
            User requestUser = null;

            if (!string.IsNullOrWhiteSpace(requestUserId))
            {
                requestUser = await _userRepository.GetUserByIdAsync(requestUserId);
                if (requestUser != null)
                {
                    var AdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                   new List<string> { "Admin" })).FirstOrDefault().Id;
                    var SuperAdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "SuperAdmin" })).FirstOrDefault().Id;
                    var headOfDivisionRoleId =
                       (await _roleRepository.GetRolesByRoleNamesAsync(
                           new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;
                    var HeadOfMfcRoleId =
                        (await _roleRepository.GetRolesByRoleNamesAsync(
                            new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;
                    var UserManagementRoleId =
                        (await _roleRepository.GetRolesByRoleNamesAsync(
                            new List<string> { "UserManagement" })).FirstOrDefault().Id;

                    var userRoles = await _userRoleRepository.GetUserRolesByUserIdsAsync(
                        new List<string> { requestUserId });
                    if (userRoles.Where(x => x.RoleId.Equals(AdminId)).Count() > 0 ||
                        userRoles.Where(x => x.RoleId.Equals(SuperAdminId)).Count() > 0)
                    {
                        var result = await _dashBordService.UpdateResearchDynamics(webSocket.Jwt);
                        var responce = JsonConvert.SerializeObject(result);
                        await _socketMessager.SendMessageAsync(webSocket.Socket, responce);
                    }
                    else if (userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).Count() > 0)
                    {
                        var userRole = userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).First();
                        var headOfDivision = await _headOfDivisionRepository.GetHeadOfDivisionByUserRoleId(userRole.Id);
                        var divisionMfcCorners = await _mfcCornerRepository.GetDivisionMfcCornersAsync(headOfDivision.DistrictId);
                        if (divisionMfcCorners.Where(x => x.Id == statisticPerDay.MfcCornerId).Count() > 0)
                        {
                            var result = await _dashBordService.UpdateResearchDynamics(webSocket.Jwt);
                            var responce = JsonConvert.SerializeObject(result);
                            await _socketMessager.SendMessageAsync(webSocket.Socket, responce);
                        }

                    }
                    else if (userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).Count() > 0)
                    {
                        var userRole = userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).First();
                        var HeadOfMfc = await _headOfMfcRepository.GetHeadOfMfcByUserRoleId(userRole.Id);
                        if (HeadOfMfc.Id == statisticPerDay.MfcCornerId)
                        {
                            var result = await _dashBordService.UpdateResearchDynamics(webSocket.Jwt);
                            var responce = JsonConvert.SerializeObject(result);
                            await _socketMessager.SendMessageAsync(webSocket.Socket, responce);
                        }
                    }
                    else if (userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).Count() > 0)
                    {
                        var userRole = userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).First();
                        var userManagement = await _userManagementRepository.GetUserManagementUserRoleId(userRole.Id);
                        if (userManagement.Id == statisticPerDay.MfcCornerId)
                        {
                            var result = await _dashBordService.UpdateResearchDynamics(webSocket.Jwt);
                            var responce = JsonConvert.SerializeObject(result);
                            await _socketMessager.SendMessageAsync(webSocket.Socket, responce);
                        }

                    }
                }
            }
        }

        private async Task VereficateCircleSocketAndSendData(WebSocketConnection webSocket, MfcCorenerStatisticPerDay statisticPerDay)
        {
            var requestUserId = GetUserIdFromJwt(webSocket.Jwt);
            User requestUser = null;

            if (!string.IsNullOrWhiteSpace(requestUserId))
            {
                requestUser = await _userRepository.GetUserByIdAsync(requestUserId);
                if (requestUser != null)
                {
                    var AdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                   new List<string> { "Admin" })).FirstOrDefault().Id;
                    var SuperAdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "SuperAdmin" })).FirstOrDefault().Id;
                    var headOfDivisionRoleId =
                       (await _roleRepository.GetRolesByRoleNamesAsync(
                           new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;
                    var HeadOfMfcRoleId =
                        (await _roleRepository.GetRolesByRoleNamesAsync(
                            new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;
                    var UserManagementRoleId =
                        (await _roleRepository.GetRolesByRoleNamesAsync(
                            new List<string> { "UserManagement" })).FirstOrDefault().Id;

                    var userRoles = await _userRoleRepository.GetUserRolesByUserIdsAsync(
                        new List<string> { requestUserId });
                    if (userRoles.Where(x => x.RoleId.Equals(AdminId)).Count() > 0 ||
                        userRoles.Where(x => x.RoleId.Equals(SuperAdminId)).Count() > 0)
                    {
                        var result = await _dashBordService.GetCircleDiagramsData(webSocket.Jwt);
                        var responce = JsonConvert.SerializeObject(result);
                        await _socketMessager.SendMessageAsync(webSocket.Socket, responce);
                    }
                    else if (userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).Count() > 0)
                    {
                        var userRole = userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).First();
                        var headOfDivision = await _headOfDivisionRepository.GetHeadOfDivisionByUserRoleId(userRole.Id);
                        var divisionMfcCorners = await _mfcCornerRepository.GetDivisionMfcCornersAsync(headOfDivision.DistrictId);
                        if (divisionMfcCorners.Where(x => x.Id == statisticPerDay.MfcCornerId).Count() > 0)
                        {
                            var result = await _dashBordService.GetCircleDiagramsData(webSocket.Jwt);
                            var responce = JsonConvert.SerializeObject(result);
                            await _socketMessager.SendMessageAsync(webSocket.Socket, responce);
                        }

                    }
                    else if (userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).Count() > 0)
                    {
                        var userRole = userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).First();
                        var HeadOfMfc = await _headOfMfcRepository.GetHeadOfMfcByUserRoleId(userRole.Id);
                        if (HeadOfMfc.Id == statisticPerDay.MfcCornerId)
                        {
                            var result = await _dashBordService.GetCircleDiagramsData(webSocket.Jwt);
                            var responce = JsonConvert.SerializeObject(result);
                            await _socketMessager.SendMessageAsync(webSocket.Socket, responce);
                        }
                    }
                    else if (userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).Count() > 0)
                    {
                        var userRole = userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).First();
                        var userManagement = await _userManagementRepository.GetUserManagementUserRoleId(userRole.Id);
                        if (userManagement.Id == statisticPerDay.MfcCornerId)
                        {
                            var result = await _dashBordService.GetCircleDiagramsData(webSocket.Jwt);
                            var responce = JsonConvert.SerializeObject(result);
                            await _socketMessager.SendMessageAsync(webSocket.Socket, responce);
                        }

                    }
                }
            }
        }

        private async Task VereficateMfcPopularityDataUpdateSocketSocketAndSendData(WebSocketConnection webSocket, MfcCorenerStatisticPerDay statisticPerDay)
        {
            var requestUserId = GetUserIdFromJwt(webSocket.Jwt);
            User requestUser = null;

            if (!string.IsNullOrWhiteSpace(requestUserId))
            {
                requestUser = await _userRepository.GetUserByIdAsync(requestUserId);
                if (requestUser != null)
                {
                    var AdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                   new List<string> { "Admin" })).FirstOrDefault().Id;
                    var SuperAdminId = (await _roleRepository.GetRolesByRoleNamesAsync(
                        new List<string> { "SuperAdmin" })).FirstOrDefault().Id;
                    var headOfDivisionRoleId =
                       (await _roleRepository.GetRolesByRoleNamesAsync(
                           new List<string> { "HeadOfTheMfcDivision" })).FirstOrDefault().Id;
                    var HeadOfMfcRoleId =
                        (await _roleRepository.GetRolesByRoleNamesAsync(
                            new List<string> { "HeadOfMfc" })).FirstOrDefault().Id;
                    var UserManagementRoleId =
                        (await _roleRepository.GetRolesByRoleNamesAsync(
                            new List<string> { "UserManagement" })).FirstOrDefault().Id;

                    var userRoles = await _userRoleRepository.GetUserRolesByUserIdsAsync(
                        new List<string> { requestUserId });
                    if (userRoles.Where(x => x.RoleId.Equals(AdminId)).Count() > 0 ||
                        userRoles.Where(x => x.RoleId.Equals(SuperAdminId)).Count() > 0)
                    {
                        var result = await _dashBordService.GetMfcPopularityDataDto(webSocket.Jwt);
                        var responce = JsonConvert.SerializeObject(result);
                        await _socketMessager.SendMessageAsync(webSocket.Socket, responce);
                    }
                    else if (userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).Count() > 0)
                    {
                        var userRole = userRoles.Where(x => x.RoleId.Equals(headOfDivisionRoleId)).First();
                        var headOfDivision = await _headOfDivisionRepository.GetHeadOfDivisionByUserRoleId(userRole.Id);
                        var divisionMfcCorners = await _mfcCornerRepository.GetDivisionMfcCornersAsync(headOfDivision.DistrictId);
                        if (divisionMfcCorners.Where(x => x.Id == statisticPerDay.MfcCornerId).Count() > 0)
                        {
                            var result = await _dashBordService.GetMfcPopularityDataDto(webSocket.Jwt);
                            var responce = JsonConvert.SerializeObject(result);
                            await _socketMessager.SendMessageAsync(webSocket.Socket, responce);
                        }

                    }
                    else if (userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).Count() > 0)
                    {
                        var userRole = userRoles.Where(x => x.RoleId.Equals(HeadOfMfcRoleId)).First();
                        var HeadOfMfc = await _headOfMfcRepository.GetHeadOfMfcByUserRoleId(userRole.Id);
                        if (HeadOfMfc.Id == statisticPerDay.MfcCornerId)
                        {
                            var result = await _dashBordService.GetMfcPopularityDataDto(webSocket.Jwt);
                            var responce = JsonConvert.SerializeObject(result);
                            await _socketMessager.SendMessageAsync(webSocket.Socket, responce);
                        }
                    }
                    else if (userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).Count() > 0)
                    {
                        var userRole = userRoles.Where(x => x.RoleId.Equals(UserManagementRoleId)).First();
                        var userManagement = await _userManagementRepository.GetUserManagementUserRoleId(userRole.Id);
                        if (userManagement.Id == statisticPerDay.MfcCornerId)
                        {
                            var result = await _dashBordService.GetMfcPopularityDataDto(webSocket.Jwt);
                            var responce = JsonConvert.SerializeObject(result);
                            await _socketMessager.SendMessageAsync(webSocket.Socket, responce);
                        }
                    }
                }
            }
        }

        private string GetUserIdFromJwt(string jwtString)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(jwtString);
                var tokenS = jsonToken as JwtSecurityToken;

                var id = tokenS.Claims.
                    Where(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid").
                    Select(claim => claim.Value).FirstOrDefault();
                return id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
