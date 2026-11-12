using Mfc.Health.Corner.Application.Common;
using Mfc.Health.Corner.Application.Dto;
using Mfc.Health.Corner.Application.Services.Interfaces;
using Mfc.Health.Corner.Application.Validators;
using Mfc.Health.Corner.Common;
using Mfc.Health.Corner.Domain.Models;
using Mfc.Health.Corner.Persistence.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Services.Implementation
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;
        public DistrictService(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public async Task<OperationResult<string>> CreateDistricAsync(CreateDistrictDto createDistrictDto)
        {
            var validator = new CreateDistrictDtoValidator();

            var validationResult = validator.Validate(createDistrictDto);

            if (!validationResult.IsValid)
            {
                return OperationResult.Error<string>(validationResult.ToString(), OperationCode.ValidationError);
            }

            var district = new District
            {
                Name = createDistrictDto.Name
            };
            
           await _districtRepository.CreateDistrictAsync(district);
            return OperationResult<string>.Ok(district.Id);
        }

        public async Task<OperationResult> DeleteDistrictByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return OperationResult.Error("Id can not be null or empty", OperationCode.ValidationError);
            }
             var deleteResult = await _districtRepository.DeleteDistrictByIdAsync(id);
            if(!deleteResult)
            {
                return OperationResult.Error("District not found", OperationCode.EntityWasNotFound);
            }
            return OperationResult.Ok();

        }

        public async Task<OperationResult<PagedCollection<DistrictDto>>> GetAllDistrictsAsync(int? pageNumber, int? pageSize, string name)
        {
            var districts =  await _districtRepository.GetAllDistrictsAsync(pageNumber, pageSize, name);
            var districtsDtos = districts.Items.Select(district => new DistrictDto()
            {
                Id = district.Id,
                Name = district.Name,
            }).ToList();


            return OperationResult<PagedCollection<DistrictDto>>.Ok(new PagedCollection<DistrictDto> { Total = districts.Total, Items = districtsDtos });
        }

        public async Task<OperationResult<DistrictDto>> GetDistrictByIdAsync(string id)
        {
            var district = await _districtRepository.GetDistrictAsync(id);
            if(district == null)
            {
                return OperationResult.Error<DistrictDto>("District not found", OperationCode.EntityWasNotFound);
            }
            var districtDto = new DistrictDto
            {
                Id = district.Id,
                Name = district.Name
            };
            return OperationResult<DistrictDto>.Ok(districtDto);
        }

        public async Task<OperationResult> UpdateDistrictAsync(DistrictDto districtDto)
        {
            var validator = new DistrictDtoValidator();
            var validationResult = validator.Validate(districtDto);

            if (!validationResult.IsValid)
            {
                return OperationResult.Error(validationResult.ToString(), OperationCode.ValidationError);
            }
            var district = new District
            {
                Id = districtDto.Id,
                Name = districtDto.Name
            };
            await _districtRepository.UpdateDistrictAsync(district);
            return OperationResult.Ok();
        }
    }
}
