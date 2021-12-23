using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using ConsoleApp.Models.Slack;
using ConsoleApp.Services;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace ConsoleApp.Tests;

public class SlackApiClientTests
{
    private const string BaseUrl = "https://test.com";
    
    private readonly HttpMessageHandlerMock _messageHandler;
    private readonly Faker _faker;
    private readonly Faker<Member> _memberFaker;

    private SlackApiClient _slackApiClient;

    public SlackApiClientTests()
    {
        _messageHandler = new HttpMessageHandlerMock();
        var client = new HttpClient(_messageHandler)
        {
            BaseAddress = new Uri(BaseUrl)
        };

        _faker = new Faker();

        _memberFaker = new Faker<Member>()
            .RuleFor(x => x.Name, f => f.Person.UserName)
            .RuleFor(x => x.RealName, f => f.Name.FullName())
            .RuleFor(x => x.IsAdmin, f => f.Random.Bool())
            .RuleFor(x => x.IsPrimaryOwner, f => f.Random.Bool())
            .RuleFor(x => x.IsBot, f => f.Random.Bool())
            .RuleFor(x => x.IsAppUser, f => f.Random.Bool())
            .RuleFor(x => x.IsOwner, f => f.Random.Bool());
        
        _slackApiClient = new SlackApiClient(client, new JsonSerializerSettings());
    }

    [Fact]
    public async Task GetMembersShouldReturnCorrectResponse()
    {
        // Arrange
        var members = _memberFaker.GenerateBetween(0, 20);

        var expected = new UsersResponse
        {
            Ok = _faker.Random.Bool(),
            Members = members
        };
        
        using var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}/api/users.list");
        using var response = new HttpResponseMessage
        {
            Content = new StringContent(JsonConvert.SerializeObject(expected), Encoding.UTF8,
                System.Net.Mime.MediaTypeNames.Application.Json)
        };
        
        _messageHandler.Setup(request, response);
        
        // Act
        var result = await _slackApiClient.GetMembers();
        
        // Arrange
        result.Ok.ShouldBe(expected.Ok);
        result.Members.ShouldBe(expected.Members, new MemberEqualityComparer());
    }
    
    
    [Fact]
    public async Task GetMembersShouldThrowException()
    {
        // Arrange
        using var request = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl}/api/users.list");
        using var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        
        _messageHandler.Setup(request, response);
        
        // Act
        Func<Task> resultAction = () => _slackApiClient.GetMembers();
        
        // Arrange
        await resultAction.ShouldThrowAsync<Exception>();
    }
}