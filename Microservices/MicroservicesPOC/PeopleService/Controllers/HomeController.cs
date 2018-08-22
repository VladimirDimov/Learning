using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Http;
using PeopleService.Models;
using RabbitMQ.Client;

namespace PeopleService.Controllers
{
    public class HomeController : ApiController
    {
        public IHttpActionResult Post(Person model)
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
                    channel.QueueDeclare("person", false, false, false, new Dictionary<string, object>
                    {
                        { "PersonId", model.Id }
                    });

                    var body = Encoding.UTF32.GetBytes($"Name: {model.Name}, ID: {model.Id}");
                    channel.BasicPublish(exchange: "", routingKey: "person", basicProperties: null, body: body);

                    return this.Json(new { name = model.Name });
                }
            }
        }
    }
}