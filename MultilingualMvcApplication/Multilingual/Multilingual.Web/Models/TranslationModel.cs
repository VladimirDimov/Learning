namespace Multilingual.Web.Models
{
    using System.Collections.Generic;

    public class TranslationModel
    {
        public string Title { get; set; }

        public Dictionary<string, string> Translations { get; set; }
    }
}
