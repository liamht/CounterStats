using CounterStats.UI.ViewModels;

namespace CounterStats.UI.DesignTimeViewModels
{
    public class DesignTimeLifetimeStatsViewModel : LifetimeStatsViewModel
    {
        public long Kills => 23123;

        public DesignTimeLifetimeStatsViewModel() : base(null)
        {
        }
    }
}
