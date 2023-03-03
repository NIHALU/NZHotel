using FluentValidation;
using NZHotel.UI;

namespace NZHotel.UI.ValidationRules
{
    public class BookRoomModelValidator : AbstractValidator<BookRoomModel>
    {
        public BookRoomModelValidator()
        {
        //    RuleFor(x => x.StartingDate).NotEmpty();
        //    RuleFor(x => x.FinisingDate).NotEmpty();
        //    RuleFor(x => x.AdultNumber).NotEmpty();
            //RuleFor(x => x.ChildNumber).NotEmpty();
            //RuleFor(x => x.InfantNumber).NotEmpty();
        }
    }
}
