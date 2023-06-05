using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuYuan_net7.Models
{
    public class Weight_M
    {
        [Key]
        [Display(Name = "id")]
        public int ID { get; set; }
        [Display(Name = "uid")]
        public string Uid { get; set; }
        [Display(Name = "weight")]
        public double? Weight { get; set; }
        [Display(Name = "body_fat")]
        public double? Body_fat { get; set; }
        [Display(Name = "bmi")]
        public double? Bmi { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:yyyy-MM-dd H:mm:ss}")]
        [Display(Name = "recorded_at")]
        public DateTime? Recorded_at { get; set; }

    }

    [NotMapped]
    public class UserWeightViewModel
    {
        [Display(Name = "weight")]
        public double Weight { get; set; }
        [Display(Name = "body_fat")]
        public double Body_fat { get; set; }
        [Display(Name = "bmi")]
        public double Bmi { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "recorded_at")]
        public DateTime Recorded_at { get; set; }
    }
}
