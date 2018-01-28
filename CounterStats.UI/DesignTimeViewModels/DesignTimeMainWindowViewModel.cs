using System.Collections.Generic;
using System.Linq;
using CounterStats.UI.Views;
using CounterStats.UI.Views.CurrentGame;
using CounterStats.UI.Views.Elements;

namespace CounterStats.UI.DesignTimeViewModels
{
    public class DesignTimeMainWindowViewModel
    {
        public List<MenuItem> Menu { get; set; }

        public MenuItem SelectedMenuItem { get; set; }


        public DesignTimeMainWindowViewModel()
        {
            Menu = GetMainMenu().ToList();
            SelectedMenuItem = Menu.First();
        }


        protected internal IMainMenu GetMainMenu()
        {
            return new MainMenu()
            {
                new MenuItem() {Text = "Current Game", OnClick = () =>
                {
                    var mainWindow = (App.Current.MainWindow as MainWindow);
                    if (mainWindow != null)
                    {
                        mainWindow.CurrentPage.Content = new CurrentGamePage(null);
                    }
                }},
                new MenuItem() {Text = "More Features Coming Soon", OnClick = () => { }}
            };
        }
    }
}
