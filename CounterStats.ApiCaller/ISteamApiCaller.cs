using System.Collections.Generic;
using CounterStats.ApiCaller.Entities;

namespace CounterStats.ApiCaller
{
    public interface ISteamApiCaller
    {
        GetPlayerSummariesReturnValue GetPlayerSummaries(string steamId);
        List<GetUserStatsForGameReturnValue> GetUserStatsForCounterStrikeGlobalOffensive(string steamId);
    }
}