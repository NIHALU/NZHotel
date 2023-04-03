using FluentValidation;
using NZHotel.UI.Areas.Management.Models;

namespace NZHotel.UI.ValidationRules
{
    public class ShiftCreateModelValidator:AbstractValidator<ShiftCreateModel>
    {
        public ShiftCreateModelValidator()
        {
            RuleFor(x => x.EmployeeId).NotEmpty();
        }
    }
}
