using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
{
    public class GuestListDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Age { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
        public string PassportNumber { get; set; }
        public string Nationality { get; set; }
        public string CountryName { get; set; }
        public bool IsNoTurkishCitizen { get; set; }
        public DateTime BirthDay { get; set; }

        public bool VisitedBefore { get; set; }

        public GuestTypeListDto GuestType { get; set; }
        public int GuestTypeId { get; set; }

        public GenderListDto Gender { get; set; }

        public int GenderId { get; set; }
    
    }
}
