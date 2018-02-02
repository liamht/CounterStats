using System;
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

        public IOpenSettingsAction OpenSettings { get; set; }

        public bool PlayQuakeSounds { get; set; }

        public List<MenuItem> Menu { get; set; }

        public MainWindowViewModel(IMainMenu mainMenu, IOpenSettingsAction openSettingsAction)
        {
            Menu = mainMenu.ToList();
            OpenSettings = openSettingsAction;

            PlayQuakeSounds = Properties.Settings.Default.PlayQuakeSounds;
        }
    }
}

