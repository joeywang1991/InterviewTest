using System.ComponentModel.DataAnnotations;

namespace InterviewTest.Models.Table
{
    public class ExchangeRateModel
    {
        [Key]
        public long ExchangeID { get; set; }
        public long CurrencyID { get; set; }
        public long ExchangeCurrencyID { get; set; }
        public decimal ExchangeRate { get; set; }
        public string Description { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
