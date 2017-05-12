namespace CustomModelBinderDemo.ModelBinders
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using ViewModels;

    public class PersonCollectionModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProvider = bindingContext.ValueProvider;

            var firstNames = valueProvider.GetValue(nameof(Person.FirstName)).RawValue as string[];
            var lastNames = valueProvider.GetValue(nameof(Person.LastName)).RawValue as string[];

            var result = new List<Person>();

            for (int i = 0; i < firstNames.Length; i++)
            {
                var person = new Person { FirstName = firstNames[i], LastName = lastNames[i] };

                // Don't forget to implement model validation!!!
                this.ValidateModel(person, bindingContext);

                result.Add(person);
            }

            return result.ToArray();
        }

        private void ValidateModel(Person model, ModelBindingContext bindingContext)
        {
            var validationResults = new HashSet<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, new ValidationContext(model, null, null), validationResults, true);
            if (!isValid)
            {
                foreach (var result in validationResults)
                {
                    bindingContext.ModelState.AddModelError(string.Empty, result.ErrorMessage);
                }
            }
        }
    }
}