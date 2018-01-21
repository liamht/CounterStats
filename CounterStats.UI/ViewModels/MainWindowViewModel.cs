using System.Collections.Generic;
using System.Configuration;

namespace CounterStats.UI.ViewModels
{
    public class MainWindowViewModel
    {
        public bool PlayQuakeSounds { get; set; }

        public List<MenuItem> Menu => GetMainMenu();

        public MainWindowViewModel()
        {
            PlayQuakeSounds = Properties.Settings.Default.PlayQuakeSounds;
        }

        public static List<MenuItem> GetMainMenu()
        {
            return new List<MenuItem>()
            {
                new MenuItem() {Text = "Current Game"},
                new MenuItem() {Text = "More Features Coming Soon"}
            };
        }
    }
}

