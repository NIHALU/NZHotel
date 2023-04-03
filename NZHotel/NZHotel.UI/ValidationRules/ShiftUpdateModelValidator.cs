using FluentValidation;
using NZHotel.UI.Areas.Management.Models;

namespace NZHotel.UI.ValidationRules
{
    public class ShiftUpdateModelValidator:AbstractValidator<ShiftUpdateModel>
    {
        public ShiftUpdateModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.EmployeeId).NotEmpty();
        }
    }
}
