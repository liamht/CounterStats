using System;
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

        public DesignTimeAppSettingsViewModel()
        {
            OpenFolderDialog = new ActionCommand(() => { });
        }
    }
}
