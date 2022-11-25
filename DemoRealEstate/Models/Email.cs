using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net.Mime;
using System.Configuration;

namespace DemoRealEstate.Models
{
    public class Email
    {
        public string To { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }

        public void SendMail()
        {
            MailMessage mc = new MailMessage();
            mc.From = new MailAddress(ConfigurationManager.AppSettings["Email"].ToString());
            mc.To.Add(new MailAddress(To));
            mc.Subject = Subject;
            mc.Body = Body;
            mc.IsBodyHtml = false;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["Email"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = true;
            smtpClient.Send(mc);
        }
    }
}