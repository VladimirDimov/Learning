using MailClient.Client;
using MailClient.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailClient
{
    class Program
    {
        static void Main()
        {
            SendMail();
            Console.WriteLine("Sending mail");
            Console.ReadLine();
        }

        private async static void SendMail()
        {
            var settings = new SmtpSettings();
            settings.Host = "smtp-pulse.com";
            settings.EnableSSL = false;
            settings.Port = 2525;
            settings.Credentials = new Credentials { Username = "register2016@abv.bg", Password = "EBFQ4cFL7ET" };

            var client = new SmtpMailSender(settings);

            var result = await client.SendAsync(new string[] { "register2016@abv.bg" }, "register2016@abv.bg", "test", "test body");
            Console.WriteLine(result);
        }
    }
}
