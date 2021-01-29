using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ehaikerv202010
{
    public static class SendMail
    {
        //发送邮件通知
        public static bool SendEmail(string email, string noticestring, string Subjectstring)
        {
            try
            {
                MailMessage mailmsg = new MailMessage();
                mailmsg.From = new MailAddress("lixingshunnick@126.com");
                mailmsg.To.Add(email);
                mailmsg.Subject = Subjectstring;
                StringBuilder contentBuilder = new StringBuilder();
                contentBuilder.Append(Subjectstring);
                contentBuilder.Append(noticestring);

                // HtmlEncode();

                mailmsg.Body = contentBuilder.ToString();
                mailmsg.IsBodyHtml = true;
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.126.com";
                client.Port = 25;
                NetworkCredential credetial = new NetworkCredential();
                credetial.UserName = "lixingshunnick";
                credetial.Password = "ehaiker126";
                client.Credentials = credetial;
                client.Send(mailmsg);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
