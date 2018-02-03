using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using CounterStats.ApiCaller;
using CounterStats.UI.Commands;
using CounterStats.UI.Views;
using CounterStats.UI.Views.Elements;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CounterStats.UI.ViewModels
{
    public class AppSettingsViewModel : BaseViewModel
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

        #region public bool DisplaySteamLoginLink
        private bool _displaySteamLoginLink;
        public bool DisplaySteamLoginLink
        {
            get { return _displaySteamLoginLink; }
            set
            {
                _displaySteamLoginLink = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DisplaySteamLoginLink"));
            }
        }
        #endregion

        #region public bool DisplayChangeCsgoPathButton
        private bool _displayChangeCsgoPathButton;
        public bool DisplayChangeCsgoPathButton
        {
            get { return _displayChangeCsgoPathButton; }
            set
            {
                _displayChangeCsgoPathButton = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DisplayChangeCsgoPathButton"));
            }
        }
        #endregion

        #region public string UserName

        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("UserName"));
            }
        }
        #endregion

        #region public string CsgoPath

        private string _csgoPath;
        public string CsgoPath
        {
            get { return _csgoPath.Substring(0, 25)+"..."; }
            set
            {
                _csgoPath = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CsgoPath"));
            }
        }
        #endregion

        public string ErrorMessage { get; } = @"The folder you specified does not contain your csgo.exe file. Please select the correct folder, This folder is typically located at:
C:\Program Files/Steam\steamapps\common\Counter-Strike Global Offensive.";

        private ISteamBrowserAuthenticator _authenticator;

        private ISteamApiCaller _apiHelper;

        public AppSettingsViewModel(ISteamBrowserAuthenticator authenticator, ISteamApiCaller apiHelper)
        {
            _authenticator = authenticator;
            _apiHelper = apiHelper;
            UserName = Properties.Settings.Default.SteamName;
            CsgoPath = Properties.Settings.Default.CsgoPath;

            if (string.IsNullOrWhiteSpace(UserName))
            {
                DisplaySteamLoginLink = true;
            }

            if (string.IsNullOrWhiteSpace(CsgoPath))
            {
                DisplayChangeCsgoPathButton = true;
            }
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
                    Properties.Settings.Default.CsgoPath = dialog.FileName;
                    Properties.Settings.Default.Save();

                    CsgoPath = dialog.FileName;
                    DisplayChangeCsgoPathButton = false;
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
            if (string.IsNullOrWhiteSpace(userId)) return;

            UserName = _apiHelper.GetPlayerSummaries(userId).UserName;
            Properties.Settings.Default.SteamId = userId;
            Properties.Settings.Default.SteamName = UserName;
            Properties.Settings.Default.Save();
            DisplaySteamLoginLink = false;
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
