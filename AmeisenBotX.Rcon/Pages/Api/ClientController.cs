using AmeisenBotX.Rcon.Api;
using AmeisenBotX.Rcon.Api.Objects;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace AmeisenBotX.Rcon.Pages.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(JsonConvert.SerializeObject(RegisterManager.I.Clients.OrderBy(e => e.Name)));
        }

        [HttpGet("{guid}")]
        public IActionResult GetByGuid(string guid)
        {
            BotClient client = RegisterManager.I.Clients.FirstOrDefault(e => e.Guid.Equals(guid, StringComparison.OrdinalIgnoreCase));

            if (client != null)
            {
                return Ok(JsonConvert.SerializeObject(client));
            }
            else
            {
                return NotFound();
            }
        }
    }
}