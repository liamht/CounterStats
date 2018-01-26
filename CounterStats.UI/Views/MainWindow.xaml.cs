using System;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using CounterStats.UI.ViewModels;

namespace CounterStats.UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }

        //todo: mvvm

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
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
