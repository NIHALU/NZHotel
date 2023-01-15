using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Entities
{
    public class Guest: BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool VisitedBefore { get; set; }
        public string IdentityNumber { get; set; }
        public string PassportNumber { get; set; }
        public string Nationality { get; set; }
        public DateTime BirthDay { get; set; }

        //Navigational Prop Begins
        public List<Reservation> Reservations { get; set; }
    }
}
