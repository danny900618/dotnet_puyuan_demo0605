using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PuYuan_net7.Models
{
    public class User
    {
        [Key]
        [Display(Name = "id")]
        public int ID { get; set; }
        [Display(Name = "uid")]
        public string Uid { get; set; }

        [Display(Name = "account")]
        public string Account { get; set; }
        [Required]
        [Display(Name = "password")]
        public string Password { get; set; }
        [Phone]
        [Display(Name = "phone")]
        public string? Phone { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "email")]
        public string? Email { get; set; }
        [Display(Name = "name")]
        public string? Name { get; set; }

        [Display(Name = "birthday")]
        public string? Birthday { get; set; }
        [Display(Name = "height")]
        public double? Height { get; set; }
        [Display(Name = "gender")]
        public bool? Gender { get; set; }

        [Display(Name = "fcm_id")]
        public string? Fcm_id { get; set; }
        [Display(Name = "address")]
        public string? Address { get; set; }
        [Display(Name = "weight")]
        public double? Weight { get; set; }
        [DefaultValue(0)]
        [Display(Name = "verifycode")]
        public string? Verifycode{ get; set; }
        [Display(Name = "message")]
        public string? Message { get; set; }

        [Display(Name = "Created_at")]
        public DateTime? Created_at { get; set; }
    }

    [NotMapped]//加上這個是為了在swagger，顯示不會加到DB裡面
    public class UserViewModel
    {
        [Display(Name = "account")]
        public string Account { get; set; }
        [Required]
        [Display(Name = "password")]
        public string Password { get; set; }
        [Phone]
        [Display(Name = "phone")]
        public string? Phone { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "email")]
        public string Email { get; set; }
    }

    [NotMapped]//加上這個是為了在swagger，顯示不會加到DB裡面
    public class UserLoginViewModel
    {
        [Display(Name = "account")]
        public string Account { get; set; }
        [Required]
        [Display(Name = "password")]
        public string Password { get; set; }
    }

    [NotMapped]//加上這個是為了在swagger，顯示不會加到DB裡面
    public class UserInfoViewModel
    {
        [Display(Name = "email")]
        public string? Email { get; set; }
        [Display(Name = "name")]
        public string? Name { get; set; }
        [Display(Name = "birthday")]
        public string? Birthday { get; set; }
        [Display(Name = "height")]
        public double? Height { get; set; }
        [Display(Name = "gender")]
        public bool? Gender { get; set; }
        [Display(Name = "fcm_id")]
        public string? Fcm_id { get; set; }
        [Display(Name = "address")]
        public string? Address { get; set; }
        [Display(Name = "weight")]
        public double? Weight { get; set; }
        [Phone]
        [Display(Name = "phone")]
        public string? Phone { get; set; }
    }

    [NotMapped]
    public class UserSendEmailViewModel
    {
        [Display(Name = "email")]
        public string Email { get; set; }
        [Display(Name = "phone")]
        public string Phone { get; set; }
    }

    [NotMapped]
    public class UserEmailckViewModel
    {
        [Display(Name = "email")]
        public string Email { get; set; }
        [Display(Name = "phone")]
        public string Phone { get; set; }
    }

    [NotMapped]
    public class UserCodeckViewModel
    {
        [Display(Name = "code")]
        public string Code { get; set; }
        [Display(Name = "phone")]
        public string Phone { get; set; }
    }

    [NotMapped]
    public class UserForgotViewModel
    {
        [Display(Name = "email")]
        public string Email { get; set; }
        [Display(Name = "phone")]
        public string Phone { get; set; }
    }

    [NotMapped]
    public class UserResetViewModel
    {
        [Display(Name = "password")]
        public string Password { get; set; }
        [Display(Name = "newpassword")]
        public string Newpassword { get; set; }
    }

    [NotMapped]
    public class DeleteUserRecordsViewModel
    {
        [Display(Name = "blood_sugars")]
        public int Blood_sugars { get; set; }
        [Display(Name = "blood_pressures")]
        public int Blood_pressures { get; set; }
        [Display(Name = "weights")]
        public int Weights { get; set; }

    }

    [NotMapped]
    public class UserCareViewModel
    {
        [Display(Name = "message")]
        public string Message { get; set; }
    }

    //以下為GetModels
    [NotMapped]
    public class UserLastUploadModel
    {
        public string Status { get; set; }
        //public Dictionary<string, LastUploadValue>? Last_upload { get; set; }
        public LastUploadValue Last_upload { get; set; }
    }
    [NotMapped]
    public class LastUploadValue
    {
        public int? Blood_pressure { get; set; }
        public double? Weight { get; set; }
        public int? Blood_sugar { get; set; }
        public DateTime? Diet { get; set; }
    }

    [NotMapped]
    public class RecordsViewModel
    {
        [Display(Name = "diets")]
        public int? Diets { get; set; }
    }

    //以下為44.上一筆紀錄資訊
    [NotMapped]
    public class RecordsValue
    {
        public string Status { get; set; }
        public RecordsBloodSugarValue Blood_sugars { get; set; }
        public RecordsBloodPressuresValue Blood_pressures { get; set; }
        public RecordsWeightsValue Weights { get; set; }
    }
    [NotMapped]
    public class RecordsBloodSugarValue
    {
        public int? Sugar { get; set; }
        public int? Exercise { get; set; }
        public int? Drug { get; set; }
        public int? Timeperiod { get; set; }
        public DateTime? Recorded_at { get; set; }

    }
    [NotMapped]
    public class RecordsBloodPressuresValue
    {
        public double? Systolic { get; set; }
        public double? Diastolic { get; set; }
        public int? Pulse { get; set; }
        public DateTime? Recorded_at { get; set; }
    }
    [NotMapped]
    public class RecordsWeightsValue
    {
        public double? Weight { get; set; }
        public double? Body_fat { get; set; }
        public double? Bmi { get; set; }
        public DateTime? Recorded_at { get; set; }
    }

    //16.獲取控糖團邀請碼
    [NotMapped]
    public class InvitecodeValue
    {
        public string Status { get; set; }
        public String invite_code { get; set; }
    }

    //以下為12.個人資訊
    [NotMapped]
    public class userValue
    {
        public string? Status { get; set; }
        public UserInfoValue? User { get; set; }
    }
    [NotMapped]
    public class UserInfoValue
    {
        public int? Id { get; set; }
        public string? Account { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Fb_id { get; set; }
        public string? Satus { get; set; }
        public string? Group { get; set; }
        public string? Birthday { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public bool? Gender { get; set; }
        public string? Address { get; set; }
        public string[]? Unread_records { get; set; }
        public bool? Verified { get; set; }
        public bool? Privacy_policy { get; set; }
        public bool? Must_change_password { get; set; }
        public string? Fcm_id { get; set; }
        public int? Badge { get; set; }
        public int? Login_times { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public UserInfoDefaultValue? Default { get; set; }
        public UserInfoSettingValue? Setting { get; set; }
    }

    //[NotMapped]
    //public class UserInfoUnreadRecordsValue //list
    //{
    //    public string R1 { get; set; }
    //    public string R2{ get; set; }
    //    public string R3{ get; set; }
    //}
    [NotMapped]
    public class UserInfoDefaultValue //dict
    {
        public int? Id { get; set; }
        public int? User_id { get; set; }
        public decimal? Sugar_delta_max { get; set; }
        public decimal? Sugar_delta_min { get; set; }
        public decimal? Sugar_morning_max { get; set; }
        public decimal? Sugar_morning_min { get; set; }
        public decimal? Sugar_evening_max { get; set; }
        public decimal? Sugar_evening_min { get; set; }
        public decimal? Sugar_before_max { get; set; }
        public decimal? Sugar_before_min { get; set; }
        public decimal? Sugar_after_max { get; set; }
        public decimal? Sugar_after_min { get; set; }
        public decimal? Systolic_max { get; set; }
        public decimal? Systolic_min { get; set; }
        public decimal? Diastolic_max { get; set; }
        public decimal? Diastolic_min { get; set; }
        public decimal? Pulse_max { get; set; }
        public decimal? Pulse_min { get; set; }
        public decimal? Weight_max { get; set; }
        public decimal? Weight_min { get; set; }
        public decimal? Bmi_max { get; set; }
        public decimal? Bmi_min { get; set; }
        public decimal? Body_fat_max { get; set; }
        public decimal? Body_fat_min { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
    }
    [NotMapped]
    public class UserInfoSettingValue //dict
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public bool? After_recording { get; set; }
        public bool? No_recording_for_a_day { get; set; }
        public bool? Over_max_or_under_min { get; set; }
        public bool? After_meal { get; set; }
        public bool? Unit_of_sugar { get; set; }
        public bool? Unit_of_weight { get; set; }
        public bool? Unit_of_height { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
    }
    //以下為14.日記列表資料
    [NotMapped]
    public class userDiaryViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        [Display(Name = "date")]
        public string? Date { get; set; }
    }
    [NotMapped]
    public class userDiaryValue
    {
        public string? Status { get; set; }
        public List<UserDiaryBP>? Diary { get; set; }
    }

    [NotMapped]
    public class UserDiaryBP
    {
        public int? Id { get; set; }
        public int? User_id { get; set; }
        public double? Systolic { get; set; }
        public double? Diastolic { get; set; }
        public int? Pulse { get; set; }
        public DateTime? Recorded_at { get; set; }
        public string? Type { get; set; }
    }
    [NotMapped]
    public class UserDiaryW
    {
        public int? Id { get; set; }
        public int? User_id { get; set; }
        public double? Weight { get; set; }
        public double? Body_fat { get; set; }
        public double? Bmi { get; set; }
        public DateTime? Recorded_at { get; set; }
        public string? Type { get; set; }
    }
    [NotMapped]
    public class UserDiaryS
    {
        public int? Id { get; set; }
        public int? User_id { get; set; }
        public int? Sugar { get; set; }
        public int? timeperiod{get; set; }
        public DateTime? Recorded_at { get; set; }
        public string? Type { get; set; }
    }
    //以下為17.控糖團列表
    [NotMapped]
    public class userFriendListValue
    {
        public string? Status { get; set; }
        public UserFriendsInfo? Friends { get; set; }
    }
    [NotMapped]
    public class UserFriendsInfo
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Account { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Fb_id { get; set; }
        public string? Satus { get; set; }
        public string? Group { get; set; }
        public string? Birthday { get; set; }
        public double? Height { get; set; }
        public bool? Gender { get; set; }
        public string? Address { get; set; }
        public bool? Verified { get; set; }
        public bool? Privacy_policy { get; set; }
        public bool? Must_change_password { get; set; }
        public int? Badge { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public int? Relation_type { get; set; }
    }

    //以下為27. 獲取關懷諮詢
    [NotMapped]
    public class userCareValue
    {
        public string? Status { get; set; }
        public List<CareValue>? Cares { get; set; }
    }
    [NotMapped]
    public class CareValue
    {
        public int? Id { get; set; }
        public int? User_id { get; set; }
        public int? member_id { get; set; }
        public int? Reply_id { get; set; }
        public string? message { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
    }
}
