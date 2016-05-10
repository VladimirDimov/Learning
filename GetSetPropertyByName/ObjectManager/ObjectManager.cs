namespace ObjectManager
{
    using System.Collections.Generic;

    public class ObjectManager<T>
    {
        private T obj;

        public ObjectManager(T obj)
        {
            this.obj = obj;
        }

        public IDictionary<string, string> GetPropertiesMap()
        {
            var propertiesMap = new Dictionary<string, string>();
        }

        private IDictionary<string, string> GetPropertiesMapRecursively(object subObject, IDictionary<string, string> propertiesMap)
        {

        }
    }
}
