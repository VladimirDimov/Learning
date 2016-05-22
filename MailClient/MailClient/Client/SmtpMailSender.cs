using MailClient.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailClient.Smtp
{
    class SmtpMailSender
    {
        private SmtpClient client = new SmtpClient();
        private SmtpSettings settings;
        private object userToken = new object();

        public SmtpMailSender(SmtpSettings settings)
        {
            this.settings = settings;
            client.Host = settings.Host;
            client.Port = settings.Port;
            client.EnableSsl = settings.EnableSSL;
            client.Credentials = new NetworkCredential(settings.Credentials.Username, settings.Credentials.Password);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        public SendMailResult Send(string[] to, string from, string subject, string body)
        {
            MailMessage message = this.CreateMailMessage(to, from, subject, body);

            try
            {
                this.client.Send(message);
            }
            catch (Exception ex)
            {
                return new SendMailResult { Error = ex.Message };
            }
            finally
            {
                this.client.Dispose();
                message.Dispose();
            }

            return new SendMailResult { Success = "Message successfully sent" };
        }

        public Task<SendMailResult> SendAsync(string[] to, string from, string subject, string body)
        {
            return Task.Factory.StartNew(() =>
            {
                return this.Send(to, from, subject, body);
            });
        }

        private MailMessage CreateMailMessage(string[] to, string from, string subject, string body)
        {
            var mailMessage = new MailMessage();

            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.From = new MailAddress(from);

            foreach (var receiver in to)
            {
                mailMessage.To.Add(new MailAddress(receiver));
            }

            return mailMessage;
        }
    }
}
