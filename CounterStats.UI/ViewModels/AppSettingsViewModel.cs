using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CounterStats.UI.Commands;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CounterStats.UI.ViewModels
{
    public class AppSettingsViewModel
    {
        public ICommand OpenFolderDialog => new ActionCommand(OpenDialog);


        public AppSettingsViewModel()
        {
        }

        public void OpenDialog()
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            CommonFileDialogResult result = dialog.ShowDialog();
        }
    }
}
