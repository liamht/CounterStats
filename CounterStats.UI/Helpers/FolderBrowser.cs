using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace CounterStats.UI.Helpers
{
    public class FolderBrowser : IFolderBrowser
    {
        private CommonFileDialog _dialog;

        public string GetFolderFromDialog()
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            var result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                return dialog.FileName;
            }
            return null;
        }
    }
}
