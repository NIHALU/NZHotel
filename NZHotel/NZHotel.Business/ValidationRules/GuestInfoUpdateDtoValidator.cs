using FluentValidation;
using NZHotel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Business.ValidationRules
{
    public class GuestInfoUpdateDtoValidator:AbstractValidator<GuestInfoUpdateDto>
    {
        public GuestInfoUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Age).NotEmpty();
            RuleFor(x => x.GuestTypeId).NotEmpty();

        }
    }
}
