using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System.Net.Mail;
using System;
using MailKit;
using SmtpClient = System.Net.Mail.SmtpClient;
using System.Net;
using PuYuan_net7.Models;

namespace PuYuan_net7.Helpers
{
    public class SendEmailHelper
    {
        private readonly string _emailusername;
        private readonly string _emailpassword;
        //把已經註冊到program的服務"注入"到這邊
        public SendEmailHelper(IConfiguration configuration)
        {            
            _emailusername = configuration.GetValue<string>("SMTP:username");
            _emailpassword = configuration.GetValue<string>("SMTP:password");
        }
        public string Send(string useremail, double randomNum, string body)
        {
            MailAddress fromAddress = new MailAddress(_emailusername);
            MailAddress toAddress = new MailAddress(useremail);
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(_emailusername, _emailpassword);
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage mailMessage = new 
            MailMessage(fromAddress.Address, toAddress.Address, "普元認證", body + randomNum);
            try
            {
                smtpClient.Send(mailMessage);
                return "true";
            }
            catch (SmtpException ex)
            {
                return "false";
            }
        }
    }
}
