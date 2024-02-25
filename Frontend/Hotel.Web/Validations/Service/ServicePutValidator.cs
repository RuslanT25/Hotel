using FluentValidation;
using Hotel.Entity.DTOs.Service;

namespace Hotel.Web.Validations.Service
{
    public class ServicePutValidator : AbstractValidator<ServiceGetPutDTO>
    {
        public ServicePutValidator()
        {
            RuleFor(x => x.Icon)
            .NotEmpty()
            .WithMessage("Add service icon,please");

            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Add service title,please")
            .MaximumLength(100).WithMessage("Service title can be up to 100 characters");

            RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Add service description,please")
            .MaximumLength(500).WithMessage("Service description can be up to 500 characters");
        }
    }
}
