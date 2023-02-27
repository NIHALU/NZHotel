using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NZHotel.DTOs;

namespace NZHotel.Business.ValidationRules
{
    public class RoomDetailUpdateDtoValidator : AbstractValidator<RoomDetailUpdateDto>
    {
        public RoomDetailUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.RoomId).NotEmpty();   
        }
    }
}
