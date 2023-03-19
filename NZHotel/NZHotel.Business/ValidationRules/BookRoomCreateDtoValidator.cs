using FluentValidation;
using NZHotel.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Business.ValidationRules
{
    public class BookRoomCreateDtoValidator:AbstractValidator<BookRoomCreateDto>
    {
        public BookRoomCreateDtoValidator()
        {
            RuleFor(x=>x.AdultNumber).NotEmpty();
        }
    }
}
