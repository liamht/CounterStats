using System;
using System.Linq;
using CounterStats.ApiCaller;
using CounterStats.Business.Entities;
using CounterStats.Business.Interfaces;

namespace CounterStats.Business
{
    public class LifetimeStatisticsFetcher : ILifetimeStatisticsFetcher
    {
        private ISteamApiCaller _apiCaller;

        public LifetimeStatisticsFetcher(ISteamApiCaller apiCaller)
        {
            _apiCaller = apiCaller;
        }

        public CsGoStats GetCsgoStats(string steamId)
        {
            var result = _apiCaller.GetUserStatsForCounterStrikeGlobalOffensive(steamId);
            return new CsGoStats(result);
        }
    }
}
