using System.Linq;
using System.Windows;
using CounterStats.ApiCaller;
using CounterStats.ApiCaller.HttpWebClient;
using CounterStats.Business;
using CounterStats.Business.Interfaces;
using CounterStats.UI.ViewModels;
using CounterStats.UI.Views.CurrentGame;
using CounterStats.UI.Views.Elements;
using CounterStats.UI.Views.LifetimeStats;
using CSGSI;
using Ninject;
using System.Configuration;

namespace CounterStats.UI.Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel _container;

        public App()
        {
            InitializeComponent();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();

            var page = _container.Get<MainWindow>();
            Current.MainWindow.Show();

            var vm = (page.DataContext as MainWindowViewModel);
            vm.SelectedMenuItem = vm.Menu.First();
        }

        private void ConfigureContainer()
        {
            _container = new StandardKernel();
            _container.Bind<ICurrentGameUpdater>().To<CurrentGameUpdater>();

            _container.Bind<CurrentGameViewModel>().To<CurrentGameViewModel>();
            _container.Bind<MainWindowViewModel>().To<MainWindowViewModel>();
            _container.Bind<LifetimeStatsViewModel>().To<LifetimeStatsViewModel>();

            _container.Bind<IHttpWebClient>().To<HttpWebClient>();
            _container.Bind<ISteamApiCaller>().To<SteamApiCaller>()
                .WithConstructorArgument(@"apiKey", ConfigurationManager.AppSettings.Get("SteamApiKey"));

            _container.Bind<ILifetimeStatisticsFetcher>().To<LifetimeStatisticsFetcher>();
            _container.Bind<GameStateListener>().ToConstant(new GameStateListener(12455));
            
            var menu = GetMainMenu();
            _container.Bind<IMainMenu>().ToConstant(menu);
        }

        protected internal IMainMenu GetMainMenu()
        {
            return new MainMenu()
            {
                new MenuItem() {Text = "Current Game", OnClick = () =>
                {
                    var mainWindow = (Current.MainWindow as MainWindow);
                    if (mainWindow != null)
                    {
                        mainWindow.CurrentPage.Content = _container.Get<CurrentGamePage>();
                    }
                }},
                new MenuItem() {Text = "Lifetime Statistics", OnClick = () =>
                {
                    var mainWindow = (Current.MainWindow as MainWindow);
                    if (mainWindow != null)
                    {
                        mainWindow.CurrentPage.Content = _container.Get<LifetimeStatsPage>();
                    }
                }},
                new MenuItem() {Text = "More Features Coming Soon", OnClick = () => { }}
            };
        }

    }
}
