namespace CustomModelBinderDemo.ModelBinders
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using ViewModels;

    public class AnimalsModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var valueProvider = bindingContext.ValueProvider;
            var names = valueProvider.GetValue("Name").RawValue as string[];
            var types = valueProvider.GetValue("TypeOfAnimal").RawValue as string[];

            var animals = new List<IAnimal>();
            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].ToLower() == "cat")
                {
                    animals.Add(new Cat { Name = names[i] });
                }
                else if (types[i].ToLower() == "dog")
                {
                    animals.Add(new Dog { Name = names[i] });
                }
            }

            return animals;
        }
    }
}