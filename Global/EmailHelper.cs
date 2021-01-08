using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Global
{
    public static class EmailHelper
    {
        public static void SendAddressValidate(string address, string authCode)
        {
            MailMessage mail = new MailMessage
            {
                From = new MailAddress("feige_20200214@163.com"),
                Subject = "激活Email",
                Body = $"感谢你的激活Email，你的验证码是：{authCode}",
                IsBodyHtml = true  //最终呈现样式由收件服务器决定
            };
            mail.To.Add(address);
            SmtpClient client = new SmtpClient
            {
                Host = "smtp.163.com",
                Port = 25,
                Credentials = new NetworkCredential("feige_20200214", "yz17bang"),
                EnableSsl = false
            };
            client.Send(mail);
        }
    }
}
