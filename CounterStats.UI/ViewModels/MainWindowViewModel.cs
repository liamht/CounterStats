using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CounterStats.UI.Views.Elements;
using MenuItem = CounterStats.UI.Views.Elements.MenuItem;

namespace CounterStats.UI.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
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
        public List<MenuItem> BottomMenu { get; set; }

        public MainWindowViewModel(IMainMenu mainMenu, IBottomMenu bottomMenu)
        {
            Menu = mainMenu.ToList();
            BottomMenu = bottomMenu.ToList();

            PlayQuakeSounds = Properties.Settings.Default.PlayQuakeSounds;
        }
    }
}

