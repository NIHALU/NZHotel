using FluentValidation;
using NZHotel.UI;
using System;

namespace NZHotel.UI.ValidationRules
{
    public class BookRoomModelValidator : AbstractValidator<BookRoomModel>
    {
        public BookRoomModelValidator()
        {
            RuleFor(x => x.StartingDate).NotEmpty().WithMessage("Enterance date is required");
            RuleFor(x => x.StartingDate).Must(BeAValidDate).WithMessage("Starting Date must be greater or equal than date of today");


            RuleFor(m => m.FinisingDate)
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
