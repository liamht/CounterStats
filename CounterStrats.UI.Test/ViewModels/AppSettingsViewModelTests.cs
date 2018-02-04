using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterStats.UI.ViewModels;
using CounterStats.UI.Views.Elements;
using Moq;
using NUnit.Framework;
using CounterStats.ApiCaller;
using CounterStats.UI.Helpers;

namespace CounterStrats.UI.Test.ViewModels
{
    public class AppSettingsViewModelTests
    {
        private AppSettingsViewModel _subject;
        private Mock<ISteamBrowserAuthenticator> _authenticator;
        private Mock<ISteamApiCaller> _api;
        private Mock<ISettings> _settings;
        private Mock<IFolderBrowser> _browser;

        [SetUp]
        public void Setup()
        {
            _authenticator = new Mock<ISteamBrowserAuthenticator>();
            _api = new Mock<ISteamApiCaller>();
            _settings = new Mock<ISettings>();
            _browser = new Mock<IFolderBrowser>();
            _browser.Setup(c => c.GetFolderFromDialog()).Returns(string.Empty);

            _subject = new AppSettingsViewModel(_authenticator.Object, _api.Object, _settings.Object, _browser.Object);
        }

        [Test]
        public void Constructor_WhenUserSettingForSteamIdIsNotSet_PromptsUserToLogin()
        {
            _settings.Setup(c => c.SteamName).Returns("foo");
            _settings.Setup(c => c.CsgoPath).Returns("bar");
            _settings.Setup(c => c.SteamId).Returns(String.Empty);
            var result = new AppSettingsViewModel(_authenticator.Object, _api.Object, _settings.Object,
                _browser.Object);

            Assert.That(result.DisplaySteamLoginLink == true);
        }

        [Test]
        public void Constructor_WhenUserSettingForSteamNameIsNotSet_PromptsUserToLogin()
        {
            _settings.Setup(c => c.SteamId).Returns("foo");
            _settings.SetupGet(c => c.CsgoPath).Returns("bar");
            _settings.SetupGet(c => c.SteamName).Returns(String.Empty);
            var result = new AppSettingsViewModel(_authenticator.Object, _api.Object, _settings.Object,
                _browser.Object);

            Assert.That(result.UserName == null);
            Assert.That(result.DisplaySteamLoginLink == true);
        }

        [Test]
        public void Constructor_WhenUserSettingForCsgoPathIsNotSet_DisplaysCsgoPathLink()
        {
            _settings.SetupGet(c => c.SteamId).Returns("foo");
            _settings.SetupGet(c => c.SteamName).Returns("bar");
            _settings.SetupGet(c => c.CsgoPath).Returns(string.Empty);
            var result = new AppSettingsViewModel(_authenticator.Object, _api.Object, _settings.Object,
                _browser.Object);

            Assert.That(result.CsgoPath == null);
            Assert.That(result.DisplayChangeCsgoPathButton == true);
        }

        [Test]
        public void Constructor_WhenUserSettingForSteamIdAndSteamNameAreSet_DoesNotPromptForLogin()
        {
            var testSteamName = "testtest";
            _settings.SetupGet(c => c.SteamName).Returns(testSteamName);
            _settings.SetupGet(c => c.CsgoPath).Returns("bar");
            _settings.SetupGet(c => c.SteamId).Returns("foo");
            var result = new AppSettingsViewModel(_authenticator.Object, _api.Object, _settings.Object,
                _browser.Object);

            Assert.That(result.UserName == testSteamName);
            Assert.That(result.DisplaySteamLoginLink == false);
        }

        [Test]
        public void Constructor_WhenUserSettingForCsgoPathIsSet_DoesNotPromptForChangingCsgoPath()
        {
            var testPath = "testtest";
            _settings.SetupGet(c => c.SteamId).Returns("foo");
            _settings.SetupGet(c => c.SteamName).Returns("bar");
            _settings.SetupGet(c => c.CsgoPath).Returns(testPath);
            var result = new AppSettingsViewModel(_authenticator.Object, _api.Object, _settings.Object,
                _browser.Object);

            Assert.That(result.CsgoPath == testPath);
            Assert.That(result.DisplayChangeCsgoPathButton == false);
        }

        [Test]
        public void OpenDialog_OpensFolderBrowser()
        {
            _subject.OpenDialog();

            _browser.Verify(c => c.GetFolderFromDialog(), Times.Once);
        }
    }
}
