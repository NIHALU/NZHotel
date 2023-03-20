using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs.PaymentDtos
{
    public class PaymentCreateDto:IDto
    {
        public int PaymentTypeId { get; set; }//Cash,CC,Pay Later 
        public string CreditCardNo { get; set; }
        public string CreditCardHolder { get; set; }
        public int CreditCardExpire { get; set; }
        public int CreditCardCVC { get; set; }
        public DateTime? ExpectedPaymentDate { get; set; }
    }
}
