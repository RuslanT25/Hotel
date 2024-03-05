using FluentValidation;
using Hotel.Entity.DTOs.Service;

namespace Hotel.Web.Validations.Service
{
    public class ServiceValidator : AbstractValidator<ServiceBaseDTO>
    {
        public ServiceValidator()
        {
            RuleFor(x => x.Icon)
           .NotEmpty()
           .WithMessage("Add service icon,please");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Add service title,please")
                .MaximumLength(25).WithMessage("Service title can be up to 100 characters")
                .MinimumLength(2).WithMessage("Service title can be at least 2 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Add service description,please")
                .MaximumLength(120).WithMessage("Service description can be up to 120 characters")
                .MinimumLength(30).WithMessage("Service description can be at least 30 characters");
        }
    }
}
