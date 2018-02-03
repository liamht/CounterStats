using System;
using CSGSI;
using CSGSI.Nodes;
using CounterStats.ApiCaller;
using CounterStats.Business.Events;
using CounterStats.Business.Interfaces;

namespace CounterStats.Business
{
    public class CurrentGameUpdater : ICurrentGameUpdater
    {
        public event CsgoStateChangeHandler OnStateChange;
        public event CsgoDeathHandler OnDeath;
        public event CsgoKillHandler OnKill;
        public event EventHandler OnCouldNotStartListening;
        public event EventHandler OnNoGameInProgress;

        private readonly ISteamApiCaller _csgoApiHelper;
        private bool _isListenerRunning;

        private string _mainUserId;
        private string _currentUserId;
        private int _currentRoundNumber;
        private int _cachedRoundKills;
        private int _cachedMatchKills;
        private int _cachedRoundHeadshots;
        private int _cachedDeaths;
        private string _cachedPlayerAvatarUrl;
        private bool _hasUserChanged;
        private int _deathStreak;
        private GameStateListener _csgoApiListener;

        public CurrentGameUpdater(GameStateListener apiListener, ISteamApiCaller csgoApiHelper)
        {
            _csgoApiListener = apiListener;
            _csgoApiHelper = csgoApiHelper;
        }

        public void Start()
        {
            _csgoApiListener = new GameStateListener(12455);
            _csgoApiListener.NewGameState += OnNewGameState;

            _isListenerRunning = _csgoApiListener.Start();
            if (!_isListenerRunning)
            {
                OnCouldNotStartListening?.Invoke(this, EventArgs.Empty);
            }
        }

        private void OnNewGameState(GameState gs)
        {
            if (gs.Player.Team == PlayerTeam.Undefined)
            {
                OnNoGameInProgress?.Invoke(this, EventArgs.Empty);
                return;
            }

            if (gs.Player.SteamID != _currentUserId)
            {
                _hasUserChanged = true;
                _currentUserId = gs.Provider.SteamID;
                UpdatePlayerCachedAvatar(gs);
            }

            var args = CsgoStateChangeEventArgs.FromGameState(gs, _cachedPlayerAvatarUrl);
            OnStateChange?.Invoke(args);

            InvokeStateSpecificEvents(gs);

            _hasUserChanged = false;
        }

        private void UpdatePlayerCachedAvatar(GameState gs)
        {
            var profile = _csgoApiHelper.GetPlayerSummaries(gs.Player.SteamID);
            _cachedPlayerAvatarUrl = profile.AvatarMedium;
        }

        private void InvokeStateSpecificEvents(GameState gs)
        {
            if (gs.Map.Round != _currentRoundNumber && gs.Round.Phase == RoundPhase.Live)
            {
                ResetRoundCachedValues(gs);
            }
            if (gs.Player.MatchStats.Deaths > _cachedDeaths)
            {
                OnPlayerGotKilled(gs);
            }
            if (gs.Player.MatchStats.Kills > _cachedMatchKills)
            {
                OnPlayerGotKill(gs);
            }
        }

        private void ResetRoundCachedValues(GameState gs)
        {
            _currentRoundNumber = gs.Map.Round;
            _cachedRoundKills = gs.Player.State.RoundKills;
            _cachedMatchKills = gs.Player.MatchStats.Kills;
            _cachedRoundHeadshots = gs.Player.State.RoundKillHS;
            _cachedDeaths = gs.Player.MatchStats.Deaths;
            _mainUserId = gs.Player.SteamID;
        }

        private void OnPlayerGotKilled(GameState gs)
        {
            _cachedDeaths = gs.Player.MatchStats.Deaths;

            if (gs.Map.Mode == MapMode.DeathMatch)
            {
                _cachedRoundHeadshots = 0;
                _cachedRoundKills = 0;
            }

            var args = new DeathEventArgs();

            if (_mainUserId == gs.Player.SteamID && gs.Map.Mode != MapMode.Undefined)
            {
                _deathStreak++;
                args.CurrentDeathStreak = _deathStreak;
                args.IsCurrentPlayer = true;
            }

            OnDeath?.Invoke(args);
        }

        private void OnPlayerGotKill(GameState gs)
        {
            if (_hasUserChanged)
            {
                return;
            }
            _cachedMatchKills = gs.Player.MatchStats.Kills;
            _cachedRoundKills = gs.Player.State.RoundKills;

            var args = new KillEventArgs();
            args.WasHeashot = gs.Player.State.RoundKillHS > _cachedRoundHeadshots;
            args.WasKnife = gs.Player.Weapons.ActiveWeapon.Type == WeaponType.Knife;
            args.KillsThisRound = _cachedRoundKills;

            if (args.WasHeashot)
            {
                _cachedRoundHeadshots = gs.Player.State.RoundKillHS;
            }

            OnKill?.Invoke(args);
        }

        public void Dispose()
        {
            if (_isListenerRunning)
            {
                _isListenerRunning = false;
            }
            if (_csgoApiListener.Running)
            {
                _csgoApiListener.Stop();
            }
        }
    }
}
