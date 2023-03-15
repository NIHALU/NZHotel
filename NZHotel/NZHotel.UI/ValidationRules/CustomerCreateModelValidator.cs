using FluentValidation;
using NZHotel.UI.Areas.Reception.Models;

namespace NZHotel.UI.ValidationRules
{
    public class CustomerCreateModelValidator : AbstractValidator<CustomerCreateModel>
    {
        public CustomerCreateModelValidator()
        {
            RuleFor(x => x.ContactName).NotEmpty();
            RuleFor(x => x.ContactSurname).NotEmpty();
            RuleFor(x => x.ContactEmail).NotEmpty().EmailAddress();
            RuleFor(x => x.ContactPhone).NotEmpty();
            RuleFor(x => x.Country).NotEmpty();
            RuleFor(x => x.Adress).NotEmpty();
            RuleFor(x => x.TurkishIDNo).NotEmpty().When(x=>x.IsNoTurkishCitizen==false).WithMessage("TC No is required for TC citizens.");
            RuleFor(x => x.PassportNo).NotEmpty().When(x => x.IsNoTurkishCitizen == true).WithMessage("Passport No is required");
            RuleFor(x => x.TermsConditions).NotEmpty();
        }
    }
}
