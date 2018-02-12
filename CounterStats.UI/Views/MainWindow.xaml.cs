using System;
using System.Windows;
using CounterStats.UI.ViewModels;

namespace CounterStats.UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _vm;
        public MainWindow(MainWindowViewModel vm)
        {
            _vm = vm;
            DataContext = vm;
            InitializeComponent();
        }

        //todo: mvvm

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            CefSharp.Cef.Shutdown();
            Environment.Exit(0);
        }

        private void ButtonSettings_OnClick(object sender, RoutedEventArgs e)
        {
            _vm.OpenSettings.Invoke();
        }

        private void ToggleSoundButton_Unchecked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.PlayQuakeSounds = false;
            Properties.Settings.Default.Save();
        }

        private void ToggleSoundButton_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.PlayQuakeSounds = true;
            Properties.Settings.Default.Save();
        }
    }
}
