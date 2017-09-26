using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCDependencyInjectionWithIdentity.Startup))]
namespace MVCDependencyInjectionWithIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
