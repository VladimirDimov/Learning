namespace Multilingual.Web.MultilingualActivator
{
    using System;
    using System.Resources;

    public class TranslationsWriter : IResourceWrite, IDisposable
    {
        private IResourceWriter resourceWriter;

        public TranslationsWriter(IResourceWriter resourceWriter)
        {
            this.resourceWriter = resourceWriter;
        }

        public void AddTranslation(string name)
        {
            resourceWriter.AddResource(name, string.Empty);
        }

        public void AddTranslation(string name, string translation, string language)
        {
            throw new NotImplementedException();
        }

        public void RemoveTranslation(string name, string language)
        {
            throw new NotImplementedException();
        }

        public void RemoveTranslationField(string name)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.resourceWriter.Close();
        }
    }
}
