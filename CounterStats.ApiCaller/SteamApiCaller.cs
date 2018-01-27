using System.Collections.Generic;
using System.Linq;
using System.Net;
using CounterStats.ApiCaller.Entities;
using CounterStats.ApiCaller.HttpWebClient;
using Newtonsoft.Json;

namespace CounterStats.ApiCaller
{
    public sealed class SteamApiCaller : ISteamApiCaller
    {
        private const string API_KEY = "21F57B48034A17C22F1E49FD0C27D507";
        private IHttpWebClient _client;

        public SteamApiCaller(IHttpWebClient client)
        {
            _client = client;
        }

        public GetPlayerSummariesReturnValue GetPlayerSummaries(string steamId)
        {
            var url = $"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={API_KEY}&steamids={steamId}";

            var jsonString = _client.DownloadString(url);
            
            var innerResponse = new {players = new List<GetPlayerSummariesReturnValue>()};

            var outerResponse = new {response = innerResponse};
            var returnedObject = JsonConvert.DeserializeAnonymousType(jsonString, outerResponse);

            return returnedObject?.response?.players?.FirstOrDefault() ?? null;
        }

        public List<GetUserStatsForGameReturnValue> GetUserStatsForCounterStrikeGlobalOffensive(string steamId)
        {
            var url =$"http://api.steampowered.com/ISteamUserStats/GetUserStatsForGame/v0002/" +
                $"?appid=730&key={API_KEY}&steamid={steamId}";

            var jsonString = _client.DownloadString(url);

            var innerResponse = new { stats = new List<GetUserStatsForGameReturnValue>() };
            var outerResponse = new { playerstats = innerResponse };

            var returnedObject = JsonConvert.DeserializeAnonymousType(jsonString, outerResponse);

            return returnedObject?.playerstats?.stats?.ToList() ?? null;
        }
    }
}
