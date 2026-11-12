using FluentValidation;
using Mfc.Health.Corner.Application.Dto;

namespace Mfc.Health.Corner.Application.Validators
{
    public class CreateMedicalExaminationDtoValidator : AbstractValidator<CreateMedicalExaminationDto>
    {
        public CreateMedicalExaminationDtoValidator()
        {
            RuleFor(x => x.PhoneNumber).NotEmpty();
            RuleFor(x => x.Age).NotEmpty();
            RuleFor(x => x.TestNames).NotEmpty();
        }
    }
}
