using System.ComponentModel.DataAnnotations;

namespace CustomModelBinderDemo.ViewModels
{
    public class Person
    {
        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}