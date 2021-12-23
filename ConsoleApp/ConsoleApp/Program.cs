using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ConsoleApp.Profiles;
using ConsoleApp.Services;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace ConsoleApp;

internal class Program
{
    private static async Task Main(string[] args)
    {
        using var cts = new CancellationTokenSource();
        var token = cts.Token;

        Console.CancelKeyPress += (_, _) =>
        {
            cts.Cancel();
        };
        
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false)
            .AddEnvironmentVariables()
            .AddCommandLine(args)
            .Build();

        var config = configuration.Get<Configuration>();

        var redisConfig = new ConfigurationOptions
        {
            EndPoints =
            {
                config.RedisConnectionString
            }
        };
        
        using var redis = await ConnectionMultiplexer.ConnectAsync(redisConfig);

        var database = redis.GetDatabase();
        var serializer = new MsgPackSerializer();

        ICacheClient cacheClient = new RedisCacheClient(database, serializer, serializer, config.Ttl);
        
        var mapper = new MapperConfiguration((mapperConfig =>
        {
            mapperConfig.AddProfile(new AppProfile());
        })).CreateMapper();

        const string slackUrl = "https://slack.com";
        const string tokenType = "Bearer";
        
        using var httpClient = new HttpClient
        {
            BaseAddress = new Uri(slackUrl),
        };
        
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, config.SlackToken);

        var settings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            }
        };

        ISlackApiClient slackClient = new SlackApiClient(httpClient, settings);
        IStudentsService studentsService = new StudentsService(cacheClient, slackClient, mapper, config.RedisKey);
        
        var user = await studentsService.GetRandomStudent(token);

        Console.WriteLine($"{user.Name} ({user.RealName}), you've killed!");
    }
    
}