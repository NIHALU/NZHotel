using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.Common.Enums;

namespace NZHotel.Entities
{
    public class GuestDetails:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string IdentityNumber { get; set; }
        public string PassportNumber { get; set; }
        public string CountryName { get; set; }
        public bool IsTurkish { get; set; }

        public GuestType GuestType { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
