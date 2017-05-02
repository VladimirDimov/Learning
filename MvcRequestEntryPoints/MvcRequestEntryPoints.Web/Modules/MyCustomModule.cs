namespace MvcRequestEntryPoints.Web.Modules
{
    using System.Web;

    public class MyCustomModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += (s, o) =>
            {
                var url = context.Request.Url;
            };
        }
    }
}