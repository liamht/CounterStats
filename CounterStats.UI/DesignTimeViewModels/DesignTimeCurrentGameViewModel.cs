using System;

namespace CounterStats.UI.DesignTimeViewModels
{
   public class DesignTimeCurrentGameViewModel
    {
        public int Money { get; set; }

        public int EquipValue { get; set; }

        public bool DefuseKit { get; set; }

        public bool Helmet { get; set; }

        public int Health { get; set; }

        public int Armor { get; set; }

        public string GameMode { get; set; }

        public string PlayerName { get; set; }

        public int Score { get; set; }

        public int Deaths { get; set; }

        public int Kills { get; set; }

        public int CurrentRound { get; set; }

        public string CurrentMap { get; set; }

        public double AverageDamagePerDeath { get; set; }

        public int GameRank { get; set; }

        public int AverageDamagePerRound { get; set; }

        public int TerroristScore { get; set; }

        public int CounterTerroristScore { get; set; }

        public string CurrentPlayerAvatarUrl { get; set; }

        public int MVPs { get; set; }

        public double KillDeathRatio => Math.Round(Kills / (double) Deaths, 2);

        public bool IsGameInProgress { get; set;  }

        public DesignTimeCurrentGameViewModel()
        {
            CurrentPlayerAvatarUrl =
                "https://steamcdn-a.akamaihd.net/steamcommunity/public/images/avatars/30/3026aa465f37e0b836bd84ddc397584a9f899002_medium.jpg";
            CounterTerroristScore = 14;
            TerroristScore = 13;
            AverageDamagePerRound = 86;
            GameRank = 4;
            AverageDamagePerDeath = 100.29;
            CurrentMap = "de_mirage";
            CurrentRound = 28;
            Kills = 7;
            Deaths = 19;
            MVPs = 2;
            Score = 21;
            PlayerName = "Chiken";
            GameMode = "Competitive";
            Armor = 85;
            Health = 98;
            Helmet = true;
            DefuseKit = false;
            EquipValue = 5850;
            Money = 14250;
        }
    }
}
