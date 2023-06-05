using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PuYuan_net7.Models
{
    public class A1c
    {
        [Key]
        [Display(Name = "id")]
        public int ID { get; set; }
        [Display(Name = "uid")]
        public string Uid { get; set; }
        [Display(Name = "a1c")]
        public decimal? A1c_v { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "recorded_at")]
        public DateTime? Recorded_at { get; set; }
    }

    //以下為32.糖化血色素
    [NotMapped]
    public class userA1cValue
    {
        public string? Status { get; set; }
        public List<A1csValue>? A1cs { get; set; }
    }
    [NotMapped]
    public class A1csValue
    {
        public int? Id { get; set; }
        public int? User_id { get; set; }
        public decimal? A1c_v { get; set; }
        public DateTime? Recorded_at { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
    }
}
