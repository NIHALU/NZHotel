using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace NZHotel.UI.Areas.Reception.Models
{
    public class GuestCreateModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
        public string PassportNumber { get; set; }
        public string Nationality { get; set; }
        public string CountryName { get; set; }
        public bool IsNoTurkishCitizen { get; set; }
        public DateTime BirthDay { get; set; }
        public int GuestTypeId { get; set; }
        public int GenderId { get; set; }

        public SelectList GuestTypes { get; set; }
        public SelectList Genders { get; set; }

        public int CalculateAge()
        {
            DateTime today = DateTime.Today;
            DateTime birtDate = BirthDay.Date;
            int age = today.Year - birtDate.Year;
            if (birtDate > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

    }
}
