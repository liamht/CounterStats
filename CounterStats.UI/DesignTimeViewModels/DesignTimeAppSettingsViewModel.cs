﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CounterStats.UI.Commands;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CounterStats.UI.DesignTimeViewModels
{
    public class DesignTimeAppSettingsViewModel
    {
        public ICommand OpenFolderDialog { get; set; }
        public ICommand LoginCommand => new ActionCommand(() => { });
        public string ErrorMessage => "Hello World";
        public bool IsErrorMessageShown { get; set; } = true;
        public bool DisplaySteamLoginLink { get; }
        public bool DisplayChangeCsgoPathButton { get; }
        public string UserName { get; set; }
        public string CsgoPath { get; set; }


        public DesignTimeAppSettingsViewModel()
        {
            OpenFolderDialog = new ActionCommand(() => { });
        }
    }
}
