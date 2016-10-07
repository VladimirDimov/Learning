namespace Multilingual.Web.MultilingualActivator
{
    using System.Collections.Generic;

    internal interface IResourceRead
    {
        IDictionary<string, string> All();
    }
}
