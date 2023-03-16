using System;

namespace NZHotel.UI.Areas.Reception.Models
{
    public class GuestInfoCreateModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime BirthDay { get; set; }

        public int GuestTypeId { get; set; }
    }
}
