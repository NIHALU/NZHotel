using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NZHotel.Common.Enums;
using NZHotel.DTOs;

namespace NZHotel.Business.ValidationRules
{
    public class ReservationUpdateDtoValidator : AbstractValidator<ReservationUpdateDto>
    {
        public ReservationUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.NumberofDays).NotEmpty();
            RuleFor(x => x.NumberofGuests).NotEmpty();
            RuleFor(x => x.StartingDate).NotEmpty();
            RuleFor(x => x.FinisingDate).NotEmpty();
            RuleFor(x => x.PaymentDeadline).NotEmpty().When(x => x.PaymentStatus == PaymentStatus.NonPaid).WithMessage("Payment deadline cannot be empty");
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.RoomId).NotEmpty();
            RuleFor(x => x.ReservationOptionId).NotEmpty();
        }
    }
}
