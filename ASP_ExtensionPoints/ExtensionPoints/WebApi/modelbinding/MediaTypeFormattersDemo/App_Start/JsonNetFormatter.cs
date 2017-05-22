namespace MediaTypeFormattersDemo.App_Start
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class JsonNetFormatter : MediaTypeFormatter
    {
        public JsonNetFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
        }

        public override bool CanWriteType(Type type)
        {
            // don't serialize JsonValue structure use default for that
            //if (type == typeof(JsonValue) || type == typeof(JsonObject) || type == typeof(JsonArray))
            //    return false;

            return true;
        }

        public override bool CanReadType(Type type)
        {
            //if (type == typeof(IKeyValueModel))
            //    return false;

            return true;
        }

        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            return Task<object>.Factory.StartNewWithCulture<object>(() =>
            {
                var settings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                };

                var sr = new StreamReader(readStream);
                var jreader = new JsonTextReader(sr);

                var ser = new JsonSerializer();
                ser.Converters.Add(new IsoDateTimeConverter());

                object val = ser.Deserialize(jreader, type);

                return val;
            },

            Thread.CurrentThread.CurrentCulture);
        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {

            return Task.Factory.StartNewWithCulture(() =>
            {
                var settings = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                };

                string json = JsonConvert.SerializeObject(value, Formatting.Indented,
                                                          new JsonConverter[1] { new IsoDateTimeConverter() });

                byte[] buf = System.Text.Encoding.Default.GetBytes(json);
                writeStream.Write(buf, 0, buf.Length);
                writeStream.Flush();
            },

            Thread.CurrentThread.CurrentCulture);
        }
    }
}