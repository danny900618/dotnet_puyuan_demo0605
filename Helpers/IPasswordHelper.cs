namespace PuYuan_net7.Helpers
{
    public interface IPasswordHelper
    {
        string HashPassword(string password);//註冊
        bool VerifyPassword(string password, string hashedPassword);//登入驗證密碼
    }
}
