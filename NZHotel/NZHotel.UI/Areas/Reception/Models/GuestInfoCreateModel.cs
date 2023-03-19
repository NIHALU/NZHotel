using System;

namespace NZHotel.UI.Areas.Reception.Models
{
    public class GuestInfoCreateModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime BirthDay { get; set; }

        public int GuestTypeId { get; set; }

        public int Age { get; set; }
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
