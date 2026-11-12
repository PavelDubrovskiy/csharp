using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Application.Validators;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using Mfc.Health.Corner.RabbitMqMessager.Sender.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class MfcCornerService : IMfcCornerService
    {
        private readonly IMfcCornerRepository _mfcCornerRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IMassTransitCommonSender _massTransitCommonSender;

        public MfcCornerService(
            IMfcCornerRepository mfcCornerRepository,
            IRoleRepository roleRepository,
            IDistrictRepository districtRepository,
            IMassTransitCommonSender massTransitCommonSender)
        {
            _mfcCornerRepository = mfcCornerRepository;
            _roleRepository = roleRepository;
            _districtRepository = districtRepository;
            _massTransitCommonSender = massTransitCommonSender;
        }

        public async Task<PagedCollection<MfcCornerDto>> GetAllMfcAsync(int pageNumber, int pageSize, string name = null)
        {
            var mfcCorners = await _mfcCornerRepository.GetAllMfcAsync(pageNumber, pageSize, name);

            var mfcCornerDtos = mfcCorners.Items.Select(mfc => new MfcCornerDto()
            {
                Id = mfc.Id,
                Name = mfc.Name,
                Address = mfc.Address,
                TelegtamChatId = mfc.TelegtamChatId,
                Latitude = mfc.Latitude,
                Longitude = mfc.Longitude,
                CreatedAt = mfc.CreatedAt,
                District = new DistrictDto
                {
                    Id = mfc.DistrictId
                },
                Group = mfc.Group,
                Ip = mfc.Ip,
                Port = mfc.Port

            }).OrderByDescending(x => x.CreatedAt).ToList();

            foreach(var mfcCornerDto in mfcCornerDtos)
            {
                var discrict = await _districtRepository.GetDistrictAsync(mfcCornerDto.District.Id);
                mfcCornerDto.District.Name = discrict.Name;
            }

            return new PagedCollection<MfcCornerDto> { Total = mfcCorners.Total, Items = mfcCornerDtos };
        }

        public async Task<List<MfcCornerDto>> GetAllMfcByDistrictIdAsync(string districtId)
        {
            var mfcCorners = await _mfcCornerRepository.GetAllMfcByDistrictIdAsync(districtId);

            var mfcCornerDtos = mfcCorners.Select(mfc => new MfcCornerDto()
            {
                Id = mfc.Id,
                Name = mfc.Name,
                Address = mfc.Address,
                TelegtamChatId = mfc.TelegtamChatId,
                Latitude = mfc.Latitude,
                Longitude = mfc.Longitude,
                CreatedAt = mfc.CreatedAt,
                District = new DistrictDto
                {
                    Id = mfc.DistrictId
                },
                Group = mfc.Group,
                Ip = mfc.Ip,
                Port = mfc.Port

            }).OrderByDescending(x => x.CreatedAt).ToList();

            foreach (var mfcCornerDto in mfcCornerDtos)
            {
                var discrict = await _districtRepository.GetDistrictAsync(mfcCornerDto.District.Id);
                mfcCornerDto.District.Name = discrict.Name;
            }

            return mfcCornerDtos;
        }

        public async Task<OperationResult<string>> CreateMfcAsync(CreateMfcCornerDto createMfcDto)
        {

            var validator = new CreateMfcCornerDtoValidator();

            var validationResult = validator.Validate(createMfcDto);

            if (!validationResult.IsValid)
            {
                return OperationResult.Error<string>(validationResult.ToString(), OperationCode.ValidationError);
            }

            var district = await _districtRepository.GetDistrictAsync(createMfcDto.DistrictId);

            if (district == null)
            {
                return OperationResult.Error<string>($"District with id {createMfcDto.DistrictId} not found",
                    OperationCode.ValidationError);
            }

            var mfcCorner = new MfcCorner
            {
                Name = createMfcDto.Name,
                TelegtamChatId = createMfcDto.TelegtamChatId,
                Address = createMfcDto.Address,
                Latitude = createMfcDto.Latitude,
                Longitude = createMfcDto.Longitude,
                CreatedAt = DateTime.UtcNow,
                DistrictId = createMfcDto.DistrictId,
                EquipmentCondition = new EquipmentCondition
                {
                    Analyzer = false,
                    Bpbio = false,
                    Bsm = false,
                    Gaz = false,
                    Pulse = false
                },
                Group = createMfcDto.Group,
                Ip = createMfcDto.Ip,
                Port = createMfcDto.Port
            };

            await _mfcCornerRepository.CreateMfcAsync(mfcCorner);
            var districts = await _districtRepository.GetAllDistrictsAsync(null, null, "");
            var mfcCornerInitializationDto = new MfcCornerInitialization
            {
                LocalMfcCorner = mfcCorner,
                Districts = districts.Items
            };
            await _massTransitCommonSender.SendEntity(mfcCornerInitializationDto);
            
            //var role = new Role
            //{
            //    Name = createMfcDto.Name
            //};
            //await _roleRepository.CreateRoleAsync(role);

            return OperationResult<string>.Ok(mfcCorner.Id);
        }

        public async Task<OperationResult> UpdateMfcAsync(UpdateMfcDto updateMfcDto)
        {
            var validator = new UpdateMfcDtoValidator();

            var validationResult = validator.Validate(updateMfcDto);

            if (!validationResult.IsValid)
            {
                return OperationResult.Error(validationResult.ToString(), OperationCode.ValidationError);
            }

            var mfcCurrentState = await _mfcCornerRepository.GetMfcAsync(updateMfcDto.Id);
            if (mfcCurrentState==null)
            {
                return OperationResult.Error($"MFC with id = {updateMfcDto.Id} not exist", OperationCode.EntityWasNotFound);
            }

            var mfcCorner = new MfcCorner
            {
                Id = updateMfcDto.Id,
                Name = updateMfcDto.Name,
                TelegtamChatId = updateMfcDto.TelegtamChatId,
                Address = updateMfcDto.Address,
                Latitude = updateMfcDto.Latitude,
                DistrictId = updateMfcDto.DistrictId,
                EquipmentCondition = mfcCurrentState.EquipmentCondition,
                DeletedAt = mfcCurrentState.DeletedAt,
                CreatedAt = mfcCurrentState.CreatedAt,
                Longitude = updateMfcDto.Longitude,
                Group = updateMfcDto.Group,
                Ip = updateMfcDto.Ip,
                Port = updateMfcDto.Port
            };

            await _mfcCornerRepository.UpdateMfcAsync(mfcCorner);
            await _massTransitCommonSender.SendEntity(mfcCorner);

            var role = new Role
            {
                Id = updateMfcDto.Id,
                Name = updateMfcDto.Name
            };

            await _roleRepository.UpdateRoleAsync(role);

            return OperationResult.Ok();
        }

        public async Task<OperationResult> Reinitialize(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return OperationResult.Error("Id can not be null or empty", OperationCode.ValidationError);
            }
            var mfcCorner = await _mfcCornerRepository.GetMfcAsync(id);
            if (mfcCorner != null)
            {
                var districts = await _districtRepository.GetAllDistrictsAsync(null, null, "");
                var mfcCornerInitializationDto = new MfcCornerInitialization
                {
                    LocalMfcCorner = mfcCorner,
                    Districts = districts.Items
                };
                await _massTransitCommonSender.SendEntity(mfcCornerInitializationDto);
            }
            else
            {
                return OperationResult.Error("Mfc not found", OperationCode.EntityWasNotFound);
            }

            return OperationResult.Ok();
        }

        public async Task<OperationResult> DeleteMfcByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return OperationResult.Error("Id can not be null or empty", OperationCode.ValidationError);
            }
            var currentMfc = await _mfcCornerRepository.GetMfcAsync(id);
            if(currentMfc != null)
            {
                await _mfcCornerRepository.DeleteMfcCornerByIdAsync(id);
                await _massTransitCommonSender.SendEntity(currentMfc);
            }
            else
            {
                return OperationResult.Error("Mfc not found", OperationCode.EntityWasNotFound);
            }

            return OperationResult.Ok();
        }
    }
}
