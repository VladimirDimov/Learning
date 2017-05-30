namespace ModelBinderDemo.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Controllers;
    using System.Web.Http.ModelBinding;
    using Models;
    using Newtonsoft.Json;

    public class MyModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var json = this.ExtractRequestJson(actionContext);

            var inputModels = this.DeserializeObjectFromJson(json);

            var result = new List<IAnimal>();
            foreach (var animal in inputModels)
            {
                if (animal.Type == typeof(Cat).Name)
                {
                    result.Add(new Cat() { Name = animal.Name });
                }
                else if (animal.Type == typeof(Dog).Name)
                {
                    result.Add(new Dog() { Name = animal.Name });
                }
                else
                {
                    throw new ArgumentException($"Invalid animal type name: {animal.Type}");
                }
            }

            bindingContext.Model = result;

            return true;
        }

        private IEnumerable<AnimalBindingModel> DeserializeObjectFromJson(string json)
        {
            var obj = JsonConvert.DeserializeObject<IEnumerable<AnimalBindingModel>>(json);

            return obj;
        }

        private string ExtractRequestJson(HttpActionContext actionContext)
        {
            var content = actionContext.Request.Content;
            string json = content.ReadAsStringAsync().Result;

            return json;
        }
    }
}