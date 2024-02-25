using FluentValidation;
using Hotel.Entity.DTOs.Service;

namespace Hotel.Web.Validations.Service
{
    public class ServicePostValidator : AbstractValidator<ServicePostDTO>
    {
        public ServicePostValidator()
        {
            RuleFor(x => x.Icon)
            .NotEmpty()
            .WithMessage("Add service icon,please");

            RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Add service title,please")
            .MaximumLength(100).WithMessage("Service title can be up to 100 characters");
        }
    }
}
