﻿using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Input;
using CounterStats.ApiCaller;
using CounterStats.UI.Commands;
using CounterStats.UI.Helpers;
using CounterStats.UI.Views;
using CounterStats.UI.Views.Elements;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CounterStats.UI.ViewModels
{
    public class AppSettingsViewModel : BaseViewModel
    {
        public ICommand OpenFolderDialog => new ActionCommand(OpenDialog);

        public ICommand LoginCommand => new ActionCommand(() => Login());

        public ICommand LogOutCommand => new ActionCommand(() => LogOut());
        
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
            get
            {
                if (string.IsNullOrWhiteSpace(_csgoPath) || _csgoPath.Length < 25)
                {
                    return _csgoPath;
                }
                return _csgoPath?.Substring(0, 25) + "...";
            }
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

        private ISettings _settings;

        private IFolderBrowser _browser;

        public AppSettingsViewModel(ISteamBrowserAuthenticator authenticator, ISteamApiCaller apiHelper, ISettings settings, IFolderBrowser browser)
        {
            _authenticator = authenticator;
            _apiHelper = apiHelper;
            _settings = settings;
            _browser = browser;

            UserName = _settings.SteamName;
            CsgoPath = _settings.CsgoPath;

            if (string.IsNullOrWhiteSpace(UserName) || string.IsNullOrWhiteSpace(_settings.SteamId))
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
            string folder = _browser.GetFolderFromDialog();
            if (string.IsNullOrWhiteSpace(folder))
            {
                // user has exited dialog. Do not show any error messages
                return;
            }

            if (CheckFolderIsValidCounterStrikeFolder(folder))
            {
                AddConfigFileToSelectedPath(folder);
                _settings.CsgoPath = folder;
                _settings.SaveChanges();

                CsgoPath = folder;
                DisplayChangeCsgoPathButton = false;
            }
            else
            {
                IsErrorMessageShown = true;
            }
        }

        private void LogOut()
        {
            _settings.SteamName = null;
            _settings.SteamId = null;
            UserName = null;
            DisplaySteamLoginLink = true;
            _settings.SaveChanges();
        }

        public async void Login()
        {
            var userId = await _authenticator.GetUsersSteamId();
            if (string.IsNullOrWhiteSpace(userId)) return;

            UserName = _apiHelper.GetPlayerSummaries(userId).UserName;
            _settings.SteamId = userId;
            _settings.SteamName = UserName;
            _settings.SaveChanges();
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
