using CounterStats.ApiCaller;
using CounterStats.ApiCaller.HttpWebClient;
using CounterStats.Business;
using CounterStats.UI.ViewModels;

namespace CounterStats.UI.DesignTimeViewModels
{
    public class DesignTimeLifetimeStatsViewModel : LifetimeStatsViewModel
    {
        public long Kills => 23123;

        public DesignTimeLifetimeStatsViewModel() : base(new LifetimeStatisticsFetcher(new SteamApiCaller(new HttpWebClient())))
        {
        }
    }
}
