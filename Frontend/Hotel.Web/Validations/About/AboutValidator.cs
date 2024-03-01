using FluentValidation;

namespace Hotel.Web.Validations.About
{
    public class AboutValidator : AbstractValidator<Entity.DTOs.About.AboutBaseDTO>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Title1)
                .NotEmpty().WithMessage("Title filed required.")
                .MaximumLength(25);

            RuleFor(x => x.Title2)
                .NotEmpty().WithMessage("Title field required.")
                .MaximumLength(25);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description field required")
                .MaximumLength(500);

            RuleFor(x => x.StaffCount)
                .NotEmpty().WithMessage("Staff count required.")
                .Must(x => x >= 0).WithMessage("Staff count can't be negative");

            RuleFor(x => x.RoomCount)
                .NotEmpty().WithMessage("Room count required.")
                .Must(x => x >= 0).WithMessage("Room count can't be negative");

            RuleFor(x => x.CustomerCount)
                .NotEmpty().WithMessage("Customer count required.")
                .Must(x => x >= 0).WithMessage("Customer count can't be negative");
        }
    }
}
