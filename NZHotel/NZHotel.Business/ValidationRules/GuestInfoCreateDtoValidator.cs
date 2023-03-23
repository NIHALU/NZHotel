using FluentValidation;
using NZHotel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Business.ValidationRules
{
    public class GuestInfoCreateDtoValidator:AbstractValidator<GuestInfoCreateDto>
    {
        public GuestInfoCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Age).NotEmpty();
            RuleFor(x => x.GuestTypeId).NotEmpty();

        }
    }
}
