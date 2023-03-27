using FluentValidation;
using NZHotel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Business.ValidationRules
{
    public class GuestTypeUpdateDtoValidator:AbstractValidator<GuestTypeUpdateDto>
    {
        public GuestTypeUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
