using FluentValidation.Attributes;

namespace MVC.Models
{
    [Validator(typeof(FormModelValidator))]
    public class FormModel
    {
        public int FormTypeId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public bool IsMan { get; set; }
    }
}