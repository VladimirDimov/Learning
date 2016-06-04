using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var requester = new HttpRequester();
            var response = requester.Post("http://localhost:2509/home/test");

            Console.WriteLine(response);
        }
    }
}
