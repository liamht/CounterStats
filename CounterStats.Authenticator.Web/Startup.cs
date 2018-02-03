using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CounterStats.Authenticator.Web.Startup))]
namespace CounterStats.Authenticator.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
