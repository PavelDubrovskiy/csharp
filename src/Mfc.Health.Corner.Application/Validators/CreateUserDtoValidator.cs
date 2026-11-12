using FluentValidation;
using Mfc.Health.Corner.Application.Dto;

namespace Mfc.Health.Corner.Application.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.FullName).NotEmpty();

            RuleFor(x => x.Phone).NotEmpty();

            RuleFor(x => x.Email).NotEmpty().EmailAddress();

            RuleFor(x => x.Login).NotEmpty();

            RuleFor(x => x.RoleNames).NotEmpty();

            RuleFor(x => x).Must(x =>
                    x.RoleNames[0].Equals("HeadOfTheMfcDivision") && !string.IsNullOrWhiteSpace(x.DistrictId) ||
                    x.RoleNames[0].Equals("HeadOfMfc") && !string.IsNullOrWhiteSpace(x.MfcCornerId) ||
                    x.RoleNames[0].Equals("UserManagement") && !string.IsNullOrWhiteSpace(x.MfcCornerId) ||
                    x.RoleNames[0].Equals("Admin") ||
                    x.RoleNames[0].Equals("SuperAdmin")).
                WithMessage("The district or mfc cannot be selected");
        }
    }
}


