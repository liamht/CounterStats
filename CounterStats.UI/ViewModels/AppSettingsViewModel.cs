using System;
using System.Windows.Input;
using CounterStats.UI.Commands;
using CounterStats.UI.Views.Elements;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CounterStats.UI.ViewModels
{
    public class AppSettingsViewModel
    {
        public ICommand OpenFolderDialog => new ActionCommand(OpenDialog);
        public ICommand LoginCommand => new ActionCommand(async () => Login());


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
            var url = "";
            var responseUrl = "";
            var authenticator = new SteamBrowserAuthenticator(url, responseUrl);
            await authenticator.GetUsersSteamId();
        }
    }
}
