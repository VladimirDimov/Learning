using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomModelBinderDemo.ViewModels
{
    public interface IAnimal
    {
        string Name { get; set; }

        string Say();
    }
}