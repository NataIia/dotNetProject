using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(uuregistration.Startup))]
namespace uuregistration
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
