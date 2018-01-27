using CounterStats.ApiCaller;
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
    }
}
