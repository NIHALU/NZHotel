﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NZHotel.DTOs;

namespace NZHotel.Business.ValidationRules
{
    public class ShiftUpdateDtoValidator:AbstractValidator<ShiftUpdateDto>
    {
        public ShiftUpdateDtoValidator()
        {

        }
    }
}
