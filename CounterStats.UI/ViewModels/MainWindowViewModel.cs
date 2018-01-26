using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using CounterStats.UI.Views.CurrentGame;
using CounterStats.UI.Views.Elements;
using MenuItem = CounterStats.UI.Views.Elements.MenuItem;

namespace CounterStats.UI.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {


        #region public int AverageDamagePerRound
        private MenuItem _selectedMenuItem;

        public MenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                _selectedMenuItem = value;
                value.OnClick.Invoke();
                OnPropertyChanged(new PropertyChangedEventArgs("SelectedMenuItem"));
            }
        }
        #endregion
        
        public bool PlayQuakeSounds { get; set; }

        public List<MenuItem> Menu { get; set; }

        public MainWindowViewModel(IMainMenu mainMenu)
        {
            Menu = mainMenu.ToList();
            PlayQuakeSounds = Properties.Settings.Default.PlayQuakeSounds;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }
}

