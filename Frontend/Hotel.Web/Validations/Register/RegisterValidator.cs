using FluentValidation;
using Hotel.Entity.DTOs.Register;

namespace Hotel.Web.Validations.Register
{
    public class RegisterValidator : AbstractValidator<RegisterPostDTO>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name field required.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname field required.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail field required.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password field required.")
                .Matches("[A-Z]").WithMessage("Password must contain an uppercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain a digit.");
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm password field required.")
                .Equal(x => x.Password).WithMessage("Passwords must be same.");
        }
    }
}
