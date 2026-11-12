using FluentValidation;
using Mfc.Health.Corner.Application.Dto;

namespace Mfc.Health.Corner.Application.Validators
{
    public class CreateMfcCornerDtoValidator : AbstractValidator<CreateMfcCornerDto>
    {
        public CreateMfcCornerDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.DistrictId).NotEmpty();
            RuleFor(x => x.TelegtamChatId).NotEmpty();
        }
    }
}
