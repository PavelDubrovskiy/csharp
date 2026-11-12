using FluentValidation;
using Mfc.Health.Corner.Application.Dto;

namespace Mfc.Health.Corner.Application.Validators
{
    public class RecoveryPasswordDtoValidator : AbstractValidator<RecoveryPasswordDto>
    {
        public RecoveryPasswordDtoValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
