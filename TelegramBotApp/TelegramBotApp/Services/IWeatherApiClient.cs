using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TelegramBotApp.Services
{
    public interface IWeatherApiClient
    {
        //Task<IEnumerable<Location>> GetLocationsByQuery(string query,
        //    CancellationToken cancellationToken = default);

        Task<WeatherInfo> GetCurrentWeatherByLocation(string location, CancellationToken cancellationToken = default);
    }
}
