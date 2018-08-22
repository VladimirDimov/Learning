using FluentValidation;

namespace MVC.Models
{
    public class FormModelValidator : AbstractValidator<FormModel>
    {
        public FormModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Name)
                .Must(x => x.StartsWith("Mr. "))
                .When(x => x.IsMan && !string.IsNullOrWhiteSpace(x.Name))
                .WithMessage("If a person is a man his name should start with \"Mr.\"");

            RuleFor(x => x.Age).InclusiveBetween(1, int.MaxValue).WithMessage("Age cannot be negative");
        }
    }
}