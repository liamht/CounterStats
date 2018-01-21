using System;
using System.Linq;
using CSGSI;
using CSGSI.Nodes;

namespace CounterStats.Business
{
    public class CsgoStateChangeEventArgs
    {
        public string PlayerName { get; internal set; }
        public int Kills { get; internal set; }
        public int Deaths { get; internal set; }
        public int MVPs { get; internal set; }
        public int Score { get; internal set; }
        public int Armor { get; internal set; }
        public int Health { get; internal set; }
        public bool Helmet { get; internal set; }
        public bool DefuseKit { get; internal set; }
        public int EquipValue { get; internal set; }
        public int Money { get; internal set; }
        public string GameMode { get; internal set; }
        public int TerroristScore { get; internal set; }
        public int CounterTerroristScore { get; internal set; }
        public string CurrentMap { get; internal set; }
        public string AvatarUrl { get; internal set; }

        internal static CsgoStateChangeEventArgs FromGameState(GameState state, string avatarUrl)
        {
            return new CsgoStateChangeEventArgs()
            {
                PlayerName = state.Player.Name,
                Kills = state.Player.MatchStats.Kills,
                Deaths = state.Player.MatchStats.Deaths,
                MVPs = state.Player.MatchStats.MVPs,
                Score = state.Player.MatchStats.Score,
                Armor = state.Player.State.Armor,
                Health = state.Player.State.Health,
                Helmet = state.Player.State.Helmet,
                DefuseKit = state.Player.State.DefuseKit,
                EquipValue = state.Player.State.EquipValue,
                Money = state.Player.State.Money,
                GameMode = Enum.GetName(typeof(MapMode), state.Map.Mode),
                TerroristScore = state.Map.TeamT.Score,
                CounterTerroristScore = state.Map.TeamCT.Score,
                CurrentMap = state.Map.Name.Contains("_")
                    ? state.Map.Name.Split('_').Last()
                    : state.Map.Name.TrimStart('d', 'e'),
                AvatarUrl = avatarUrl
            };
        }
    }
}