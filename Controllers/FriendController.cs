using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuYuan_net7.Models;

namespace PuYuan_net7.Controllers
{
    [Authorize] //需要授權才能使用
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly PuYuanContext _context;

        public FriendController(PuYuanContext context)
        {
            _context = context;
        }

        // POST: api/friend/send
        /// <summary>
        /// 19.送出控糖團邀請
        /// </summary>
        /// <returns></returns>
        [HttpPost("send")]
        //[AllowAnonymous]//可能會有例外(不用登入即可使用
        public async Task<ActionResult> PostFriend(FriendSendViewModel friendSend)
        {
            var postFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return postFail;
            }

            var me = _context.User.Single(x => x.Account == User.Identity.Name);
            var user = _context.Friends.Single(x => x.Uid == me.Uid);
            if (user == null)
            {
                return postFail;
            }

            //發送的邀請碼是否和該朋友的邀請碼相同
            var friend =_context.Friends.Single(x => x.Invite_code == friendSend.Invite_code);
            if (friend == null)
            {
                return postFail;
            }

            user.Relation_id = friendSend.Invite_code;
            _context.SaveChanges();
            return new JsonResult(new { status = 0 });
        }

        // GET: api/friend/邀請id(不是會員id)/accept
        /// <summary>
        /// 20.接受控糖團邀請
        /// </summary>
        /// <returns></returns>
        [HttpGet("id/accept")]
        //[AllowAnonymous]//可能會有例外(不用登入即可使用
        public async Task<ActionResult> GetFriendAccept()
        {
            var getFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return getFail;
            }

            //自己
            var me = _context.User.Single(x => x.Account == User.Identity.Name);
            var user = _context.Friends.Single(x => x.Uid == me.Uid);
            if (user == null)
            {
                return getFail;
            }

            //找到該朋友查看邀請碼是否和邀請自己的一樣
            var friend =_context.Friends.Single(x => x.Invite_code == user.Relation_id);
            if (friend == null)
            {
                return getFail;
            }

            //修改接受條件
            user.Relation_id = friend.Uid;
            user.Read = true;
            user.Status = "1";
            _context.SaveChanges();
            return new JsonResult(new { status = 0 });
        }

        // GET: api/friend/邀請id(不是會員id)/refuse
        /// <summary>
        /// 21.拒絕控糖團邀請
        /// </summary>
        /// <returns></returns>
        [HttpGet("id/refuse")]
        //[AllowAnonymous]//可能會有例外(不用登入即可使用
        public async Task<ActionResult> GetFriendRefuse()
        {
            var getFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return getFail;
            }

            //自己
            var me = _context.User.Single(x => x.Account == User.Identity.Name);
            var user = _context.Friends.Single(x => x.Uid == me.Uid);
            if (user == null)
            {
                return getFail;
            }

            //找到該朋友查看邀請碼是否和邀請自己的一樣
            var friend =_context.Friends.Single(x => x.Invite_code == user.Relation_id);
            if (friend == null)
            {
                return getFail;
            }

            //修改接受條件
            user.Relation_id = null;
            user.Read = true;
            user.Status = "2";
            _context.SaveChanges();
            return new JsonResult(new { status = 0 });
        }


        // GET: api/friend/邀請id(不是會員id)/remove
        /// <summary>
        /// 22.刪除控糖團邀請
        /// </summary>
        /// <returns></returns>
        [HttpGet("id/remove")]
        //[AllowAnonymous]//可能會有例外(不用登入即可使用
        public async Task<ActionResult> GetFriendRemove()
        {
            var getFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return getFail;
            }

            //自己
            var me = _context.User.Single(x => x.Account == User.Identity.Name);
            var user = _context.Friends.Single(x => x.Uid == me.Uid);
            if (user == null)
            {
                return getFail;
            }
            user.Relation_id = null;
            user.Read = false;
            user.Status =null;
            _context.SaveChanges();
            return new JsonResult(new { status = 0 });
        }

        // GET: api/friend/code
        /// <summary>
        /// 16.獲取控糖團邀請碼
        /// </summary>
        /// <returns></returns>
        [HttpGet("code")]
        //[AllowAnonymous]//可能會有例外(不用登入即可使用
        public async Task<InvitecodeValue> GetFriendcode()
        {
            try
            {
                var me = _context.User.Single(x => x.Account == User.Identity.Name);
                var user = _context.Friends.Single(x => x.Uid == me.Uid);
                var result = new InvitecodeValue
                {
                    Status = "0",
                    invite_code = user.Invite_code
                };
                return result;
            }
            catch
            {
                var result = new InvitecodeValue
                {
                    Status = "1"
                };
                return result;
            }
        }

        // POST: api/notification
        /// <summary>
        /// 36.親友團通知
        /// </summary>
        /// <returns></returns>
        [HttpPost("api/notification")]
        //[AllowAnonymous]//可能會有例外(不用登入即可使用
        public async Task<ActionResult> PostNotification(FriendNotificationViewModel userMessage)
        {
            var postFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return postFail;
            }

            //自己
            var user = _context.User.Single(x => x.Account == User.Identity.Name);
            if (user == null)
            {
                return postFail;
            }
            user.Message = userMessage.Message;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return postFail;
            }
            return new JsonResult(new { status = 0 });
        }
        // DELETE: api/friend/remove
        /// <summary>
        /// 37.刪除更多好友
        /// </summary>
        /// <returns></returns>
        [HttpDelete("remove")]
        //[AllowAnonymous]//可能會有例外(不用登入即可使用
        public async Task<ActionResult> DeleteFriendRemove()
        {
            var deleteFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return deleteFail;
            }

            //自己
            var me = _context.User.Single(x => x.Account == User.Identity.Name);
            var user = _context.Friends.Single(x => x.Uid == me.Uid);
            if (user == null)
            {
                return deleteFail;
            }
            else if (user.Status == "1" && user.Relation_id != null)
            {
                user.Relation_id = null;
                user.Status = null;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return deleteFail;
            }
            return new JsonResult(new { status = 0 });
        }

        // GET: api/friend/results
        /// <summary>
        /// 26. 控糖團結果
        /// </summary>
        /// <returns></returns>
        [HttpGet("results")]
        public async Task<userFriendsValue> GetResult()
        {
            try
            {
                var user = _context.User.Single(x => x.Account == User.Identity.Name);
                var userself = _context.Friends.Single(x => x.Uid == user.Uid);
                var userTime = _context.Weight.Single(x => x.Uid == user.Uid);
                var userfriend = _context.User.Single(x => x.Uid == userself.Relation_id);
                //var userFriends = _context.Friends.Where(x => x.Uid == user.Uid).OrderBy(x => x.ID).ToArray();
                List<ResultsValue> results = new List<ResultsValue>();
                var userfriendInfo = new RelationValue()
                {
                    Id = userfriend.ID,
                    Name = userfriend.Name,
                    Account = userfriend.Account,
                    Email = userfriend.Email,
                    Phone = userfriend.Phone,
                    Fb_id = "1",
                    Satus = "Normal",
                    Group = null,
                    Birthday = userfriend.Birthday,
                    Height = userfriend.Height,
                    Gender = userfriend.Gender,
                    Unread_records = "[0,0,0]",
                    Verified = true,
                    Privacy_policy = true,
                    Must_change_password = true,
                    Badge = 87,
                    Created_at = userTime.Recorded_at,
                    Updated_at = userTime.Recorded_at
                };
                var UserInfo = new ResultsValue()
                {
                    Id = userself.ID,
                    User_id = userself.ID,
                    Relation_id = userself.Relation_id,
                    Friend_type = userself.Friend_type,
                    Status = userself.Status,
                    Read = userself.Read,
                    Created_at = userTime.Recorded_at,
                    Updated_at = userTime.Recorded_at,
                    Relation = userfriendInfo
                };
                results.Add(UserInfo);

                var friendresult = new userFriendsValue
                {
                    Status = "0",
                    Results = results
                };
                return friendresult;
            }
            catch
            {
                var friendresult = new userFriendsValue
                {
                    Status = "1"
                };
                return friendresult;
            }
        }

        // GET: api/friend/list
        /// <summary>
        /// 17.控糖團列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<UserFriendListValue> GetFriendList()
        {
            try
            {
                var user = _context.User.Single(x => x.Account == User.Identity.Name);
                var userFriends = _context.Friends.Where(x => x.Uid == user.Uid & x.Relation_id != null).OrderBy(x => x.ID).ToArray();
                List<FriendsValue> results = new List<FriendsValue>();
                foreach (var user_uid in userFriends)
                {
                    var userInfo = _context.User.Single(x => x.Uid == user_uid.Relation_id);
                    var friendsInfo = new FriendsValue()
                    {
                        Id = userInfo.ID,
                        Name = userInfo.Name,
                        Account = userInfo.Account,
                        Email = userInfo.Email,
                        Phone = userInfo.Phone,
                        Fb_id = "1",
                        Satus = "Normal",
                        Group = null,
                        Birthday = userInfo.Birthday,
                        Height = userInfo.Height,
                        Gender = userInfo.Gender,
                        Verified = true,
                        Privacy_policy = true,
                        Must_change_password = true,
                        Badge = 87,
                        Created_at = userInfo.Created_at,
                        Updated_at = userInfo.Created_at,
                        Relation_type = 1
                    };
                    results.Add(friendsInfo);
                }
                var friendresult = new UserFriendListValue
                {
                    Status = "0",
                    Friends = results
                };
                return friendresult;
            }
            catch
            {
                var friendresult = new UserFriendListValue
                {
                    Status = "1"
                };
                return friendresult;
            }
        }

        // GET: api/friend/requests
        /// <summary>
        /// 18.獲取控糖團邀請
        /// </summary>
        /// <returns></returns>
        [HttpGet("requests")]
        public async Task<FriendRequestsValue> GetRequests()
        {
            try
            {
                var user = _context.User.Single(x => x.Account == User.Identity.Name);
                var userself = _context.Friends.Single(x => x.Uid == user.Uid);
                var userFriends = _context.Friends.Where(x => x.Uid == user.Uid & x.Relation_id != null).OrderBy(x => x.ID).ToArray();
                List<RequestValue> results = new List<RequestValue>();
                foreach (var user_uid in userFriends)
                {
                    var userInfo = _context.User.Single(x => x.Uid == user_uid.Relation_id);

                    var userdata = new UserValue()
                    {
                        Id = userInfo.ID,
                        Name = userInfo.Name,
                        Account = userInfo.Account,
                        Email = userInfo.Email,
                        Phone = userInfo.Phone,
                        Fb_id = "1",
                        Satus = "Normal",
                        Group = null,
                        Birthday = userInfo.Birthday,
                        Height = userInfo.Height,
                        Gender = userInfo.Gender,
                        Verified = true,
                        Privacy_policy = true,
                        Must_change_password = true,
                        Badge = 87,
                        Created_at = userInfo.Created_at,
                        Updated_at = userInfo.Created_at,
                    };
                    var UserInfo = new RequestValue()
                    {
                        Id = userself.ID,
                        User_id = userself.ID,
                        Relation_id = userself.Relation_id,
                        Friend_type = userself.Friend_type,
                        Status = userself.Status,
                        Created_at = user.Created_at,
                        Updated_at = user.Created_at,
                        User = userdata

                    };
                    results.Add(UserInfo);
                }
                var friendresult = new FriendRequestsValue
                {
                    Status = "0",
                    Requests = results
                };
                return friendresult;
            }
            catch
            {
                var friendresult = new FriendRequestsValue
                {
                    Status = "1"
                };
                return friendresult;
            }
        }
    }

}
