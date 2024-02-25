using OnlineCourse.Data.Model.Email;
using OnlineCourse.Services.Email.Interface;
using System.Net;
using System.Net.Mail;

namespace OnlineCourse.Services.Email
{
    public class EmailService : IEmailService
    {
        public EmailService() { }
        public void SendMail(SendMailModel model)
        {
            try
            {
                MailMessage mailMessage = new MailMessage()
                {
                    Subject = model.Sbuject,
                    Body = model.Content,
                    IsBodyHtml = false
                };
                mailMessage.From = new MailAddress(EmailSettingsModel.Instance.FromEmailAddress, EmailSettingsModel.Instance.FromDisplayName);
                mailMessage.To.Add(model.ReceiveAddress);

                var smtp = new SmtpClient()
                {
                    EnableSsl = EmailSettingsModel.Instance.Smtp.EnableSsl,
                    Host = EmailSettingsModel.Instance.Smtp.Host,
                    Port = EmailSettingsModel.Instance.Smtp.Port
                };

                var network = new NetworkCredential(EmailSettingsModel.Instance.Smtp.EmailAddress, EmailSettingsModel.Instance.Smtp.Password);
                smtp.Credentials = network;
                smtp.Send(mailMessage);
            } catch(Exception ex)
            {
                throw;
            }
        }
    }
}
