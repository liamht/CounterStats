using System;
using CounterStats.Business.Interfaces;

namespace CounterStats.UI.ViewModels
{
    public class LifetimeStatsViewModel
    {
        private ILifetimeStatisticsFetcher _fetcher;

        public long Kills { get; set; }

        public long Deaths { get; set; }

        public double KillDeathRatio { get; set; }

        public long DamageDone { get; set; }

        public LifetimeStatsViewModel(ILifetimeStatisticsFetcher fetcher)
        {
            _fetcher = fetcher;

            var stats = _fetcher.GetCsgoStats("76561198442886149");

            Kills = stats.Kills;
            Deaths = stats.Deaths;
            KillDeathRatio = Math.Round((double)Kills / (double)Deaths, 2);
            DamageDone = stats.DamageDone;
        }
    }
}
