﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NZHotel.DTOs;

namespace NZHotel.Business.ValidationRules
{
    public class RoomCreateDtoValidator: AbstractValidator<RoomCreateDto>
    {
        public RoomCreateDtoValidator()
        {
            RuleFor(x=>x.RoomName).NotEmpty();
            RuleFor(x=>x.RoomNo).NotEmpty();
            RuleFor(x => x.BedInfo).NotEmpty();
            RuleFor(x => x.MaxAdults).NotEmpty();
            //RuleFor(x => x.MaxChildren).NotEmpty();
            RuleFor(x => x.RoomPrice).NotEmpty();
            RuleFor(x => x.RoomStatusId).NotEmpty();
            RuleFor(x => x.RoomTypeId).NotEmpty();
        }
    }
}
