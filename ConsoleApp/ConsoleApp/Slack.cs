using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Member
    {
        public string RealName { get; init; }
        public string Name { get; init; }
        public bool IsAdmin { get; init; }
        public bool IsOwner { get; init; }
        public bool IsBot { get; init; }
        public bool IsAppUser { get; init; }
        public bool IsPrimaryOwner { get; init; }
    }

    public class UsersResponse
    {
        public bool Ok { get; init; }
        public IEnumerable<Member> Members { get; init; }
    }

    internal class SlackApiClient
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
}
