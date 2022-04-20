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

                var query = update.Message.Text;
                var locations = await _weatherApiClient.GetLocationsByQuery(query, cancellationToken);
                var location = locations?.FirstOrDefault();

                if (location == null)
                {
                    await _telegramBotClient.SendTextMessageAsync(update.Message.Chat.Id, $"I cannot find your location {query}", cancellationToken: cancellationToken);

                    return;
                }

                var weatherInfo = await _weatherApiClient.GetWeatherByWoeid(location.Woeid, cancellationToken);
                var weather = weatherInfo?.ConsolidatedWeather?.OrderBy(cw => cw.ApplicableDate).FirstOrDefault();

                if (weather != null)
                {
                    await _telegramBotClient.SendTextMessageAsync(update.Message.Chat.Id, $"Weather in {weatherInfo.Title} is between {weather.MinTemp} and {weather.MaxTemp}", cancellationToken: cancellationToken);

                    return;
                }

                await _telegramBotClient.SendTextMessageAsync(update.Message.Chat.Id, $"I cannot find your location by query {query}.", cancellationToken: cancellationToken);

                return;
            }
            catch (Exception)
            {
                //ignore
            }
        }
    }
}
