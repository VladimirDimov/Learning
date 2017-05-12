namespace CustomModelBinderDemo.ViewModels
{
    public class Cat : IAnimal
    {
        public string Name { get; set; }

        public string Say()
        {
            return $"Meau, I am {this.Name}";
        }
    }
}