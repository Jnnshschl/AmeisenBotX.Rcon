using AmeisenBotX.Rcon.Api.Enums;
using AmeisenBotX.Rcon.Api.Objects;
using AmeisenBotX.Rcon.Api.Objects.Messages;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace AmeisenBotX.Rcon.Api
{
    public class RegisterManager
    {
        private static readonly object synclock = new object();
        private static RegisterManager instance;

        private RegisterManager()
        {
        }

        public static RegisterManager I => instance ??= new RegisterManager();

        public List<BotClient> AliveClients => Clients.Where(e => e.IsAlive).ToList();

        public ConcurrentBag<BotClient> Clients { get; } = new ConcurrentBag<BotClient>();

        public List<BotClient> DeadClients => Clients.Where(e => !e.IsAlive).ToList();

        public bool AddData(DataMessage dataMessage)
        {
            BotClient client = Clients.FirstOrDefault(e => e.Guid == dataMessage.Guid);

            if (client != null)
            {
                if (client.DataMessages.Count > 1000)
                {
                    client.DataMessages.RemoveAt(0);
                }

                client.DataMessages.Add(dataMessage);
                client.KeepAlive();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddImage(ImageMessage imageMessage)
        {
            BotClient client = Clients.FirstOrDefault(e => e.Guid == imageMessage.Guid);

            if (client != null)
            {
                client.LastScreenImage = imageMessage.Image;
                client.KeepAlive();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddPendingAction(string guid, ActionType action)
        {
            BotClient client = Clients.FirstOrDefault(e => e.Guid == guid);

            if (client != null)
            {
                if (!client.PendingActions.Contains(action))
                {
                    client.PendingActions.Add(action);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool KeepAlive(KeepAliveMessage keepAliveMessage)
        {
            BotClient client = Clients.FirstOrDefault(e => e.Guid == keepAliveMessage.Guid);

            if (client != null)
            {
                client.KeepAlive();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Register(RegisterMessage registerMessage)
        {
            lock (synclock)
            {
                if (!Clients.Any(e => e.Guid == registerMessage.Guid))
                {
                    BotClient client = new BotClient(registerMessage);
                    client.KeepAlive();
                    Clients.Add(client);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool TryGetPendingActions(string guid, out string json)
        {
            json = "";
            BotClient client = Clients.FirstOrDefault(e => e.Guid == guid);

            if (client != null)
            {
                json = JsonConvert.SerializeObject(client.PendingActions);
                client.PendingActions.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}