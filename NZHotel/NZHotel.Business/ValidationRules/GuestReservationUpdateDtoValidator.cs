using FluentValidation;
using NZHotel.DTOs;

namespace NZHotel.Business.ValidationRules
{
    public class GuestReservationUpdateDtoValidator : AbstractValidator<GuestReservationUpdateDto>
    {
        public GuestReservationUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.GuestId).NotEmpty();
            RuleFor(x => x.ReservationId).NotEmpty();
            RuleFor(x => x.CheckInTime).NotEmpty();

			RuleFor(m => m.CheckOutTime)
		  .NotEmpty().WithMessage("CheckOut date is required")
		  .GreaterThan(m => m.CheckInTime)
				   .WithMessage("CheckOut date must after CheckIn date");
		}
    }
}
