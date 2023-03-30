using FluentValidation;
using NZHotel.UI.Areas.Management.Models;

namespace NZHotel.UI.ValidationRules
{
    public class EmployeeCreateModelValidator:AbstractValidator<EmployeeCreateModel>
    {
        public EmployeeCreateModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Address).NotEmpty().MaximumLength(40);
            RuleFor(x => x.IdentityNumber).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.DepartmentId).NotEmpty();
            RuleFor(x => x.GenderId).NotEmpty();
        }
    }
}
