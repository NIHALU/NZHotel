using FluentValidation;
using NZHotel.UI.Areas.Admin.Models;

namespace NZHotel.UI.ValidationRules
{
    public class RoomUpdateModelValidator : AbstractValidator<RoomUpdateViewModel>
    {
        public RoomUpdateModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.RoomName).NotEmpty();
            RuleFor(x => x.RoomNo).NotEmpty();
            RuleFor(x => x.BedInfo).NotEmpty();
            RuleFor(x => x.MaxAdults).NotEmpty();
            //RuleFor(x => x.MaxChildren).NotEmpty();
            RuleFor(x => x.RoomPrice).NotEmpty();
            RuleFor(x => x.RoomStatusId).NotEmpty();
            RuleFor(x => x.RoomTypeId).NotEmpty();
        }
    }
}
