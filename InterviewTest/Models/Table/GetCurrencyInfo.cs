using System.ComponentModel.DataAnnotations;

namespace InterviewTest.Models.Table
{
    public class GetCurrencyInfo
    {
        [Key]
        public string CurrencyName { get; set; }
        public string CurrencyCName { get; set; }
        public string ExchangeCurrencyName { get; set; }
        public string ExchangeCurrencyCName { get; set; }
        public decimal ExchangeRate { get; set; }
        public string UpdateTime { get; set; }

    }
}
