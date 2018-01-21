using System;
using System.Windows.Controls;

namespace CounterStats.UI.Views.CurrentGame
{
    /// <summary>
    /// Interaction logic for CurrentGamePage.xaml
    /// </summary>
    public partial class CurrentGamePage : UserControl
    {
        public CurrentGamePage()
        {    
            InitializeComponent();
            Dispatcher.ShutdownStarted += OnDispatcherShutDownStarted;
        }

        private void OnDispatcherShutDownStarted(object sender, EventArgs e)
        {
            (DataContext as IDisposable)?.Dispose();
        }
    }
}
