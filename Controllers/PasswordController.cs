using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuYuan_net7.Helpers;
using PuYuan_net7.Models;

namespace PuYuan_net7.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly PuYuanContext _context;
        private readonly SendEmailHelper _sendEmail;
        private readonly IPasswordHelper _passwordHelper;

        public PasswordController(PuYuanContext context, SendEmailHelper sendEmail, IPasswordHelper passwordHelper)
        {
            _context = context;
            _sendEmail = sendEmail;
            _passwordHelper = passwordHelper;
        }

        // POST: api/password/forgot
        /// <summary>
        /// 5.忘記密碼
        /// </summary>
        /// <returns></returns>
        [HttpPost("forgot")]
        [AllowAnonymous]
        public async Task<ActionResult> PostUser(UserForgotViewModel forgotpwd)
        {
            var SendFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return SendFail;
            }

            var user = _context.User.Single(x => x.Email == forgotpwd.Email);
            if (user == null)
            {
                return SendFail;
            }

            //產生密碼
            double newPwd = RandomNumberGenerator.GetInt32(10000000, 99999999);
            //寄信驗證碼
            string body = new string("這是您的新密碼: ");
            var SendResult = _sendEmail.Send(forgotpwd.Email, newPwd, body);
            if (SendResult == "false")
            {
                return SendFail;
            }

            //新增驗證碼到DB
            //var result = _context.User.SingleOrDefault(b => b.Password != null);
            user.Password = newPwd.ToString();
            _context.SaveChanges();
            return new JsonResult(new { status = 0 });
        }

        // POST: api/password/reset
        /// <summary>
        /// 6.重設密碼
        /// </summary>
        /// <returns></returns>
        [HttpPost("reset")]
        public async Task<ActionResult> PostReset(UserResetViewModel resetpwd)
        {
            var ResetFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return ResetFail;
            }
            var user = _context.User.Single(x => x.Account == User.Identity.Name);
            if (user.Password != resetpwd.Password)
            {
                return ResetFail;
            }
            user.Password = _passwordHelper.HashPassword(resetpwd.Newpassword);
            _context.SaveChanges();
            return new JsonResult(new { status = 0 });
        }
    }
}
