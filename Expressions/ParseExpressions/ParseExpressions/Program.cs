namespace ParseExpressions
{
    using System;
    using System.Linq.Expressions;

    internal class Program
    {
        private static void Main()
        {
            var model = new Person();

            var name = "SomeName";
            var propName = ExpressionParser.Parse<Person>(m => name);

            Console.WriteLine(propName);
        }
    }
}
