﻿namespace ModelBinderDemo.App_Start
{
    using System;
    using System.Web.Http;
    using System.Web.Http.ModelBinding;

    public class AnimalsModelBinderProvider : ModelBinderProvider
    {
        public override IModelBinder GetBinder(HttpConfiguration configuration, Type modelType)
        {
            return new AnimalsModelBinder();
        }
    }
}