using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuYuan_net7.Models
{
    public class BloodPressure
    {
        [Key]
        [Display(Name = "id")]
        public int ID { get; set; }
        [Display(Name = "uid")]
        public string Uid { get; set; }
        [Display(Name = "systolic")]
        public double? Systolic { get; set; }
        [Display(Name = "diastolic")]
        public double? Diastolic { get; set; }
        [Display(Name = "pulse")]
        public int? Pulse { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "recorded_at")]
        public DateTime? Recorded_at { get; set; }
    }

    [NotMapped]
    public class UserBloodPViewModel
    {
        public double Systolic { get; set; }
        [Display(Name = "diastolic")]
        public double Diastolic { get; set; }
        [Display(Name = "pulse")]
        public int Pulse { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "recorded_at")]
        public DateTime Recorded_at { get; set; }
    }
}
