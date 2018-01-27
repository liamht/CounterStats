using CounterStats.Business.Interfaces;

namespace CounterStats.UI.ViewModels
{
    public class LifetimeStatsViewModel
    {
        private ILifetimeStatisticsFetcher _fetcher;

        public LifetimeStatsViewModel(ILifetimeStatisticsFetcher fetcher)
        {
                
        }
    }
}
