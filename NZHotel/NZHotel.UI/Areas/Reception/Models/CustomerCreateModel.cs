namespace NZHotel.UI.Areas.Reception.Models
{
    public class CustomerCreateModel
    {
        public string ContactName { get; set; }
        public string ContactSurname { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public bool IsNoTurkishCitizen { get; set; }
        public string TurkishIDNo { get; set; }
        public string PassportNo { get; set; }
        public string Country { get; set; }
        public string Adress { get; set; }
        public bool TermsConditions { get; set; } 
    }
}
