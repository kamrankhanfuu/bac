using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace BACAgent.Services
{
    public class EmailService
    {
        public void GmailSend(string from, string[] to, string subject, string body, bool isHtml = false)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(from);
            foreach (var address in to)
            {
                mailMessage.To.Add(address);
            }
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = isHtml;

            
            string value = System.Configuration.ConfigurationManager.AppSettings["gp"];

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("bacagentforms@gmail.com", value);
            smtpClient.Send(mailMessage);
        }

    }
}