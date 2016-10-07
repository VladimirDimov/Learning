namespace Multilingual.Web.MultilingualActivator
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Resources;

    public class TranslationsReader : IResourceRead
    {
        private ResourceManager resourceManager;

        public TranslationsReader(ResourceManager resourceManager)
        {
            this.resourceManager = resourceManager;
        }

        public IDictionary<string, string> All()
        {
            return new Dictionary<string, string>();
        }
    }
}
