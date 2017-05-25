namespace FilterProviderDemo.ConfigSections
{
    using System;
    using System.Configuration;

    public class FilterElement : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string name
        {
            get { return (string)base["name"]; }
            set { base["name"] = value; }
        }
        [ConfigurationProperty("type", IsKey = false, IsRequired = true)]
        public string type
        {
            get { return (string)base["type"]; }
            set { base["type"] = value; }
        }

        [ConfigurationProperty("isactive", DefaultValue = "true", IsKey = false, IsRequired = false)]
        public bool isactive
        {
            get { return (bool)base["isactive"]; }
            set { base["isactive"] = value; }
        }
    }

    [ConfigurationCollection(typeof(FilterElement))]
    public class FilterAppearanceCollection : ConfigurationElementCollection
    {
        internal const string PropertyName = "Filter";

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        protected override string ElementName
        {
            get
            {
                return PropertyName;
            }
        }

        protected override bool IsElementName(string elementName)
        {
            return elementName.Equals(PropertyName, StringComparison.InvariantCultureIgnoreCase);
        }


        public override bool IsReadOnly()
        {
            return false;
        }


        protected override ConfigurationElement CreateNewElement()
        {
            return new FilterElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FilterElement)(element)).name;
        }

        public FilterElement this[int idx]
        {
            get
            {
                return (FilterElement)BaseGet(idx);
            }
        }
    }

    public class FiltersSettings : ConfigurationSection
    {
        [ConfigurationProperty("Filters")]
        public FilterAppearanceCollection FilterElement
        {
            get { return ((FilterAppearanceCollection)(base["Filters"])); }
            set { base["Filters"] = value; }
        }
    }
}