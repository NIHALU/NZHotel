using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NZHotel.DTOs.Interfaces;

namespace NZHotel.DTOs.ExtraPaymentDtos
{
    public class ExtraPaymentUpdateDto:IUpdateDto
    {
        public int Id { get; set; } 
        public decimal ExtraAmount { get; set; }
        public string CreditCardNo { get; set; }
        public string CreditCardHolder { get; set; }
        public int CreditCardExpire { get; set; }
        public int CreditCardCVC { get; set; }
    }
}
