using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWithHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            var tmp = new HtmlTemplate();
            tmp.Session = new Dictionary<string, object>();
            tmp.Session["person"] = new Person() { Name = "Pesho", Age = 150 };
            tmp.Initialize();
            Console.WriteLine(tmp.TransformText());
        }
    }

    class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
