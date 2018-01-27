using CounterStats.ApiCaller.Entities;

namespace CounterStats.ApiCaller
{
    public interface ISteamApiCaller
    {
        GetPlayerSummariesReturnValue GetPlayerSummaries(string steamId);
        GetUserStatsForGameReturnValue GetUserStatsForCounterStrikeGlobalOffensive(string steamId);
    }
}