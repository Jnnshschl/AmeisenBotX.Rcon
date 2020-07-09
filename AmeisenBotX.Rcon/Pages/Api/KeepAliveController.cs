using AmeisenBotX.Rcon.Api;
using AmeisenBotX.Rcon.Api.Objects.Messages;
using Microsoft.AspNetCore.Mvc;

namespace AmeisenBotX.Rcon.Pages.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeepAliveController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] KeepAliveMessage keepAliveMessage)
        {
            return RegisterManager.I.KeepAlive(keepAliveMessage) ? StatusCode(200) : StatusCode(400);
        }
    }
}