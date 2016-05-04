using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectManager
{
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
            var propertyInfo = obj.GetType().GetProperties();
        }
    }
}
