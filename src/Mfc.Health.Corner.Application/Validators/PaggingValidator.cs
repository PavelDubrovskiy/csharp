using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Mfc.Health.Corner.Application.Dto;

namespace Mfc.Health.Corner.Application.Validators
{
    public class PaggingValidator : AbstractValidator<PaggingDto>
    {
        public PaggingValidator()
        {
            RuleFor(x => x.PageNumber).GreaterThan(0).WithMessage("Page can not be null");
            RuleFor(x => x.PageSize).GreaterThan(0).WithMessage("Page size can not be null");
        }
    }
}
