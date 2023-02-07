﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NZHotel.DTOs;

namespace NZHotel.Business.ValidationRules
{
    public class RoomTypeCreateDtoValidator : AbstractValidator<RoomTypeCreateDto>
    {
        public RoomTypeCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
