namespace GetSetPropertyByName
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        public class Person
        {
            public Name Name { get; set; }

            public int Age { get; set; }
        }

        public class Name
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }
        }

        static void Main()
        {
            var person = new Person { Name = new Name { FirstName = "Pesho", LastName = "Petrov" }, Age = 20 };
            var propertyInfo = person.GetType().GetProperties();

            foreach (var prop in propertyInfo)
            {
                if (!prop.PropertyType.IsClass)
                {
                    Console.WriteLine($"{prop.Name} : {prop.GetValue(person)}");
                }
            }
        }
    }
}
