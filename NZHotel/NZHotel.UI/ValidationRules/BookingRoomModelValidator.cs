using FluentValidation;
using NZHotel.UI.Areas.Member.Models;
using System;

namespace NZHotel.UI.ValidationRules
{
    public class BookingRoomModelValidator:AbstractValidator<BookingRoomModel>
    {
        public BookingRoomModelValidator()
        {

            RuleFor(x => x.StartingDate).NotEmpty().WithMessage("Enterance date is required");
            RuleFor(x => x.StartingDate).Must(BeAValidDate).WithMessage("Starting Date must be greater or equal than date of today");


            RuleFor(m => m.FinishingDate)
          .NotEmpty().WithMessage("Exist date is required")
          .GreaterThan(m => m.StartingDate)
                   .WithMessage("Exist date must after Enterance date");

            RuleFor(x => x.ReservationOptionId).NotEmpty().WithMessage("Please choose reservation option.");
        }
        protected bool BeAValidDate(DateTime date)
        {
            return (date.Date >= DateTime.Today) ? true : false;
        }

    }
}
