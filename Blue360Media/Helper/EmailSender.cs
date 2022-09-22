//using AE.Net.Mail.Imap;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
//using System.Web.UI.WebControls;

namespace Blue360Media
{
    public class EmailSender
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string ReceiverEmail { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
        public bool EnableSsl { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string AttachmentFile { get; set; }

        public string ClientName { get; set; }
        public string ClientEmail { get; set; }

        [Obsolete]
        public EmailSender(/*string mailServer, int port, bool ssl, string login, string password*/)
        {
            Email = "parvind.vishwakarma@trivialworks.com";
            Password = "Trivial@123";
            Host = "smtp.gmail.com";
            Port = Convert.ToInt32(587);
            //Password = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["password"]);
            ReceiverEmail = "divyanshi.tiwari@trivialworks.com";
            ClientEmail = "divyanshi.tiwari@trivialworks.com";
            //AttachmentFile = @"D://A56CX14777Signed.cgm";
            DisplayName = "Blue360Media Email";
            Subject = "Mail From Blue360Media Related to Forgot Password";
            EnableSsl = true;
            IsBodyHtml = true;
            //Host = Convert.ToString(System.Configuration.ConfigurationSettings.AppSettings["host"]);
            //Port = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings["port"]);
            UseDefaultCredentials = true;

        }
        public static bool SendEmail(EmailSender emailSender)
        {

            MailAddress fromAddress = new MailAddress(emailSender.Email, emailSender.DisplayName);
            MailAddress toAddress = new MailAddress(emailSender.ClientEmail);
            SmtpClient smtpClient = new SmtpClient
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, emailSender.Password),
                Host = emailSender.Host,
                Port = emailSender.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
            MailMessage mailMessage = new MailMessage(fromAddress.Address, toAddress.Address, emailSender.Subject, emailSender.Body);
            //mailMessage.Attachments.Add(new Attachment(emailSender.AttachmentFile));
            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (SmtpException ex)
            {
                return false;
            }
        }
    }
}
