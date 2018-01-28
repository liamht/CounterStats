using CounterStats.UI.ViewModels;
using CounterStats.UI.Views.Elements;
using NUnit.Framework;

namespace CounterStrats.UI.Test.ViewModels
{
    public class MainWindowViewModelTests
    {
        private MainWindowViewModel _subject;
        private bool _hasMenuItemMethodBeenCalled;

        [SetUp]
        public void SetUp()
        {
            var mainMenu = new MainMenu();
            var bottomMenu = new MainMenu();

            _subject = new MainWindowViewModel(mainMenu, bottomMenu);
        }

        [Test]
        public void SelectedMenuItem_WhenChanged_CallsOnClickAction()
        {
            var menuItem = new MenuItem() { Text = "test", OnClick = () => MainMenuItemMethod() };
            _subject.SelectedMenuItem = menuItem;

            Assert.IsTrue(_hasMenuItemMethodBeenCalled);
        }

        [Test]
        public void SelectedMenuItem_WhenChanged_CallsOnPropertyChanged()
        {
            var nameOfPropertyChanged = string.Empty;
            _subject.PropertyChanged += (sender, args) => nameOfPropertyChanged = args.PropertyName;

            var menuItem = new MenuItem() { Text = "test", OnClick = () => MainMenuItemMethod() };
            _subject.SelectedMenuItem = menuItem;

            Assert.IsTrue(nameOfPropertyChanged == "SelectedMenuItem");
        }

        private void MainMenuItemMethod()
        {
            _hasMenuItemMethodBeenCalled = true;
        }
    }
}
