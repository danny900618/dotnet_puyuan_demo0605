using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuYuan_net7.Models;
using PuYuan_net7.Helpers;
using System.Reflection;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace PuYuan_net7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly PuYuanContext _context;
        private readonly IPasswordHelper _passwordHelper;
        //把已經註冊到program的服務"注入"到這邊
        public RegisterController(PuYuanContext context, IPasswordHelper passwordHelper)
        {
            _context = context;
            _passwordHelper = passwordHelper;
        }

        // POST: api/register
        /// <summary>
        /// 1.註冊
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PostUser(UserViewModel userRegister)
        {
            var registerFail = new JsonResult(new { status = 1 });

            var user = new User();

            foreach (var propertyInfo in userRegister.GetType().GetProperties())
            {
                var value = propertyInfo.GetValue(userRegister);

                if (value != null)
                {
                    var property = typeof(User).GetProperty(propertyInfo.Name);
                    property.SetValue(user, value, null);
                }
            }
            string uid = Guid.NewGuid().ToString();
            user.Uid = uid;
            user.Created_at = DateTime.Now.Date;
            user.Password = _passwordHelper.HashPassword(user.Password);
            _context.User.Add(user);

            var F = new Friend();
            double newPwd = RandomNumberGenerator.GetInt32(100000, 999999);
            F.Uid = uid;
            F.Invite_code = newPwd.ToString();
            _context.Friends.Add(F);

            var M = new Medical();
            M.Uid = uid;
            M.Account = userRegister.Account;
            _context.Medical.Add(M);

            var US = new UserSet();
            US.Uid = uid;
            US.Account = userRegister.Account;
            _context.UserSet.Add(US);

            var W = new Weight_M();
            W.Uid = uid;
            _context.Weight.Add(W);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch
            {
                return registerFail;
            }
            return new JsonResult(new { status = 0 });
        }

        // GET: api/register/check
        /// <summary>
        /// 38.註冊確認
        /// </summary>
        /// <returns></returns>
        [HttpGet("check")]
        public async Task<ActionResult> GetUser(string account)
        {
            var checkFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return checkFail;
            }


            var user = _context.User.Single(b => b.Account == User.Identity.Name);
            //Console.Write(user);
            if (user == null)
            {
                return checkFail;
            }
            if (_context.Entry(user).Property<bool>("Enabled").CurrentValue)//這是抓DB物件的方法，如果Enabled欄位為True，就會進到裡面回傳0
            {
                return new JsonResult(new { status = 0 });
            }

            return checkFail;
        }
    }
}
