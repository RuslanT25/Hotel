using FluentValidation;
using Hotel.Entity.DTOs.Staff;

namespace Hotel.Web.Validations.Staff
{
    public class StaffValidator : AbstractValidator<StaffBaseDTO>
    {
        public StaffValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Add staff name,please")
                .MaximumLength(30).WithMessage("Staff name can be up to 30 characters");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Add staff title,please")
                .MaximumLength(30).WithMessage("Staff title can be up to 30 characters");

            RuleFor(x => x.SocialMedia1)
                .MaximumLength(100).WithMessage("Staff socialmedia can be up to 100 characters");

            RuleFor(x => x.SocialMedia2)
               .MaximumLength(100).WithMessage("Staff socialmedia can be up to 100 characters");

            RuleFor(x => x.SocialMedia3)
               .MaximumLength(100).WithMessage("Staff socialmedia can be up to 100 characters");
        }
    }
}
