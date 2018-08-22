using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ContactsService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            this.SubscribeToMessages();
        }

        private void SubscribeToMessages()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = 12345,
                RequestedHeartbeat = 60,
                UserName = "guest",
                Password = "guest",
                Protocol = Protocols.AMQP_0_9_1
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {

                    };
                }
            }
        }
    }
}
