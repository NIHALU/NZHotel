using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using NZHotel.DTOs;

namespace NZHotel.Business.ValidationRules
{
    public class EmployeeCreateDtoValidator:AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.IdentityNumber).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.DepartmentId).NotEmpty();
            RuleFor(x => x.GenderId).NotEmpty();
        }
    }
}
