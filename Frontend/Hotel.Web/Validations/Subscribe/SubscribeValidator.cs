using FluentValidation;
using Hotel.Entity.DTOs.Subscribe;

namespace Hotel.Web.Validations.Subscribe
{
    public class SubscribeValidator : AbstractValidator<SubscribeBaseDTO>
    {
        public SubscribeValidator()
        {
            RuleFor(x => x.Mail)
                .MaximumLength(100)
                .EmailAddress();
        }
    }
}
