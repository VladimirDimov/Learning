namespace Multilingual.Web.MultilingualActivator
{
    public interface IResourceWrite
    {
        /// <summary>
        /// Add empty translation row with title
        /// </summary>
        /// <param name="name"></param>
        void AddTranslation(string name);

        /// <summary>
        /// Add language to translation row. Create the row if not exist.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="translation"></param>
        /// <param name="language"></param>
        void AddTranslation(string name, string translation, string language);

        /// <summary>
        /// Remove the whole translation row by provided name
        /// </summary>
        /// <param name="name"></param>
        void RemoveTranslationField(string name);

        /// <summary>
        /// Remove a translation in existing row by provided language abbreviation.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="language"></param>
        void RemoveTranslation(string name, string language);

    }
}