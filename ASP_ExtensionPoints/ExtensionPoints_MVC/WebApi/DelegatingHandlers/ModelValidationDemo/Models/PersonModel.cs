namespace ModelValidationDemo.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PersonModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [Range(0, 200)]
        public int Age { get; set; }
    }
}