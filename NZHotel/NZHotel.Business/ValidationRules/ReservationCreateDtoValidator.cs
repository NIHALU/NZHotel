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
    public class ReservationCreateDtoValidator : AbstractValidator<ReservationCreateDto>
    {
        public ReservationCreateDtoValidator()
        {
            RuleFor(x => x.NumberofDays).NotEmpty();
            RuleFor(x => x.NumberofGuests).NotEmpty();
            RuleFor(x => x.StartingDate).NotEmpty();
            RuleFor(x => x.FinishingDate).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.RoomId).NotEmpty();
            RuleFor(x => x.ReservationOptionId).NotEmpty();
            RuleFor(x => x.ReservationTypeId).NotEmpty();
            RuleFor(X => X.TotalAmount).NotEmpty();
            RuleFor(x =>x.PaymentStatusId).NotEmpty();
        }
    }
}
