using AmeisenBotX.Rcon.Api;
using AmeisenBotX.Rcon.Api.Objects.Messages;
using Microsoft.AspNetCore.Mvc;

namespace AmeisenBotX.Rcon.Pages.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] ImageMessage imageMessage)
        {
            return RegisterManager.I.AddImage(imageMessage) ? StatusCode(200) : StatusCode(400);
        }
    }
}