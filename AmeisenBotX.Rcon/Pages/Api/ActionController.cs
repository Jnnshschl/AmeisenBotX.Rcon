using AmeisenBotX.Rcon.Api;
using AmeisenBotX.Rcon.Api.Enums;
using AmeisenBotX.Rcon.Api.Objects.Messages;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AmeisenBotX.Rcon.Pages.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        [HttpGet("{guid}")]
        public IActionResult Get(string guid)
        {
            if (RegisterManager.I.TryGetPendingActions(guid, out string json))
            {
                return Ok(json);
            }

            return StatusCode(400);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ActionMessage actionMessage)
        {
            return Enum.TryParse(actionMessage.Action, true, out ActionType actionType)
                   && RegisterManager.I.AddPendingAction(actionMessage.Guid, actionType) ? StatusCode(200) : StatusCode(400);
        }
    }
}