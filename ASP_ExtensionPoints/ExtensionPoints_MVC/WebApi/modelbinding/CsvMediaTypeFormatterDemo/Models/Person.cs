using System;
using System.Linq;
using System.Linq.Expressions;
using CsvHelper.Configuration;

namespace CsvMediaTypeFormatterDemo.Models
{
    public class Person : IReadCsv
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public object ReadLine(string csvLine)
        {
            var values = csvLine.Split(',').Select(x => x.Trim()).ToList();
            return new Person
            {
                Name = values[0],
                Age = int.Parse(values[1])
            };
        }
    }

    public interface IReadCsv
    {
        object ReadLine(string csvLine);
    }
}