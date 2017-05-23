namespace ModelBinderDemo.Models
{
    public class Cat : IAnimal
    {
        public string Name { get; set; }

        public string Speak()
        {
            return $"Meau, my name is {this.Name}";
        }
    }
}