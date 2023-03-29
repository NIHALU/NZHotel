using FluentValidation;
using NZHotel.UI.Areas.Member.Models;

namespace NZHotel.UI.ValidationRules
{
    public class PaymentCreateModel2Validator:AbstractValidator<PaymentCreateModel2>
    {
        public PaymentCreateModel2Validator()
        {
            RuleFor(x => x.CreditCardNo).NotEmpty().WithMessage("Credit Card No is required");
            RuleFor(x => x.CreditCardHolder).NotEmpty().WithMessage("Credit Card Holder is required");
            RuleFor(x => x.CreditCardExpire).NotEmpty().WithMessage("Credit Card Expire No is required");
            RuleFor(x => x.CreditCardCVC).NotEmpty().WithMessage("Credit Card No is required");
            RuleFor(x => x.CreditCardCVC).NotEmpty().WithMessage("CVC is required");
            RuleFor(x => x.TotalAmount).NotEmpty();
        }
    }
}
