using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(All.Startup))]
namespace All
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
