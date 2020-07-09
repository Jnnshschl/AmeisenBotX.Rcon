using Newtonsoft.Json;

namespace AmeisenBotX.Rcon.Api.Objects.Messages
{
    public class ImageMessage
    {
        [JsonProperty("guid")]
        public string Guid { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }
    }
}