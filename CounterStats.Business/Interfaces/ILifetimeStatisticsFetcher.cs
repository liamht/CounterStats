using CounterStats.Business.Entities;

namespace CounterStats.Business.Interfaces
{
    public interface ILifetimeStatisticsFetcher
    {
        CsGoStats GetCsgoStats(string steamId);
    }
}
