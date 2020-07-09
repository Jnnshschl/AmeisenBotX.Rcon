using Newtonsoft.Json;

namespace AmeisenBotX.Rcon.Api.Objects.Messages
{
    public class ActionMessage
    {
        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("guid")]
        public string Guid { get; set; }
    }
}