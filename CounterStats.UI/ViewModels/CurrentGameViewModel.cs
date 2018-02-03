using System;
using System.ComponentModel;
using System.Media;
using System.Windows;
using CounterStats.Business.Events;
using CounterStats.Business.Interfaces;

namespace CounterStats.UI.ViewModels
{
    public class CurrentGameViewModel : BaseViewModel, IDisposable
    {
        #region Properties
        #region public string CurrentPlayerAvatarUrl
        private string _currentPlayerAvatarUrl;
        public string CurrentPlayerAvatarUrl
        {
            get { return _currentPlayerAvatarUrl; }
            set
            {
                if (_currentPlayerAvatarUrl == value)
                {
                    return;
                }
                _currentPlayerAvatarUrl = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentPlayerAvatarUrl"));
            }
        }
        #endregion

        #region public int GameRank
        private int _gameRank;

        public int GameRank
        {
            get { return _gameRank; }
            set
            {
                _gameRank = value;
                OnPropertyChanged(new PropertyChangedEventArgs("GameRank"));
            }
        }
        #endregion

        #region public int AverageDamagePerRound
        private int _averageDamagePerRound;

        public int AverageDamagePerRound
        {
            get { return _averageDamagePerRound; }
            set
            {
                _averageDamagePerRound = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AverageDamagePerRound"));
            }
        }
        #endregion

        #region public string PlayerName
        private string _playerName;
        public string PlayerName
        {
            get { return _playerName; }
            set
            {
                _playerName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("PlayerName"));
            }
        }
        #endregion

        #region public int CounterTerroristScore
        private int _counterTerroristScore;
        public int CounterTerroristScore
        {
            get { return _counterTerroristScore; }
            set
            {
                _counterTerroristScore = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CounterTerroristScore"));
            }
        }
        #endregion

        #region public int TerroristScore
        private int _terroristScore;
        public int TerroristScore
        {
            get { return _terroristScore; }
            set
            {
                _terroristScore = value;
                OnPropertyChanged(new PropertyChangedEventArgs("TerroristScore"));
            }
        }
        #endregion

        #region public int CurrentRound
        private int _currentScore;
        public int CurrentRound
        {
            get { return _currentScore; }
            set
            {
                _currentScore = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentRound"));
            }
        }
        #endregion

        #region public string CurrentMap
        private string _currentMap;
        public string CurrentMap
        {
            get { return _currentMap; }
            set
            {
                _currentMap = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CurrentMap"));
            }
        }
        #endregion

        #region public string GameMode
        private string _gameMode;
        public string GameMode
        {
            get { return _gameMode; }
            set
            {
                _gameMode = value;
                OnPropertyChanged(new PropertyChangedEventArgs("GameMode"));
            }
        }
        #endregion

        #region public int Kills
        private int _kills;
        public int Kills
        {
            get { return _kills; }
            set
            {
                _kills = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Kills"));
                OnPropertyChanged(new PropertyChangedEventArgs("KillDeathRatio"));
            }
        }
        #endregion

        #region public int Deaths
        private int _deaths;
        public int Deaths
        {
            get { return _deaths; }
            set
            {
                _deaths = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Deaths"));
                OnPropertyChanged(new PropertyChangedEventArgs("KillDeathRatio"));
            }
        }
        #endregion

        #region public double KillDeathRatio
        public double KillDeathRatio => Deaths == 0 ? Kills : (double)Kills / (double)Deaths;
        #endregion

        #region public double AverageDamagePerDeath

        private double _averageDamagePerDeath;
        public double AverageDamagePerDeath
        {
            get { return _averageDamagePerDeath; }
            set
            {
                _averageDamagePerDeath = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AverageDamagePerDeath"));
            }
        }

        #endregion

        #region public int MVPs
        private int _mvps;
        public int MVPs
        {
            get { return _mvps; }
            set
            {
                _mvps = value;
                OnPropertyChanged(new PropertyChangedEventArgs("MVPs"));
            }
        }
        #endregion

        #region public int Score
        private int _score;
        public int Score
        {
            get { return _score; }
            set
            {
                _score = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Score"));
            }
        }
        #endregion

