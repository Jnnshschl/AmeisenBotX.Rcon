using AmeisenBotX.Rcon.Api;
using AmeisenBotX.Rcon.Api.Objects.Messages;
using Microsoft.AspNetCore.Mvc;

namespace AmeisenBotX.Rcon.Pages.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] RegisterMessage registerMessage)
        {
            return RegisterManager.I.Register(registerMessage) ? StatusCode(200) : StatusCode(400);
        }
    }
}