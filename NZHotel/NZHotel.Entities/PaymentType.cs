using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Entities
{
    public class PaymentType:BaseEntity
    {
        public string Definition { get; set; }
        public List<Payment> Payments { get; set; }
        public List<Reservation> Reservations { get; set; }
      
    }
}
