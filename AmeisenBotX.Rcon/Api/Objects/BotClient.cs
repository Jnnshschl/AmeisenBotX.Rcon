using AmeisenBotX.Rcon.Api.Enums;
using AmeisenBotX.Rcon.Api.Objects.Messages;
using AmeisenBotX.Rcon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AmeisenBotX.Rcon.Api.Objects
{
    public class BotClient
    {
        public BotClient(RegisterMessage registerMessage)
        {
            RegisterMessage = registerMessage;
            RegistrationTimestamp = DateTime.Now;
        }

        public DateTime ActiveSince { get; set; }

        public string ActiveSinceString
        {
            get
            {
                if (IsAlive)
                {
                    if (ActiveSince == default)
                    {
                        ActiveSince = DateTime.Now;
                    }
                }
                else
                {
                    ActiveSince = default;
                    return TimeSpan.FromSeconds(0).ToString("hh\\:mm\\:ss");
                }

                return (DateTime.Now - ActiveSince).ToString("hh\\:mm\\:ss");
            }
        }

        public string Class => RconUtils.Capitalize(RegisterMessage.Class);

        public DataMessage Data => DataMessages.LastOrDefault();

        public List<DataMessage> DataMessages { get; } = new List<DataMessage>();

        public string Gender => RconUtils.Capitalize(RegisterMessage.Gender);

        public string Guid => RegisterMessage.Guid;

        public string Image => RegisterMessage.Image;

        public bool IsAlive => DateTime.Now - LastKeepAlive < TimeSpan.FromSeconds(2);

        public DateTime LastKeepAlive { get; private set; }

        public string LastKeepAliveString => $"{Math.Ceiling((DateTime.Now - LastKeepAlive).TotalSeconds)} s";

        public string LastScreenImage { get; set; }

        public string Name => RegisterMessage.Name;

        public List<ActionType> PendingActions { get; set; } = new List<ActionType>();

        public string Race => RconUtils.Capitalize(RegisterMessage.Race);

        public DateTime RegistrationTimestamp { get; }

        public string Role => RegisterMessage.Role.ToUpper() switch
        {
            "DPS" => "🗡",
            "TANK" => "🛡",
            "HEAL" => "➕",
            _ => "unk",
        };

        private RegisterMessage RegisterMessage { get; }

        public void KeepAlive()
        {
            LastKeepAlive = DateTime.Now;
        }
    }
}