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

        [SetUp]
        public void Setup()
        {
            _authenticator = new Mock<ISteamBrowserAuthenticator>();
            _api = new Mock<ISteamApiCaller>();
            _settings = new Mock<ISettings>();

            _subject = new AppSettingsViewModel(_authenticator.Object, _api.Object, _settings.Object);
        }

        [Test]
        public void Constructor_WhenUserSettingForSteamIdIsNotSet_PromptsUserToLogin()
        {
            _settings.Setup(c => c.SteamId).Returns<string>(null);
            var result = new AppSettingsViewModel(_authenticator.Object, _api.Object, _settings.Object);

            Assert.That(result.UserName == null);
            Assert.That(result.DisplaySteamLoginLink == true);
        }
    }
}
