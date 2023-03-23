using FluentValidation;
using NZHotel.Common.Enums;
using NZHotel.UI.Areas.Reception.Models;

namespace NZHotel.UI.ValidationRules
{
    public class PaymentCreateModelValidator : AbstractValidator<PaymentCreateModel>
    {
        public PaymentCreateModelValidator()
        {
            RuleFor(x => x.CreditCardNo).NotEmpty().When(x => x.PaymentTypeId == (int)PaymentType.CreditCard || x.PaymentTypeId==(int)PaymentType.PayLater).WithMessage("Credit Card No is required");
            RuleFor(x => x.CreditCardHolder).NotEmpty().When(x => x.PaymentTypeId == (int)PaymentType.CreditCard || x.PaymentTypeId == (int)PaymentType.PayLater).WithMessage("Credit Card Holder is required");
            RuleFor(x => x.CreditCardExpire).NotEmpty().When(x => x.PaymentTypeId == (int)PaymentType.CreditCard || x.PaymentTypeId == (int)PaymentType.PayLater).WithMessage("Credit Card Expire No is required");
            RuleFor(x => x.CreditCardCVC).NotEmpty().When(x => x.PaymentTypeId == (int)PaymentType.CreditCard || x.PaymentTypeId == (int)PaymentType.PayLater).WithMessage("Credit Card No is required");
            RuleFor(x => x.CreditCardCVC).NotEmpty().When(x => x.PaymentTypeId == (int)PaymentType.CreditCard || x.PaymentTypeId == (int)PaymentType.PayLater).WithMessage("CVC is required");
            RuleFor(x => x.ExpectedPaymentDate).NotEmpty().When(x=> x.PaymentTypeId == (int)PaymentType.PayLater).WithMessage("Expected Payment Date is required");
        }
    }
}
