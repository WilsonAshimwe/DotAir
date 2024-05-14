using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DotAir.BLL.Infrastructure
{
    public class Mailer(SmtpClient _smtpClient, Mailer.MailerConfig _config)
    {
        public class MailerConfig
        {
            public required string Server { get; init; }
            public required int Port { get; init; }
            public required string Username { get; init; }
            public required string Password { get; init; }
        }

        public void Send(
            string to, string subject, string html, params Attachment[] attachments
        )
        {
            _smtpClient.Host = _config.Server;
            _smtpClient.Port = _config.Port;
            _smtpClient.Credentials = new NetworkCredential
                (_config.Username, _config.Password);
            _smtpClient.EnableSsl = true;


            MailMessage mailMessage = new MailMessage();
            mailMessage.Subject = subject;
            mailMessage.Body = html;
            mailMessage.IsBodyHtml = true;
            mailMessage.From = new MailAddress("noreply@dotair.com");
            mailMessage.To.Add(to);
            foreach (var item in attachments)
            {
                mailMessage.Attachments.Add(item);
            }
            _smtpClient.Send(mailMessage);
        }
    }
}
