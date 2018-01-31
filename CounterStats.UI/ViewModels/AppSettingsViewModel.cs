using System;
using System.Windows.Input;
using CounterStats.UI.Commands;
using CounterStats.UI.Views;
using CounterStats.UI.Views.Elements;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CounterStats.UI.ViewModels
{
    public class AppSettingsViewModel
    {
        public ICommand OpenFolderDialog => new ActionCommand(OpenDialog);
        public ICommand LoginCommand => new ActionCommand(async () => Login());

        public string UserId { get; set; }


        public AppSettingsViewModel()
        {
        }

        public void OpenDialog()
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            CommonFileDialogResult result = dialog.ShowDialog();
        }

        public async void Login()
        {
// todo: Add URL's for real authentication implementation
            var url = "http://counterstats-app.com/Account/Login";
            var responseUrl = "http://counterstats-app.com/Account/Confirmed";
            var authenticator = new SteamBrowserAuthenticator(url, responseUrl);
           var userId = await authenticator.GetUsersSteamId();

            UserId = userId;
        }
    }
}
