using FluentValidation;
using NZHotel.UI.Areas.Admin.Models;

namespace NZHotel.UI.ValidationRules
{
    public class RoomDetailCreateModelValidator : AbstractValidator<RoomDetailCreateModel>
    {
        public RoomDetailCreateModelValidator()
        {
            RuleFor(x => x.RoomId).NotEmpty();
        }
    }
}
