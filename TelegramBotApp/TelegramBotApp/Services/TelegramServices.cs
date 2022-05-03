using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramBotApp.Services
{
    public class TelegramServices : ITelegramServices 
    {
        private readonly ITelegramBotClient _telegramBotClient;
        private readonly IWeatherApiClient _weatherApiClient;

        public TelegramServices(ITelegramBotClient telegramBotClient, IWeatherApiClient weatherApiClient)
        {
            _telegramBotClient = telegramBotClient;
            _weatherApiClient = weatherApiClient;
        }

        public async Task HandleMessege(Update update, CancellationToken cancellationToken = default)
        {
            try
            {
                if (update.Type != UpdateType.Message)
                {
                    await _telegramBotClient.SendTextMessageAsync(update.Message.Chat.Id, $"I cannot handle {update}", cancellationToken: cancellationToken);

                    return;
                }

                if (update.Message.Equals("/start"))
                {
                    return;
                }

                var location = update.Message.Text;

                var weatherInfo = await _weatherApiClient.GetCurrentWeatherByLocation(location, cancellationToken);

                if (weatherInfo != null)
                {
                    await _telegramBotClient.SendTextMessageAsync(update.Message.Chat.Id, $"Weather in {weatherInfo.Name}, {weatherInfo.Sys.Country} is between {weatherInfo.Main.TempMin} and {weatherInfo.Main.TempMax}" +
                        $", current temp {weatherInfo.Main.Temp}", cancellationToken: cancellationToken);

                    return;
                }

                await _telegramBotClient.SendTextMessageAsync(update.Message.Chat.Id, $"I cannot find your location by query {location}.", cancellationToken: cancellationToken);

                return;
            }
            catch (Exception)
            {
                //ignore
            }
        }
    }
}
