using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PuYuan_net7.Models
{
    public class Friend
    {
        [Key]
        [Display(Name = "id")]
        public int ID { get; set; }
        [Display(Name = "uid")]
        public string Uid { get; set; }
        [Display(Name = "invite_code")]
        public string? Invite_code { get; set; }
        [Display(Name = "relation_id")]
        public string? Relation_id { get; set; }
        [Display(Name = "friend_type")]
        public int? Friend_type { get; set; }
        [Display(Name = "status")]
        public string? Status { get; set; }
        [Display(Name = "read")]
        public bool? Read { get; set; }
        [Display(Name = "imread")]
        public bool? Imread { get; set; }
    }

    [NotMapped]
    public class FriendSendViewModel
    {
        [Display(Name = "type")]
        public int Type { get; set; }
        [Display(Name = "invite_code")]
        public String Invite_code { get; set; }
    }
    [NotMapped]
    public class FriendNotificationViewModel
    {
        [Display(Name = "message")]

        public String Message { get; set; }
    }


    //以下為26. 控糖團結果
    [NotMapped]
    public class userFriendsValue
    {
        public string? Status { get; set; }
        public List<ResultsValue>? Results { get; set; }
    }
    [NotMapped]
    public class ResultsValue
    {
        public int? Id { get; set; }
        public int? User_id { get; set; }
        public string? Relation_id { get; set; }
        public int? Friend_type { get; set; }
        public string? Status { get; set; }
        public bool? Read { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public RelationValue? Relation { get; set; }
    }
    [NotMapped]
    public class RelationValue
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
        public string? Unread_records { get; set; }
        public bool? Verified { get; set; }
        public bool? Privacy_policy { get; set; }
        public bool? Must_change_password { get; set; }
        public int? Badge { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
    }


    //以下為17.控糖團列表
    [NotMapped]
    public class UserFriendListValue
    {
        public string? Status { get; set; }
        public List<FriendsValue>? Friends { get; set; }
    }
    [NotMapped]
    public class FriendsValue
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
        public bool? Verified { get; set; }
        public bool? Privacy_policy { get; set; }
        public bool? Must_change_password { get; set; }
        public int? Badge { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public int? Relation_type { get; set; }
    }

    //以下為18.獲取控糖團邀請
    [NotMapped]
    public class FriendRequestsValue
    {
        public string? Status { get; set; }
        public List<RequestValue>? Requests { get; set; }
    }
    [NotMapped]
    public class RequestValue
    {
        public int? Id { get; set; }
        public int? User_id { get; set; }
        public string? Relation_id { get; set; }
        public int? Friend_type { get; set; }
        public string? Status { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
        public UserValue? User { get; set; }
    }

        [NotMapped]
    public class UserValue
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
        public bool? Verified { get; set; }
        public bool? Privacy_policy { get; set; }
        public bool? Must_change_password { get; set; }
        public int? Badge { get; set; }
        public DateTime? Created_at { get; set; }
        public DateTime? Updated_at { get; set; }
    }
}
