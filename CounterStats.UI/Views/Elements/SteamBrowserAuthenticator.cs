using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using CefSharp.Wpf;

namespace CounterStats.UI.Views.Elements
{
    public class SteamBrowserAuthenticator : ISteamBrowserAuthenticator
    {
        public async Task<string> GetUsersSteamId()
        {
            var window = new Window()
            {
                Width = 900,
                Height = 625,
                Title = "Log in to Steam"
            };
            var browser = new ChromiumWebBrowser();
            var limiter = new SemaphoreSlim(0, 1);
            var result = String.Empty;

            browser.LoadingStateChanged += (sender, e) =>
            {
                if (BrowserIsNavigatingToRedirectUrl(e.Browser.MainFrame.Url))
                {
                    result = e.Browser.MainFrame.Url.ToString().Split('=').Last();
                    window.Dispatcher.Invoke(() =>
                    {
                        window.Close();
                    }); 
                }
            };

            window.Closing += (s, e) =>
            {
                limiter.Release();
            };

            window.Content = browser;
            window.Show();
            var url = "http://counterstats-app.com/Account/Login";
            browser.Load(url);

            await limiter.WaitAsync();

            return result;
        }

        private bool BrowserIsNavigatingToRedirectUrl(string uri)
        {
            var expectedUri = "http://counterstats-app.com/Account/Confirmed";
            return uri.StartsWith(expectedUri);
        }
    }
}
