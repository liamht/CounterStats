using System.Linq;
using System.Windows;
using CounterStats.ApiCaller;
using CounterStats.ApiCaller.HttpWebClient;
using CounterStats.Business;
using CounterStats.Business.Interfaces;
using CounterStats.UI.Helpers;
using CounterStats.UI.ViewModels;
using CounterStats.UI.Views.CurrentGame;
using CounterStats.UI.Views.Elements;
using CounterStats.UI.Views.LifetimeStats;
using CSGSI;
using Ninject;
using CounterStats.UI.Views.AppSettings;

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
            _container.Bind<IOpenSettingsAction>().ToConstant(GetOpenSettingsAction());

            _container.Bind<MainWindowViewModel>().To<MainWindowViewModel>();
            _container.Bind<LifetimeStatsViewModel>().To<LifetimeStatsViewModel>();
            _container.Bind<AppSettingsViewModel>().To<AppSettingsViewModel>();
            _container.Bind<CurrentGameViewModel>().To<CurrentGameViewModel>();

            _container.Bind<IHttpWebClient>().To<HttpWebClient>();
            _container.Bind<ISteamBrowserAuthenticator>().To<SteamBrowserAuthenticator>();
            _container.Bind<ISteamApiCaller>().To<SteamApiCaller>()
                .WithConstructorArgument(@"apiKey", SteamApiKey.Value);

            _container.Bind<ILifetimeStatisticsFetcher>().To<LifetimeStatisticsFetcher>();
            _container.Bind<ISettings>().To<Settings>();
            _container.Bind<IFolderBrowser>().To<FolderBrowser>();
            _container.Bind<GameStateListener>().ToConstant(new GameStateListener(12455));
            
            _container.Bind<IMainMenu>().ToConstant(GetMainMenu());
        }

        private IOpenSettingsAction GetOpenSettingsAction()
        {
            return new OpenSettingsAction(() =>
            {
                var mainWindow = (Current.MainWindow as MainWindow);
                if (mainWindow != null)
                {
                    var vm = MainWindow.DataContext as MainWindowViewModel;
                    vm?.ResetMenu();

                    mainWindow.CurrentPage.Content = _container.Get<AppSettingsPage>();
                }
            });
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
                        if (string.IsNullOrWhiteSpace(CounterStats.UI.Properties.Settings.Default.CsgoPath))
                        {
                            var vm = MainWindow.DataContext as MainWindowViewModel;
                            vm?.ResetMenu();
                            mainWindow.CurrentPage.Content = _container.Get<AppSettingsPage>();
                            return;
                        }
                        mainWindow.CurrentPage.Content = _container.Get<CurrentGamePage>();
                    }
                }},
                new MenuItem() {Text = "Lifetime Statistics", OnClick = () =>
                {
                    var mainWindow = (Current.MainWindow as MainWindow);
                    if (mainWindow != null)
                    {
                        if (string.IsNullOrWhiteSpace(CounterStats.UI.Properties.Settings.Default.SteamId))
                        {
                            var vm = MainWindow.DataContext as MainWindowViewModel;
                            vm?.ResetMenu();
                            mainWindow.CurrentPage.Content = _container.Get<AppSettingsPage>();
                            return;
                        }
                        mainWindow.CurrentPage.Content = _container.Get<LifetimeStatsPage>();
                    }
                }}
            };
        }
    }
}
