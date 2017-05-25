namespace HttpParameterBindingDemo.Models
{
    public class CustomerOrder : BaseModel
    {
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}