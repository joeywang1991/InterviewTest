namespace InterviewTest.Models
{
    public class CurrentPriceResponse
    {
        public Time? Time { get; set; }
        public string Disclaimer { get; set; }
        public string ChartName { get; set; }
        public Bpi? Bpi { get; set; }
    }


    public class Time
    {
        public string Updated { get; set; }
        public string UpdatedISO { get; set; }
        public string Updateduk { get; set; }
    }

    public class Bpi
    {
        public CurrencyInfo? USD { get; set; }
        public CurrencyInfo? GBP { get; set; }
        public CurrencyInfo? EUR { get; set; }
    }

    public class CurrencyInfo
    {
        public string code { get; set; }
        public string symbol { get; set; }
        public string rate { get; set; }
        public string description { get; set; }
        public decimal rate_float { get; set; }
    }
}
