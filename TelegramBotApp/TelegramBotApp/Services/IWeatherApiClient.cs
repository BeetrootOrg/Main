using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TelegramBotApp.Model;

namespace TelegramBotApp.Services
{
    public interface IWeatherApiClient
    {
        //Task<IEnumerable<Location>> GetLocationsByQuery(string query,
        //    CancellationToken cancellationToken = default);

        Task<WeatherResponseModel> GetCurrentWeatherByLocation(string location, CancellationToken cancellationToken = default);
    }
}
