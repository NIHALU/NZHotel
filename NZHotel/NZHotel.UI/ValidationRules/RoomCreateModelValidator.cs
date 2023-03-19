using FluentValidation;
using NZHotel.UI.Areas.Admin.Models;

namespace NZHotel.UI.ValidationRules
{
    public class RoomCreateModelValidator : AbstractValidator<RoomCreateViewModel>
    {
        public RoomCreateModelValidator()
        {
            RuleFor(x => x.RoomName).NotEmpty();
            RuleFor(x => x.RoomNo).NotEmpty();
            RuleFor(x => x.BedInfo).NotEmpty();
            RuleFor(x => x.MaxAdults).NotEmpty();
            RuleFor(x => x.RoomPrice).NotEmpty();
            RuleFor(x => x.RoomStatusId).NotEmpty().WithMessage("While creating please default choose free");
            RuleFor(x => x.RoomTypeId).NotEmpty();
        }

    }
    
}
