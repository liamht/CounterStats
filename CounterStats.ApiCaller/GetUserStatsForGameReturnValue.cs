using Newtonsoft.Json;

namespace CounterStats.ApiCaller
{
    public class GetUserStatsForGameReturnValue
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}