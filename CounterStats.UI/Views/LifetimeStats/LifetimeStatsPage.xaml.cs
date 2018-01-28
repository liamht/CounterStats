using System;
using System.Windows.Controls;
using CounterStats.UI.ViewModels;

namespace CounterStats.UI.Views.LifetimeStats
{
    /// <summary>
    /// Interaction logic for CurrentGamePage.xaml
    /// </summary>
    public partial class LifetimeStatsPage : UserControl
    {
        public LifetimeStatsPage(LifetimeStatsViewModel vm)
        {
            DataContext = vm;
            InitializeComponent();
        }
    }
}
