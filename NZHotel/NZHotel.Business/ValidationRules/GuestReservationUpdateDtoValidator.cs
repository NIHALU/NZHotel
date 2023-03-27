using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }
    }
}
