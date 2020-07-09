using Newtonsoft.Json;

namespace AmeisenBotX.Rcon.Api.Objects.Messages
{
    public class KeepAliveMessage
    {
        [JsonProperty("guid")]
        public string Guid { get; set; }
    }
}