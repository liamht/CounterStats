using System;
using System.Windows.Controls;
using CounterStats.UI.ViewModels;
using MaterialDesignThemes.Wpf;

namespace CounterStats.UI.Views.AppSettings
{
    public partial class AppSettingsPage : UserControl
    {
        private AppSettingsViewModel _vm;

        public AppSettingsPage(AppSettingsViewModel vm)
        {
            DataContext = vm;
            _vm = vm;
            InitializeComponent();
        }

        private void DialogHost_OnDialogClosing(object sender, DialogClosingEventArgs eventargs)
        {
            _vm.ErrorMessageReceived.Execute(null);
        }
    }
}
