namespace ModelBinderDemo.Models
{
    public class Dog : IAnimal
    {
        public string Name { get; set; }

        public string Speak()
        {
            return $"Bau, my name is {this.Name}";
        }
    }
}