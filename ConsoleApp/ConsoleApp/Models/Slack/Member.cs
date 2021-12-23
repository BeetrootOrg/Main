namespace ConsoleApp.Models.Slack;

internal class Member
{
    public string RealName { get; init; }
    public string Name { get; init; }
    public bool IsAdmin { get; init; }
    public bool IsOwner { get; init; }
    public bool IsBot { get; init; }
    public bool IsAppUser { get; init; }
    public bool IsPrimaryOwner { get; init; }
}
