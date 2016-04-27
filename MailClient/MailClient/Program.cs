namespace MailClient
{
    using MailClient.Client;
    using MailClient.Smtp;
    using System;

    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Sending mail");
            SendMailAsync();
            Console.ReadLine();
        }

        private async static void SendMailAsync()
        {
            var settings = new SmtpSettings();
            settings.Host = "smtp-pulse.com";
            settings.EnableSSL = false;
            settings.Port = 2525;
            settings.Credentials = new Credentials { Username = "register2016@abv.bg", Password = "EBFQ4cFL7ET" };

            var client = new SmtpMailSender(settings);

            var result = await client.SendAsync(new string[] { "vladimir.dimov@codeo.co.il" }, "register2016@abv.bg", "test", "test body");

            if (result.Success != null)
            {
                Console.WriteLine($"Success: {result.Success}");
            }
            else
            {
                Console.WriteLine($"Error: {result.Error}");
            }
        }
    }
}
