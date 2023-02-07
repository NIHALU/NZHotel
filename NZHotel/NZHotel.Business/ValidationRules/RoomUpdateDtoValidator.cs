using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NZHotel.DTOs;

namespace NZHotel.Business.ValidationRules
{
    public class RoomUpdateDtoValidator : AbstractValidator<RoomUpdateDto>
    {
        public RoomUpdateDtoValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.RoomName).NotEmpty();
            RuleFor(x => x.RoomNo).NotEmpty();
            RuleFor(x => x.BedInfo).NotEmpty();
            RuleFor(x => x.MaxAdults).NotEmpty();
            RuleFor(x => x.MaxChildren).NotEmpty();
            RuleFor(x => x.RoomPrice).NotEmpty();
            RuleFor(x => x.RoomStatusId).NotEmpty().WithMessage("While creating please default choose 1 as meaning free");
            RuleFor(x => x.RoomTypeId).NotEmpty();
        }
    }
}
