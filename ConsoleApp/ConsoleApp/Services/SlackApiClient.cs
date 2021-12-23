using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ConsoleApp.Models.Slack;
using Newtonsoft.Json;

namespace ConsoleApp.Services;

internal interface ISlackApiClient
{
    Task<UsersResponse> GetMembers(CancellationToken cancellationToken = default);
}

internal class SlackApiClient : ISlackApiClient
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerSettings _settings;

    public SlackApiClient(HttpClient httpClient, JsonSerializerSettings settings)
    {
        _httpClient = httpClient;
        _settings = settings;
    }

    public async Task<UsersResponse> GetMembers(CancellationToken cancellationToken = default)
    {
        using var response = await _httpClient.GetAsync("/api/users.list", cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Slack API returned {response.StatusCode}");
        }

        var content = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<UsersResponse>(content, _settings);

        return result;
    }
}