using System.Web.Http.ModelBinding;
using ModelBinderDemo.App_Start;

namespace ModelBinderDemo.Models
{
    public interface IAnimal
    {
        string Name { get; set; }

        string Speak();

    }
}