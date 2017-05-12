namespace CustomModelBinderDemo.ViewModels
{
    public class Dog : IAnimal
    {
        public string Name { get; set; }

        public string Say()
        {
            return $"Bau, I am {this.Name}";
        }
    }
}