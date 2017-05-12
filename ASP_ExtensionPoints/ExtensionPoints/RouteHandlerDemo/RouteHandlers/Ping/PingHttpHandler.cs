using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace RouteHandlerDemo.RouteHandlers
{
    public class PingHttpHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            using (var writer = new StringWriter())
            {
                var xmlSerializer = new XmlSerializer(typeof(PingResult));
                var result = new PingResult
                {
                    ApplicationName = "MyApplication",
                    Version = "0.0.0.1"
                };
                xmlSerializer.Serialize(writer, result);

                context.Response.Output.Write(writer);
            }
        }
    }
}