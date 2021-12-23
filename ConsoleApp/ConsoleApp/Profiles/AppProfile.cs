using AutoMapper;
using ConsoleApp.Models.Domain;
using ConsoleApp.Models.Slack;

namespace ConsoleApp.Profiles;

internal class AppProfile : Profile
{
    public AppProfile()
    {
        CreateMap<Member, User>();
    }
}