using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CounterStats.UI.Views.Elements
{
    public class SteamBrowserAuthenticator
    {
        public Uri RequestUri { get; set; }
        public Uri ResponseUri { get; set; }

        public SteamBrowserAuthenticator()
        {
        }

        public async Task<string> GetUsersSteamId()
        {
            var browser = new WebBrowser();
            var limiter = new SemaphoreSlim(0, 1);
            var result = String.Empty;

            var window = new Window()
            {
                Width = 900,
                Height = 625,
                Title = "Log in to Steam"
            };

            browser.Navigating += (s, e) =>
            {
                if (BrowserIsNavigatingToRedirectUri(e.Uri))
                {
                    e.Cancel = true;

                    result = e.Uri.ToString().Split('=').Last();

                    limiter.Release();

                    window.Close();
                }
            };

            window.Closing += (s, e) =>
            {
                limiter.Release();
            };

            window.Content = browser;
            window.Show();
            var url = new Uri("http://counterstats-app.com/Account/Login");
            browser.Source = url;

            await limiter.WaitAsync();

            return result;
        }

        private bool BrowserIsNavigatingToRedirectUri(Uri uri)
        {
            var expectedUri = "http://counterstats-app.com/Account/Confirmed";
            return uri.AbsoluteUri.StartsWith(expectedUri);
        }
    }
}
