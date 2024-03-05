using FluentValidation;
using Hotel.Entity.DTOs.Testimonial;

namespace Hotel.Web.Validations.Testimonial
{
    public class TestimonialValidator : AbstractValidator<TestimonialBaseDTO>
    {
        public TestimonialValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(25);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(140);

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name field is required.")
                .MaximumLength(20);
        }
    }
}
