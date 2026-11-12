using FluentValidation;
using Mfc.Health.Corner.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mfc.Health.Corner.Application.Validators
{
    public class DistrictDtoValidator : AbstractValidator<DistrictDto>
    {
        public DistrictDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
