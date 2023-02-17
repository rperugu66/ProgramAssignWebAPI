using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
namespace ProgramAssignWebAPI.SendEmail
{
    public static class Email
    {
        public static void SendMailsToClient(string SmtpClientName, int SmtpPort, string Subject, string Body, string FromEmail, string FromEmailPassword, string[] ToEmails, string[] CCEmails = null, bool EnableSsl = true, string[] Attachments = null)
        {
            var smtpClient = new SmtpClient(); 
            smtpClient.UseDefaultCredentials = false; smtpClient.Credentials = new NetworkCredential(FromEmail, FromEmailPassword);
            smtpClient.Host = SmtpClientName;
            smtpClient.Port = 587; 
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network; 
            smtpClient.EnableSsl = true; var mailMessage = new MailMessage { From = new MailAddress(FromEmail, "ValueMomentum Insurance"), Subject = Subject, Body = Body, IsBodyHtml = true, }; 
            if (ToEmails != null && ToEmails.Length > 0) { foreach (string toEmail in ToEmails) { mailMessage.To.Add(toEmail); } }
            if (CCEmails != null && CCEmails.Length > 0) { foreach (string ccEmail in CCEmails) { mailMessage.CC.Add(ccEmail); } }
            if (Attachments != null && Attachments.Length > 0) { foreach (string AttachmentFile in Attachments) { mailMessage.Attachments.Add(new Attachment(AttachmentFile)); } }
            smtpClient.Send(mailMessage);
        }
    }
}