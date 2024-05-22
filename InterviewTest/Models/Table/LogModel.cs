using System.ComponentModel.DataAnnotations;

namespace InterviewTest.Models.Table
{
    public class LogModel
    {
        [Key]
        public long LogID { get; set; }
        public DateTime RequestTime { get; set; }
        public string? RequestHeader { get; set; }
        public string? RequestBody { get; set; }
        public DateTime? ResponseTime { get; set; }
        public string? ResponseHeader { get; set; }
        public string? ResponseBody { get; set; }
    }
}
