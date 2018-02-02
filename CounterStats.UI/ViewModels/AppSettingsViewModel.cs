using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using CounterStats.UI.Commands;
using CounterStats.UI.Views;
using CounterStats.UI.Views.Elements;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CounterStats.UI.ViewModels
{
    public class AppSettingsViewModel: BaseViewModel
    {
        public ICommand OpenFolderDialog => new ActionCommand(OpenDialog);
        public ICommand LoginCommand => new ActionCommand(async () => Login());
        public ICommand ErrorMessageReceived => new ActionCommand(CloseErrorMessage);

        #region public bool IsErrorMessageShown
        private bool _isErrorMessageShown;
        public bool IsErrorMessageShown
        {
            get { return _isErrorMessageShown; }
            set
            {
                _isErrorMessageShown = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsErrorMessageShown"));
            }
        }
        #endregion

        public string UserId { get; set; }
        public string ErrorMessage { get; } = @"The folder you specified does not contain your csgo.exe file. Please select the correct folder.";

        private ISteamBrowserAuthenticator _authenticator;

        public AppSettingsViewModel(ISteamBrowserAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public void OpenDialog()
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            var result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                if (CheckFolderIsValidCounterStrikeFolder(dialog.FileName))
                {
                    AddConfigFileToSelectedPath(dialog.FileName);
                }
                else
                {
                    IsErrorMessageShown = true;
                }
            }
        }

        public async void Login()
        {
           var userId = await _authenticator.GetUsersSteamId();

           Properties.Settings.Default.SteamId = userId;
        }


        private void AddConfigFileToSelectedPath(string selectedPath)
        {
            var cfgLocation = selectedPath + "\\csgo\\cfg\\gamestate_integration_counterstrats.cfg";
            File.Copy("gamestate_integration_counterstrats.cfg", cfgLocation, true);
        }

        private bool CheckFolderIsValidCounterStrikeFolder(string selectedPath)
        {
            return File.Exists(selectedPath + "\\csgo.exe");
        }

        private void CloseErrorMessage()
        {
            IsErrorMessageShown = false;
        }
    }
}
