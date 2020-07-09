using AmeisenBotX.Rcon.Api;
using AmeisenBotX.Rcon.Api.Objects.Messages;
using Microsoft.AspNetCore.Mvc;

namespace AmeisenBotX.Rcon.Pages.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] DataMessage dataMessage)
        {
            return RegisterManager.I.AddData(dataMessage) ? StatusCode(200) : StatusCode(400);
        }
    }
}