using FluentValidation;
using Hotel.Entity.DTOs.Booking;
using System;

namespace Hotel.Web.Validations.Booking
{
    public class BookingValidator : AbstractValidator<BookingBaseDTO>
    {
        public BookingValidator()
        {
            RuleFor(booking => booking.FullName)
                .NotEmpty().WithMessage("FullName cannot be empty.")
                .MaximumLength(50).WithMessage("FullName cannot be longer than 50 characters.");

            RuleFor(booking => booking.Mail)
                .NotEmpty().WithMessage("Mail cannot be empty.")
                .EmailAddress().WithMessage("Mail must be a valid email address.")
                .MaximumLength(100).WithMessage("Mail cannot be longer than 100 characters.");

            RuleFor(booking => booking.AdultCount)
                .NotEmpty().WithMessage("AdultCount cannot be empty.")
                .InclusiveBetween(1, 3).WithMessage("AdultCount must be between 1 and 3.");

            RuleFor(booking => booking.Children)
                .NotEmpty().WithMessage("Children cannot be empty.")
                .InclusiveBetween(1, 3).WithMessage("Children must be between 1 and 3.");

            RuleFor(booking => booking.Checkin)
                .NotEmpty().WithMessage("CheckIn cannot be empty.");

            RuleFor(booking => booking.CheckOut)
                .NotEmpty().WithMessage("CheckOut cannot be empty.");
        }
    }
}
