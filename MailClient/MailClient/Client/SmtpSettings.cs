using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient.Client
{
    public class SmtpSettings
    {
        public Credentials Credentials { get; internal set; }

        public bool EnableSSL { get; internal set; }

        public string Host { get; internal set; }

        public int Port { get; internal set; }
    }

    public class Credentials
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
