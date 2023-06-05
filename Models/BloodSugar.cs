using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuYuan_net7.Models
{
    public class BloodSugar
    {
        [Key]
        [Display(Name = "id")]
        public int ID { get; set; }
        [Display(Name = "uid")]
        public string Uid { get; set; }
        [Display(Name = "sugar")]
        public int? Sugar { get; set; }
        [Display(Name = "timeperiod")]
        public int? timeperiod { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "recorded_at")]
        public DateTime? Recorded_at { get; set; }
    }

    [NotMapped]
    public class UserBloodSugarViewModel
    {
        [Display(Name = "sugar")]
        public int Sugar { get; set; }
        [Display(Name = "timeperiod")]
        public int timeperiod { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "recorded_at")]
        public DateTime Recorded_at { get; set; }
    }
}
