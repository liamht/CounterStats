using CounterStats.UI.ViewModels;

namespace CounterStats.UI.DesignTimeViewModels
{
   public class DesignTimeCurrentGameViewModel : CurrentGameViewModel
    {
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
