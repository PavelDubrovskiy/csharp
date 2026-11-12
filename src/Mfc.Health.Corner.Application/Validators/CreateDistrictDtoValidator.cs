using FluentValidation;
using Mfc.Health.Corner.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Validators
{
    public class CreateDistrictDtoValidator :AbstractValidator<CreateDistrictDto>
    {
        public CreateDistrictDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
