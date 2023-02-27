using FluentValidation;
using NZHotel.UI.Areas.Admin.Models;

namespace NZHotel.UI.ValidationRules
{
    public class RoomDetailUpdateModelValidator : AbstractValidator<RoomDetailUpdateModel>
    {
        public RoomDetailUpdateModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
        
    }
}
