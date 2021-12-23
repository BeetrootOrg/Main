using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main()
        {
            const string slackBotToken = "SLACK_BOT_TOKEN";
            using var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://slack.com"),
            };

            var token = Environment.GetEnvironmentVariable(slackBotToken);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };

            var slackClient = new SlackApiClient(httpClient, settings);
            var result = await slackClient.GetMembers();

            if (!result.Ok)
            {
                throw new Exception("Slack API returned not OK");
            }

            var students = result.Members
                .Where(member => !member.IsBot && !member.IsAdmin && !member.IsOwner && !member.IsAppUser && !member.IsPrimaryOwner)
                .ToArray();

            if (!students.Any())
            {
                throw new Exception("No students in workspace");
            }

            var random = new Random((int)DateTime.Now.Ticks);
            var user = students[random.Next(0, students.Length)];

            Console.WriteLine($"{user.Name} ({user.RealName}), you've killed!");
        }
    }
}