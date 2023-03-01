using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NZHotel.DTOs;
using NZHotel.Entities;

namespace NZHotel.Business.ValidationRules
{
    public class ReservationOptionUpdateDtoValidator : AbstractValidator<ReservationOptionUpdateDto>
    {
        public ReservationOptionUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
