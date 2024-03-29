﻿using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NZHotel.UI.Areas.Reception.Models
{
    public class PaymentCreateModel
    {
        public int PaymentTypeId { get; set; }//Cash,CC,Pay Later 
        public decimal TotalAmount { get; set; }
        public string CreditCardNo { get; set; }
        public string CreditCardHolder { get; set; }
        public string CreditCardExpire { get; set; }
        public string CreditCardCVC { get; set; }
        public DateTime? ExpectedPaymentDate { get; set; }
       
        public SelectList PaymentTypes { get; set; }
    }
}
