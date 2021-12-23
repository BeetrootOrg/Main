using System.Collections.Generic;

namespace ConsoleApp.Models.Slack;

internal class UsersResponse
{
    public bool Ok { get; init; }
    public IEnumerable<Member> Members { get; init; }
}