using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using CefSharp;
using CefSharp.Wpf;

namespace CounterStats.UI.Views.Elements
{
    public class SteamBrowserAuthenticator : ISteamBrowserAuthenticator
    {
        private Window _window;
        private ChromiumWebBrowser _browser;
        private string _returnResult;
        private SemaphoreSlim _limiter;

        public async Task<string> GetUsersSteamId()
        {
            _limiter = new SemaphoreSlim(0, 1);
            SetUpWindow();
            await _limiter.WaitAsync();
            return _returnResult;
        }

        private void SetUpWindow()
        {
            _window = new Window()
            {
                Width = 900,
                Height = 625,
                Title = "Log in to Steam"
            };
            _browser = new ChromiumWebBrowser();
            _window.Closing += CleanUpBrowser;
            _browser.LoadingStateChanged += BrowserOnLoadingStateChanged;
            _window.Closing += (s, e) =>
            {
                _limiter.Release();
            };

            _window.Content = _browser;
            _window.Show();
            var url = "http://counterstats-app.com/Account/Login";
            _browser.Load(url);
        }

        private void BrowserOnLoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (BrowserIsNavigatingToRedirectUrl(e.Browser.MainFrame.Url))
            {
                _returnResult = e.Browser.MainFrame.Url.ToString().Split('=').Last();
                _window.Dispatcher.Invoke(() =>
                {
                    _window.Close();
                });
            }
        }

        private void CleanUpBrowser(object o, CancelEventArgs cancelEventArgs)
        {
            _window.Dispatcher.Invoke(() =>
            {
                Cef.Shutdown();
                _browser.Dispose();
            });
        }

        private bool BrowserIsNavigatingToRedirectUrl(string uri)
        {
            var expectedUri = "http://counterstats-app.com/Account/Confirmed";
            return uri.StartsWith(expectedUri);
        }
    }
}
