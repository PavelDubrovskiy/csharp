using FluentValidation;

namespace Mfc.Health.Corner.Application.Validators
{
    public static class ValidatorExtentions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
            .NotEmpty().WithMessage("Password must not be null or empty")
            .MinimumLength(6).WithMessage("Password must contain at least 6 characters")
            .Matches("[A-Z]").WithMessage("Password must contain letters")
            .Matches("[0-9]").WithMessage("Password must contain numbers");
            return options;
        }
    }
}
