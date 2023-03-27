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
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
        public string PassportNumber { get; set; }
        public string Nationality { get; set; }
        public string CountryName { get; set; }
        public bool IsNoTurkishCitizen { get; set; } 
        public DateTime BirthDay { get; set; }

        

        //lookup
        public int GuestTypeId { get; set; }
        public GuestType GuestType { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public List<GuestReservation> GuestReservations { get; set; } = new();


        public bool VisitedBefore()
        {
            if (GuestReservations?.Count(x =>x.GuestId == Id)>0)
            {
                return true;
            }
            return false;

        }
  
    }
}
