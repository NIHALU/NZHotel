using FluentValidation;
using NZHotel.Common.Enums;
using NZHotel.UI.Areas.Reception.Models;

namespace NZHotel.UI.ValidationRules
{
    public class GuestCreateModelValidator:AbstractValidator<GuestCreateModel>
    {
        public GuestCreateModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(40);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(40); ;
            RuleFor(x => x.Age).Must(BeAValidAgeAdult).When(x => x.GuestTypeId == (int)GuestType.ADT).WithMessage("Adult age must be 12+");
            RuleFor(x => x.Age).Must(BeAValidAgeChild).When(x => x.GuestTypeId == (int)GuestType.CHD).WithMessage("Child age must be 2-12");
            RuleFor(x => x.Age).Must(BeAValidAgeInf).When(x => x.GuestTypeId == (int)GuestType.INF).WithMessage("Infant age must be 0-2");
            RuleFor(x => x.GenderId).NotEmpty();
            RuleFor(x => x.CountryName).NotEmpty();
            RuleFor(x => x.Nationality).NotEmpty();
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.IdentityNumber).NotEmpty().When(x => x.IsNoTurkishCitizen == false).WithMessage("TC No is required for TC citizens.");
            RuleFor(x => x.PassportNumber).NotEmpty().When(x => x.IsNoTurkishCitizen == true).WithMessage("Passport No is required");
          
        }
        protected bool BeAValidAgeInf(int age)
        {
            return age <= 2 ? true : false;

        }

        protected bool BeAValidAgeChild(int age)
        {
            return age > 2 && age <= 12 ? true : false;

        }

        protected bool BeAValidAgeAdult(int age)
        {
            return age > 12 ? true : false;

        }

    }

    
    
}
