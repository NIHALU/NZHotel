namespace NZHotel.UI.Areas.Member.Models
{
    public class PaymentCreateModel2
    {
        public decimal TotalAmount { get; set; }
        public string CreditCardNo { get; set; }
        public string CreditCardHolder { get; set; }
        public string CreditCardExpire { get; set; }
        public string CreditCardCVC { get; set; }
    
    }
}
