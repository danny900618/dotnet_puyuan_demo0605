using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PuYuan_net7.Helpers;
using PuYuan_net7.Models;

namespace PuYuan_net7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly PuYuanContext _context;
        private readonly IPasswordHelper _passwordHelper;
        private readonly JwtHelper jwt;

        public AuthController(PuYuanContext context, IPasswordHelper passwordHelper, JwtHelper jwt)
        {
            _context = context;
            _passwordHelper = passwordHelper;
            this.jwt = jwt;
        }

        // POST: api/auth   
        /// <summary>
        /// 2.登入 
        /// </summary>
        /// <returns></returns>
        [HttpPost]//在影片的一小時左右開始講解HELPERS的jwt相關驗證
        public async Task<ActionResult<User>> PostUser(UserLoginViewModel userLogin)
        {
            var loginFail = new JsonResult(new { status = 1 });
            if (_context.User == null)
            {
                return loginFail;
            }

            var user = _context.User.Single(b => b.Account == userLogin.Account);
            //var user1 = await _context.User.FindAsync(userLogin.Account);

            if (user == null)
            {
                return loginFail;
            }
            if (!_context.Entry(user).Property<bool>("Enabled").CurrentValue)
            {
                return new JsonResult(new { status = 2 });
            }
            if (_passwordHelper.VerifyPassword(userLogin.Password, user.Password))
            {
                string token = jwt.GenerateToken(user.Account);
                return new JsonResult(new { status = 0, token });
            }
            return loginFail;
        }
        //record LoginViewModel(string Username, string Password);
    }
}
