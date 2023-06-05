using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PuYuan_net7.Models
{
    public class Medical
    {
        [Key]
        [Display(Name = "id")]
        public int ID { get; set; }
        [Display(Name = "account")]
        public string Account { get; set; }
        [Display(Name = "uid")]
        public string Uid { get; set; }
        [Display(Name = "diabetes_type")]
        public int? Diabetes_type { get; set; }
        [Display(Name = "oad")]
        public bool? Oad { get; set; }
        [Display(Name = "insulin")]
        public bool? Insulin { get; set; }
        [Display(Name = "anti_hypertensives")]
        public bool? Anti_hypertensives { get; set; }
        [Display(Name = "drugtype")]
        public bool? Drugtype { get; set; }
        [Display(Name = "drugname")]
        public string? Drugname { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd H:mm:ss}")]
        [Display(Name = "recorded_at")]
        public DateTime? Recorded_at { get; set; }
    }

    [NotMapped]//加上這個是為了在swagger，顯示不會加到DB裡面
    public class UserA1cViewModel
    {
        [Display(Name = "a1c")]
        public decimal? A1c_v { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd H:mm:ss}")]
        [Display(Name = "recorded_at")]
        public DateTime? Recorded_at { get; set; }
    }
    
    [NotMapped]//加上這個是為了在swagger，顯示不會加到DB裡面
    public class UserMedicalViewModel
    {
        [Display(Name = "diabetes_type")]
        public int? Diabetes_type { get; set; }
        [Display(Name = "oad")]
        public bool? Oad { get; set; }
        [Display(Name = "insulin")]
        public bool? Insulin { get; set; }
        [Display(Name = "anti_hypertensives")]
        public bool? Anti_hypertensives { get; set; }
    }

    [NotMapped]//加上這個是為了在swagger，顯示不會加到DB裡面
    public class UserDrugUsedPostViewModel
    {
        [Display(Name = "drugtype")]
        public bool Drugtype { get; set; }
        [Display(Name = "drugname")]
        public string Drugname { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd H:mm:ss}")]
        [Display(Name = "recorded_at")]
        public DateTime Recorded_at { get; set; }
    }

    //以下為30. 就醫資訊
    [NotMapped]
    public class userMedicalInfoValue
    {
        public string? Status { get; set; }
        public MedicalValue? Medical_info { get; set; }
    }
    [NotMapped]
    public class MedicalValue
    {
        public int? Id { get; set; }
        public int? User_id { get; set; }
        public int? Diabetes_type { get; set; }
        public bool? Oad { get; set; }
        public bool? Insulin { get; set; }
        public bool? Anti_hypertensives { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
    }


    //以下為41.藥物資訊
    [NotMapped]
    public class userDrugUsedValue
    {
        public string? Status { get; set; }
        public List<DrugValue>? Drug_useds { get; set; }
    }
    [NotMapped]
    public class DrugValue
    {
        public int? Id { get; set; }
        public int? User_id { get; set; }
        public bool? Drugtype { get; set; }
        public string? Drugname { get; set; }
        public DateTime? Recorded_at { get; set; }
    }
}
