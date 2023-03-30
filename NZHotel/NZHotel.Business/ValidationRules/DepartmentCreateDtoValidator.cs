using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NZHotel.DTOs.DepartmentDtos;

namespace NZHotel.Business.ValidationRules
{
    public class DepartmentCreateDtoValidator:AbstractValidator<DepartmentCreateDto>
    {
        public DepartmentCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
