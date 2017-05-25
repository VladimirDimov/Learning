namespace CsvMediaTypeFormatterDemo.Models
{
    using System.Linq;

    public class Car : IReadCsv
    {
        public string Model { get; set; }

        public int Weight { get; set; }

        public object ReadLine(string csvLine)
        {
            var values = csvLine.Split(',').Select(x => x.Trim(' ', '"')).ToList();

            return new Car
            {
                Model = values[0],
                Weight = int.Parse(values[1])
            };
        }
    }
}