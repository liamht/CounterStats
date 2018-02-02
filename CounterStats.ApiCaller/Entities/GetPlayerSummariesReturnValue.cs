using Newtonsoft.Json;

namespace CounterStats.ApiCaller.Entities
{
    public class GetPlayerSummariesReturnValue
    {
        [JsonProperty("steamid")]
        public string SteamId { get; set; }

        [JsonProperty("avatar")]
        public string Avatar { get; set; }

        [JsonProperty("avatarmedium")]
        public string AvatarMedium { get; set; }

        [JsonProperty("avatarfull")]
        public string AvatarFull { get; set; }

        [JsonProperty("personaname")]
        public string UserName { get; set; }
    }
}
