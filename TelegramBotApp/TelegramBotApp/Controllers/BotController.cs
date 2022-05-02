using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using TelegramBotApp.Services;

namespace TelegramBotApp.Controllers
{
    public class BotController : ControllerBase
    {
        private readonly ITelegramServices _telegramServices;

        public BotController(ITelegramServices telegramService)
        {
            _telegramServices = telegramService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update, CancellationToken cancellationTokken = default)
        {
            await _telegramServices.HandleMessege(update, cancellationTokken);

            return Ok();
        }

    }
}
