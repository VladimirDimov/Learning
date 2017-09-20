namespace CsvMediaTypeFormatterDemo.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net.Http;
    using System.Net.Http.Formatting;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using CsvHelper;
    using Models;

    // The 
    public class CsvMediaTypeFormatter<T> : MediaTypeFormatter
    {
        public CsvMediaTypeFormatter()
        {
            this.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
        }

        public override bool CanReadType(Type type)
        {
            return this.CanProcessType(type);
        }

        public override bool CanWriteType(Type type)
        {
            return this.CanProcessType(type);
        }

        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            return Task.Factory.StartNew<object>(() =>
            {
                List<T> result = new List<T>();

                using (var reader = new StreamReader(readStream))
                {
                    var model = Activator.CreateInstance(type.GetGenericArguments().First()) as IReadCsv;

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var currentModel = (T)model.ReadLine(line);

                        result.Add(currentModel);
                    }
                }

                return result;
            });
        }

        private bool CanProcessType(Type type)
        {
            if (type.GetGenericArguments().Single() == typeof(T))
            {
                return true;
            }

            return false;
        }

        private IEnumerable<T> GetRecords<T>(CsvReader reader, T model)
        {
            var records = reader.GetRecords<T>();

            return records;
        }
    }
}