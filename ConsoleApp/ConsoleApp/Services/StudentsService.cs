using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ConsoleApp.Extensions;
using ConsoleApp.Models.Domain;

namespace ConsoleApp.Services;

internal interface IStudentsService
{
    Task<User> GetRandomStudent(CancellationToken cancellationToken = default);
}

internal class StudentsService : IStudentsService
{
    private readonly ICacheClient _cacheClient;
    private readonly ISlackApiClient _slackApiClient;
    private readonly IMapper _mapper;

    public StudentsService(ICacheClient cacheClient, ISlackApiClient slackApiClient, IMapper mapper)
    {
        _cacheClient = cacheClient;
        _slackApiClient = slackApiClient;
        _mapper = mapper;
    }

    public async Task<User> GetRandomStudent(CancellationToken cancellationToken = default)
    {
        var users = await _cacheClient.GetOrSet(new StringKey("users"), 
            async token => await GetUsersFromSlack(token), cancellationToken);
        
        var students = users.Where(UserExtensions.IsStudent).ToArray();

        if (!students.Any())
        {
            throw new Exception("No students in workspace");
        }

        var random = new Random((int)DateTime.Now.Ticks);
        return students[random.Next(0, students.Length)];
    }
    
    private async Task<IEnumerable<User>> GetUsersFromSlack(CancellationToken cancellationToken = default)
    {
        var result = await _slackApiClient.GetMembers(cancellationToken);

        if (!result.Ok)
        {
            throw new Exception("Slack API returned not OK");
        }

        return _mapper.Map<IEnumerable<User>>(result.Members);
    }
}