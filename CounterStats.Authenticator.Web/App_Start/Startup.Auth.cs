using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using CounterStats.UI;
using Owin.Security.Providers.Steam;

namespace CounterStats.Authenticator.Web
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
           
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

          
            app.UseSteamAuthentication(SteamApiKey.Value);

        }
    }
}