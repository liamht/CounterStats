using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using CounterStats.UI.ViewModels;
using Moq;
using NUnit.Framework;
using CounterStats.Business.Interfaces;

namespace CounterStrats.UI.Test.ViewModels
{
    public class CurrentGameViewModelTests
    {
        private CurrentGameViewModel _subject;
        private Mock<ICurrentGameUpdater> _updater;

        [SetUp]
        public void Setup()
        {
            _updater = new Mock<ICurrentGameUpdater>();
            _updater.Setup(c => c.Start());
            _updater.Setup(c => c.Dispose());

            _subject = new CurrentGameViewModel(_updater.Object);
        }

        [Test]
        public void Constructor_StartsUpdater()
        {
            _updater.Verify(c => c.Start(), Times.Once);
        }

        [Test]
        public void Constructor_SetsDefaultValueForPlayerName()
        {
            Assert.That(_subject.PlayerName, Is.EqualTo("Waiting to connect to a game")); 
        }
        
        [Test]
        public void Dispose_CallsUpdaterDispose()
        {
            _subject.Dispose();

            _updater.Verify(c => c.Dispose(), Times.Once);
        }

        [Test]
        public void Kills_WhenEdited_UpdateKillDeathRatioPropertyChanged()
        {
            List<string> propertiesChanged = new List<string>();
            _subject.PropertyChanged += (sender, args) => propertiesChanged.Add(args.PropertyName);

            _subject.Kills = 2;
            Assert.That(propertiesChanged.Contains("KillDeathRatio"));
        }

        [Test]
        public void KillDeathRatio_EqualsKillsDividedByDeaths()
        {
            _subject.Kills = 328947274;
            _subject.Deaths = 23424;

            var expected = (double)_subject.Kills / (double)_subject.Deaths;

           Assert.That(_subject.KillDeathRatio, Is.EqualTo(expected));
        }

        [Test]
        public void Deaths_WhenEdited_UpdateKillDeathRatioPropertyChanged()
        {
            List<string> propertiesChanged = new List<string>();
            _subject.PropertyChanged += (sender, args) => propertiesChanged.Add(args.PropertyName);

            _subject.Deaths = 2;
            Assert.That(propertiesChanged.Contains("KillDeathRatio"));
        }


        [Test]
        public void Properties_CallPropertyChanged()
        {
            List<string> propertiesChanged = new List<string>();
            _subject.PropertyChanged += (sender, args) => propertiesChanged.Add(args.PropertyName);

            _subject.Kills = 2;
            Assert.That(propertiesChanged.Contains("Kills"));

            _subject.PlayerName = "test";
            Assert.That(propertiesChanged.Contains("PlayerName"));

            _subject.Armor = 2;
            Assert.That(propertiesChanged.Contains("Armor"));

            _subject.AverageDamagePerDeath = 2;
            Assert.That(propertiesChanged.Contains("AverageDamagePerDeath"));
            
            _subject.AverageDamagePerRound = 2;
            Assert.That(propertiesChanged.Contains("AverageDamagePerRound"));
            
            _subject.CounterTerroristScore = 2;
            Assert.That(propertiesChanged.Contains("CounterTerroristScore"));

            _subject.CurrentMap = "test";
            Assert.That(propertiesChanged.Contains("CurrentMap"));

            _subject.CurrentPlayerAvatarUrl = "test";
            Assert.That(propertiesChanged.Contains("CurrentPlayerAvatarUrl"));

            _subject.CurrentRound = 2;
            Assert.That(propertiesChanged.Contains("CurrentRound"));

            _subject.Deaths = 2;
            Assert.That(propertiesChanged.Contains("Deaths"));

            _subject.DefuseKit = true;
            Assert.That(propertiesChanged.Contains("DefuseKit"));

            _subject.GameMode = "test";
            Assert.That(propertiesChanged.Contains("GameMode"));

            _subject.EquipValue = 34343;
            Assert.That(propertiesChanged.Contains("EquipValue"));

            _subject.Money = 34343;
            Assert.That(propertiesChanged.Contains("Money"));
        }
    }
}
