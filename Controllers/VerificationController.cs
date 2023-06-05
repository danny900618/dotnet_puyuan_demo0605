using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json.Linq;
using PuYuan_net7.Helpers;
using PuYuan_net7.Models;

namespace PuYuan_net7.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VerificationController : ControllerBase
    {
        private readonly PuYuanContext _context;
        private readonly SendEmailHelper _sendEmail;

        public VerificationController(PuYuanContext context, SendEmailHelper sendEmail, IPasswordHelper passwordHelper)
        {
            _context = context;
            _sendEmail = sendEmail;
        }

        // POST: api/verification/send
        /// <summary>
        /// 3.發送驗證碼
        /// </summary>
        /// <returns></returns>
        [HttpPost("send")]
        [AllowAnonymous]
        public async Task<ActionResult> PostUser(UserSendEmailViewModel userEmailck)
        {
            var SendFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return SendFail;
            }

            var user = _context.User.Single(x => x.Email == userEmailck.Email);
            if (user == null)
            {
                return SendFail;
            }

            //產生驗證碼
            double randomNum = RandomNumberGenerator.GetInt32(100000, 999999);
            //寄信驗證碼
            string body = new string("歡迎使用普元血糖app:\n請點選下列連結完成註冊:\n127.0.0.1:8000/api/check\n驗證碼: ");
            var SendResult = _sendEmail.Send(userEmailck.Email, randomNum, body);
            if (SendResult == "false")
            {
                return SendFail;
            }

            //新增驗證碼到DB
            //var result = _context.User.SingleOrDefault(b => b.Verifycode == null);
            user.Verifycode = randomNum.ToString();
            _context.SaveChanges();
            return new JsonResult(new { status = 0 });
        }

        // POST: api/verification/check
        /// <summary>
        /// 4.檢查驗證碼
        /// </summary>
        /// <returns></returns>
        [HttpPost("check")]
        public async Task<ActionResult> Postcheck(UserCodeckViewModel sendCheck)
        {
            var CheckFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return CheckFail;
            }
            //var user = _context.User.Single(x => x.Account == User.Identity.Name);
            var user = _context.User.Single(x => x.Account == User.Identity.Name);
            if (user.Verifycode != sendCheck.Code)
            {
                return CheckFail;
            }
            return new JsonResult(new { status = 0 });
        }
    }
}
