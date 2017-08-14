using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace _2_56_ImplementingIEnumerable
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var x = new Person()
            {
                FirstName = "asdsadas",
                LastName = "123213123"
            };
        }
    }

    [DebuggerDisplay("Name = {FirstName} {LastName}")]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}