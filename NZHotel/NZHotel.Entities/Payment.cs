using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NZHotel.Entities
{
    public class Payment : BaseEntity
    {
        public string CreditCardNo { get; set; }
        public string CreditCardHolder { get; set; }
        public int CreditCardExpire { get; set; }
        public int CreditCardCVC { get; set; }
        public DateTime? ExpectedPaymentDate { get; set; }


        //Navigational Prop Begins
        //public int? ReservationId { get; set; }
        //public Reservation Reservation { get; set; }
        public int PaymentTypeId { get; set; }
        public PaymentType PaymentType { get; set; }

    }
}
