using AmeisenBotX.Rcon.Api;
using AmeisenBotX.Rcon.Api.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;

namespace AmeisenBotX.Rcon.Pages
{
    public class BotModel : PageModel
    {
        public BotClient BotClient { get; set; }

        public IActionResult OnGet(string guid)
        {
            BotClient = RegisterManager.I.Clients.FirstOrDefault(e => e.Guid.Equals(guid, StringComparison.OrdinalIgnoreCase));

            if (BotClient == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}