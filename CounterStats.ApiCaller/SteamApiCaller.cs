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
        private string _apiKey;
        private IHttpWebClient _client;

        public SteamApiCaller(IHttpWebClient client, string apiKey)
        {
            _apiKey = apiKey;
            _client = client;
        }

        public GetPlayerSummariesReturnValue GetPlayerSummaries(string steamId)
        {
            var url = $"http://api.steampowered.com/ISteamUser/GetPlayerSummaries/v0002/?key={_apiKey}&steamids={steamId}";

            var jsonString = _client.DownloadString(url);
            
            var innerResponse = new {players = new List<GetPlayerSummariesReturnValue>()};

            var outerResponse = new {response = innerResponse};
            var returnedObject = JsonConvert.DeserializeAnonymousType(jsonString, outerResponse);

            return returnedObject?.response?.players?.FirstOrDefault() ?? null;
        }

        public List<GetUserStatsForGameReturnValue> GetUserStatsForCounterStrikeGlobalOffensive(string steamId)
        {
            var url =$"http://api.steampowered.com/ISteamUserStats/GetUserStatsForGame/v0002/" +
                $"?appid=730&key={_apiKey}&steamid={steamId}";

            var jsonString = _client.DownloadString(url);

            var innerResponse = new { stats = new List<GetUserStatsForGameReturnValue>() };
            var outerResponse = new { playerstats = innerResponse };

            var returnedObject = JsonConvert.DeserializeAnonymousType(jsonString, outerResponse);

            return returnedObject?.playerstats?.stats?.ToList() ?? null;
        }
    }
}
