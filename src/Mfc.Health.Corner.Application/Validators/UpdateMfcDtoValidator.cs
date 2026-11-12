using FluentValidation;
using Mfc.Health.Corner.Application.Dto;

namespace Mfc.Health.Corner.Application.Validators
{
    public class UpdateMfcDtoValidator : AbstractValidator<UpdateMfcDto>
    {
        public UpdateMfcDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
