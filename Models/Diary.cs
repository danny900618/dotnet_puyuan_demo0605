using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuYuan_net7.Models
{
    public class Diary
    {
        [Key]
        [Display(Name = "id")]
        public int ID { get; set; }
        [Display(Name = "uid")]
        public string Uid { get; set; }
        [Display(Name = "description")]
        public string? Description { get; set; }
        [Display(Name = "meal")]
        public int? Meal { get; set; }
        [Display(Name = "tag[]")]
        public string? Tag { get; set; }
        [Display(Name = "image")]
        public int? Image { get; set; }
        [Display(Name = "lat")]
        public double? Lat { get; set; }
        [Display(Name = "lng")]
        public double? Lng { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "recorded_at")]
        public DateTime? Recorded_at { get; set; }
    }

    [NotMapped]
    public class UserDiaryViewModel
    {
        [Display(Name = "description")]
        public string? Description { get; set; }
        [Display(Name = "meal")]
        public int? Meal { get; set; }
        [Display(Name = "tag[]")]
        public string? Tag { get; set; }
        [Display(Name = "image")]
        public int? Image { get; set; }
        [Display(Name = "lat")]
        public double? Lat { get; set; }
        [Display(Name = "lng")]
        public double? Lng { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "recorded_at")]
        public DateTime? Recorded_at { get; set; }
    }


    //以下為14.日記列表資料
    [NotMapped]
    public class UserDiaryValue
    {
        public string? Status { get; set; }
        public List<DiaryValue>? Diary { get; set; }
    }
    [NotMapped]
    public class DiaryValue
    {
        public int? Id { get; set; }
        public int? User_id { get; set; }

        public double? Systolic { get; set; }
        public double? Diastolic { get; set; }
        public int? Pulse { get; set; }

        public double? Weight { get; set; }
        public double? Body_fat { get; set; }
        public double? Bmi { get; set; }

        public int? Sugar { get; set; }
        public int? timeperiod { get; set; }

        public string? message { get; set; }
        public DateTime? Recorded_at { get; set; }
        public string? Type { get; set; }
    }
}
