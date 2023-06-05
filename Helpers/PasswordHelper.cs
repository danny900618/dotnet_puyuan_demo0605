using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using PuYuan_net7.Models;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PuYuan_net7.Helpers
{
    public class PasswordHelper : IPasswordHelper
    {
        private readonly string _hashkey;
        //把已經註冊到program的服務"注入"到這邊
        public PasswordHelper(IConfiguration configuration)
        {
            _hashkey = configuration.GetValue<string>("Secret:HashKey");
        }
        private string Hash(string password, byte[] salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8)
            );
        }

        public string HashPassword(string password)
        {
            byte[] salt = Encoding.UTF8.GetBytes(_hashkey); //產生幾個亂數
            return Convert.ToBase64String(salt) +":"+ Hash(password, salt);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            string[] passwordInfo = hashedPassword.Split(':');
            if (passwordInfo.Length !=2)
            {
                return false;
            }
            byte[] salt = Encoding.UTF8.GetBytes(_hashkey);
            if (Hash(password, salt) == passwordInfo[1])
            {
                return true;
            }
            return false;
        }
    }
}
