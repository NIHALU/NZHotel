﻿using FluentValidation;
using NZHotel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Business.ValidationRules
{
    public class CustomerUpdateDtoValidator:AbstractValidator<CustomerUpdateDto>
    {
        public CustomerUpdateDtoValidator()
        {

        }
    }
}
