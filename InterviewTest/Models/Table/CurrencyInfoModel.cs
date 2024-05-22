using System.ComponentModel.DataAnnotations;

namespace InterviewTest.Models.Table
{
    public class CurrencyInfoModel
    {
        [Key]
        public long CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
