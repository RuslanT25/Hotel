using FluentValidation;
using Hotel.Entity.DTOs.Login;

namespace Hotel.Web.Validations.Login
{
    public class LoginValidator : AbstractValidator<LoginPostDTO>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Mail).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
