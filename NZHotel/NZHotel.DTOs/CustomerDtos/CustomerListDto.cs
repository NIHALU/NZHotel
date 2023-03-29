using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs
{ 
    public class CustomerListDto:IDto
    {
        public int Id { get; set; }
        public string ContactName { get; set; }
        public string ContactSurname { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public bool IsNoTurkishCitizen { get; set; }
        public string TurkishIDNo { get; set; }
        public string PassportNo { get; set; }
        public string Country { get; set; }
        public string Adress { get; set; }
        public int ReservationId { get; set; }
        public ReservationListDto Reservation { get; set; }
    }
}
