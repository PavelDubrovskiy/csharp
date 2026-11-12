using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Mfc.Health.Corner.Application.Dto;

namespace Mfc.Health.Corner.Application.Validators
{
    class DatesIntervalValidator : AbstractValidator<DatesIntervalDto>
    {
        public DatesIntervalValidator()
        {
            RuleFor(x => x).Must(x => x.StartDate <= x.EndDate).
                WithMessage("The start date cannot be greater than the end date");
            RuleFor(x => x.StartDate).Must(x => x < DateTimeOffset.Now).
                WithMessage("The start date cannot be greater than the current date");
        }
    }
}
