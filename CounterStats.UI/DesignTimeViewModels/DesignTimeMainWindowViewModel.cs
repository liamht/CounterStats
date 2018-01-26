using System.Collections.Generic;
using System.Linq;
using CounterStats.UI.ViewModels;
using CounterStats.UI.Views;
using CounterStats.UI.Views.CurrentGame;
using CounterStats.UI.Views.Elements;

namespace CounterStats.UI.DesignTimeViewModels
{
    public class DesignTimeMainWindowViewModel : MainWindowViewModel
    {
        public DesignTimeMainWindowViewModel() : base(null)
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
