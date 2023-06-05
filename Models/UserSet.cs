using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuYuan_net7.Models
{
    public class UserSet
    {
        [Key]
        [Display(Name = "account")]
        public string Account { get; set; }
        [Display(Name = "uid")]
        public string Uid { get; set; }

        [Display(Name = "sugar_delta_max")]
        public decimal? Sugar_delta_max { get; set; }
        [Display(Name = "sugar_delta_min")]
        public decimal? Sugar_delta_min { get; set; }
        [Display(Name = "sugar_morning_max")]
        public decimal? Sugar_morning_max { get; set; }
        [Display(Name = "sugar_morning_min")]
        public decimal? Sugar_morning_min { get; set; }
        [Display(Name = "sugar_evening_max")]
        public decimal? Sugar_evening_max { get; set; }
        [Display(Name = "sugar_evening_min")]
        public decimal? Sugar_evening_min { get; set; }
        [Display(Name = "sugar_before_max")]
        public decimal? Sugar_before_max { get; set; }
        [Display(Name = "sugar_before_min")]
        public decimal? Sugar_before_min { get; set; }
        [Display(Name = "sugar_after_max")]
        public decimal? Sugar_after_max { get; set; }
        [Display(Name = "sugar_after_min")]
        public decimal? Sugar_after_min { get; set; }
        [Display(Name = "systolic_max")]
        public decimal? Systolic_max { get; set; }
        [Display(Name = "systolic_min")]
        public decimal? Systolic_min { get; set; }
        [Display(Name = "diastolic_max")]
        public decimal? Diastolic_max { get; set; }
        [Display(Name = "diastolic_min")]
        public decimal? Diastolic_min { get; set; }
        [Display(Name = "pulse_max")]
        public decimal? Pulse_max { get; set; }
        [Display(Name = "pulse_min")]
        public decimal? Pulse_min { get; set; }
        [Display(Name = "weight_max")]
        public decimal? Weight_max { get; set; }
        [Display(Name = "weight_min")]
        public decimal? Weight_min { get; set; }
        [Display(Name = "bmi_max")]
        public decimal? Bmi_max { get; set; }
        [Display(Name = "bmi_min")]
        public decimal? Bmi_min { get; set; }
        [Display(Name = "body_fat_max")]
        public decimal? Body_fat_max { get; set; }
        [Display(Name = "body_fat_min")]
        public decimal? body_fat_min { get; set; }

        [Display(Name = "after_recording")]
        public bool? After_recording { get; set; }
        [Display(Name = "no_recording_for_a_day")]
        public bool? No_recording_for_a_day { get; set; }
        [Display(Name = "over_max_or_under_min")]
        public bool? Over_max_or_under_min { get; set; }
        [Display(Name = "after_meal")]
        public bool? After_meal { get; set; }
        [Display(Name = "unit_of_sugar")]
        public bool? Unit_of_sugar { get; set; }
        [Display(Name = "unit_of_weight")]
        public bool? Unit_of_weight { get; set; }
        [Display(Name = "unit_of_height")]
        public bool? Unit_of_height { get; set; }
    }

    public class Usertest
    {
        [Display(Name = "test")]
        public bool? Test { get; set; }
    }
        [NotMapped]
    public class UserSetViewModel
    {
        [Display(Name = "sugar_delta_max")]
        public decimal? Sugar_delta_max { get; set; }
        [Display(Name = "sugar_delta_min")]
        public decimal? Sugar_delta_min { get; set; }
        [Display(Name = "sugar_morning_max")]
        public decimal? Sugar_morning_max { get; set; }
        [Display(Name = "sugar_morning_min")]
        public decimal? Sugar_morning_min { get; set; }
        [Display(Name = "sugar_evening_max")]
        public decimal? Sugar_evening_max { get; set; }
        [Display(Name = "sugar_evening_min")]
        public decimal? Sugar_evening_min { get; set; }
        [Display(Name = "sugar_before_max")]
        public decimal? Sugar_before_max { get; set; }
        [Display(Name = "sugar_before_min")]
        public decimal? Sugar_before_min { get; set; }
        [Display(Name = "sugar_after_max")]
        public decimal? Sugar_after_max { get; set; }
        [Display(Name = "sugar_after_min")]
        public decimal? Sugar_after_min { get; set; }
        [Display(Name = "systolic_max")]
        public decimal? Systolic_max { get; set; }
        [Display(Name = "systolic_min")]
        public decimal? Systolic_min { get; set; }
        [Display(Name = "diastolic_max")]
        public decimal? Diastolic_max { get; set; }
        [Display(Name = "diastolic_min")]
        public decimal? Diastolic_min { get; set; }
        [Display(Name = "pulse_max")]
        public decimal? Pulse_max { get; set; }
        [Display(Name = "pulse_min")]
        public decimal? Pulse_min { get; set; }
        [Display(Name = "weight_max")]
        public decimal? Weight_max { get; set; }
        [Display(Name = "weight_min")]
        public decimal? Weight_min { get; set; }
        [Display(Name = "bmi_max")]
        public decimal? Bmi_max { get; set; }
        [Display(Name = "bmi_min")]
        public decimal? Bmi_min { get; set; }
        [Display(Name = "body_fat_max")]
        public decimal? Body_fat_max { get; set; }
        [Display(Name = "body_fat_min")]
        public decimal? body_fat_min { get; set; }
    }

    [NotMapped]
    public class UserSettingViewModel
    {
        [Display(Name = "after_recording")]
        public bool? After_recording { get; set; }
        [Display(Name = "no_recording_for_a_day")]
        public bool? No_recording_for_a_day { get; set; }
        [Display(Name = "over_max_or_under_min")]
        public bool? Over_max_or_under_min { get; set; }
        [Display(Name = "after_meal")]
        public bool? After_meal { get; set; }
        [Display(Name = "unit_of_sugar")]
        public bool? Unit_of_sugar { get; set; }
        [Display(Name = "unit_of_weight")]
        public bool? Unit_of_weight { get; set; }
        [Display(Name = "unit_of_height")]
        public bool? Unit_of_height { get; set; }
    }
}
