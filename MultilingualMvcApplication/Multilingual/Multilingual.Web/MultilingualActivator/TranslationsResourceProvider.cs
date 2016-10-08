namespace Multilingual.Web.MultilingualActivator
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Linq;

    public class TranslationsResourceProvider
    {
        public static IDictionary<string, Dictionary<string, string>> translations;
        public static Dictionary<string, TranslationsResourceProvider> instances = new Dictionary<string, TranslationsResourceProvider>();
        public static object instanceLocker = new object();

        protected TranslationsResourceProvider(string path, string defaultLanguage)
        {
            this.Path = path;
            this.DefaultLanguage = defaultLanguage;

            using (var reader = new StreamReader(this.Path))
            {
                var diction = JsonConvert.DeserializeObject<ConcurrentDictionary<string, Dictionary<string, string>>>(reader.ReadToEnd());
                translations = diction;
            }
        }

        public static TranslationsResourceProvider Instance(string path, string defaultLanguage)
        {
            if (!instances.ContainsKey(path))
            {
                lock (instanceLocker)
                {
                    instances.Add(path, new TranslationsResourceProvider(path, defaultLanguage));
                }
            }

            return instances[path];
        }

        public string Path { get; set; }

        public IDictionary<string, Dictionary<string, string>> Translations
        {
            get
            {
                return translations;
            }
        }

        public string DefaultLanguage { get; private set; }

        public void AddTranslation(string title)
        {
            translations.Add(title, new Dictionary<string, string>());
        }

        public void Delete(string title, string lang)
        {
            if (lang == null) // remove the whole title
            {
                translations.Remove(title);
            }

            translations[title].Remove(lang);
            this.Save();
        }

        public string this[string title, string lang]
        {
            get
            {
                if (!translations.ContainsKey(title))
                {
                    return "[Not translated]";
                }
                if (!translations[title].ContainsKey(lang))
                {
                    if (!translations[title].ContainsKey(DefaultLanguage))
                    {
                        return $"[Missing {DefaultLanguage} translation]";
                    }

                    return translations[title][DefaultLanguage];
                }

                return translations[title][lang];
            }

            set
            {
                var twoLetterIsoLang = GetTwoLetterLanguage(lang);
                if (twoLetterIsoLang == null)
                {
                    throw new ArgumentException($"Invalid ISO language: {lang}");
                }

                this.AddorUpdateTranslation(title, twoLetterIsoLang, value);
                this.Save();
            }
        }

        private void Save()
        {
            var translationsJsonString = JsonConvert.SerializeObject(this.Translations);
            using (var writer = new StreamWriter(this.Path, false))
            {
                writer.Write(translationsJsonString);
            }
        }

        private void AddorUpdateTranslation(string title, string lang, string value)
        {
            if (!translations.ContainsKey(title))
            {
                this.AddTranslation(title);
            }
            var rowTranslations = translations[title];
            if (!rowTranslations.ContainsKey(lang))
            {
                rowTranslations.Add(lang, value);
            }
            else
            {
                rowTranslations[lang] = value;
            }
        }

        private string GetTwoLetterLanguage(string language)
        {
            language = language.ToLower();
            var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);
            CultureInfo correspondingCulture = null;

            if (language.Length == 2)
            {
                correspondingCulture = cultures.FirstOrDefault(x => x.TwoLetterISOLanguageName == language);
            }
            else if (language.Length == 3)
            {
                correspondingCulture = cultures.FirstOrDefault(x => x.ThreeLetterISOLanguageName == language);
            }

            if (correspondingCulture == null)
            {
                return null;
            }
            else
            {
                return correspondingCulture.TwoLetterISOLanguageName;
            }
        }
    }
}
