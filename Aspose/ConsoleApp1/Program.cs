using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Pdf;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            // load HTML contents<o:p></o:p>

            using (var stream = new MemoryStream(Encoding.ASCII.GetBytes("<p>test</p>")))
            {
                Document source = new Document(stream, new HtmlLoadOptions());
                source.Save("result.pdf");
            }


            // save output as PDF format
        }
    }
}
