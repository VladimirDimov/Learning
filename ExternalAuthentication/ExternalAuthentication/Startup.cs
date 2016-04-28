using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExternalAuthentication.Startup))]
namespace ExternalAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
