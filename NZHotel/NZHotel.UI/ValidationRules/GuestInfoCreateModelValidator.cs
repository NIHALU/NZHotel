using FluentValidation;
using NZHotel.Common.Enums;
using NZHotel.UI.Areas.Reception.Models;
using System;

namespace NZHotel.UI.ValidationRules
{
    public class GuestInfoCreateModelValidator:AbstractValidator<GuestInfoCreateModel>
    {
        public GuestInfoCreateModelValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(40);
            RuleFor(x => x.Surname).NotEmpty().MaximumLength(40); ;
            RuleFor(x => x.Age).Must(BeAValidAgeAdult).When(x => x.GuestTypeId == (int)GuestType.ADT).WithMessage("Adult age must be 12+");
            RuleFor(x => x.Age).Must(BeAValidAgeChild).When(x => x.GuestTypeId == (int)GuestType.CHD).WithMessage("Child age must be 2-12");
            RuleFor(x => x.Age).Must(BeAValidAgeInf).When(x => x.GuestTypeId == (int)GuestType.INF).WithMessage("Infant age must be 0-2");

        }
        protected bool BeAValidAgeInf(int age)
        {
            return age<=2 ? true : false;

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