        #region public int Money
        private int _money;
        public int Money
        {
            get { return _money; }
            set
            {
                _money = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Money"));
            }
        }
        #endregion

        #region public int EquipValue
        private int _equipValue;
        public int EquipValue
        {
            get { return _equipValue; }
            set
            {
                _equipValue = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EquipValue"));
            }
        }
        #endregion

        #region public int Health
        private int _health;
        public int Health
        {
            get { return _health; }
            set
            {
                _health = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Health"));
            }
        }
        #endregion

        #region public int Armor
        private int _armor;
        public int Armor
        {
            get { return _armor; }
            set
            {
                _armor = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Armor"));
            }
        }
        #endregion

        #region public bool DefuseKit
        private bool _defuseKit;
        public bool DefuseKit
        {
            get { return _defuseKit; }
            set
            {
                _defuseKit = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DefuseKit"));
            }
        }
        #endregion

        #region public bool Helmet
        private bool _helmet;
        public bool Helmet
        {
            get { return _helmet; }
            set
            {
                _helmet = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Helmet"));
            }
        }
        #endregion

        #region public bool IsGameInProgress
        private bool _isGameInProgress;
        public bool IsGameInProgress
        {
            get { return _isGameInProgress; }
            set
            {
                _isGameInProgress = value;
                OnPropertyChanged(new PropertyChangedEventArgs("IsGameInProgress"));
            }
        }
        #endregion
        #endregion

        private ICurrentGameUpdater _updater;

        public CurrentGameViewModel(ICurrentGameUpdater updater)
        {
            _updater = updater;
            _updater.OnKill += PlayKillSound;
            _updater.OnStateChange += UpdateViewModelWithNewState;
            _updater.OnNoGameInProgress += InformUserWeAreWaitingForAGameToStart;
            _updater.OnDeath += PlayDeathSound;

            PlayerName = "Waiting to connect to a game";


            DependencyObject dep = new DependencyObject();
            if (!DesignerProperties.GetIsInDesignMode(dep))
            {
                _updater.Start();
            }
        }

        private void InformUserWeAreWaitingForAGameToStart(object sender, EventArgs e)
        {
            IsGameInProgress = false;
        }

        private void PlayDeathSound(DeathEventArgs death)
        {
            if (!Properties.Settings.Default.PlayQuakeSounds)
            {
                return;
            }

            if (death.IsCurrentPlayer && death.CurrentDeathStreak == 7 & Kills == 0)
            {
                var player = new SoundPlayer($"Sounds/bond.wav");
                player.Play();
            }
        }

        private void PlayKillSound(KillEventArgs kill)
        {
            if (!Properties.Settings.Default.PlayQuakeSounds)
            {
                return;
            }

            var soundName = GetSoundFromKill(kill);

            if (soundName != null)
            {
                var player = new SoundPlayer($"Sounds/{soundName}.wav");
                player.Play();
            }
        }

        private string GetSoundFromKill(KillEventArgs kill)
        {
            if (kill.WasKnife && kill.KillsThisRound < 4)
            {
                return "assassin";
            }

            switch (kill.KillsThisRound)
            {
                case 1:
                    return kill.WasHeashot ? "headshot" : null;
                case 2:
                    return "doublekill";
                case 3:
                    return "megakill";
                case 4:
                    return "ultrakill";
                case 5:
                    return "monsterkill";
                default:
                    return "godlike";
            }
        }

        private void UpdateViewModelWithNewState(CsgoStateChangeEventArgs state)
        {
            IsGameInProgress = true;
            PlayerName = state.PlayerName;
            Kills = state.Kills;
            Deaths = state.Deaths;
            MVPs = state.MVPs;
            Score = state.Score;
            Armor = state.Armor;
            Health = state.Health;
            Helmet = state.Helmet;
            DefuseKit = state.DefuseKit;
            EquipValue = state.EquipValue;
            Money = state.Money;
            GameMode = state.GameMode;
            TerroristScore = state.TerroristScore;
            CounterTerroristScore = state.CounterTerroristScore;
            CurrentMap = state.CurrentMap;
            CurrentPlayerAvatarUrl = state.AvatarUrl;
        }

        public void Dispose()
        {
            _updater?.Dispose();
        }
    }
}
