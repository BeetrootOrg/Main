using System.Runtime.Serialization;

namespace ConsoleApp.Models.Domain;

[DataContract]
public class User
{
    [DataMember(Order = 0)]
    public string RealName { get; init; }
    
    [DataMember(Order = 1)]
    public string Name { get; init; }
    
    [DataMember(Order = 2)]
    public bool IsAdmin { get; init; }
    
    [DataMember(Order = 3)]
    public bool IsOwner { get; init; }
    
    [DataMember(Order = 4)]
    public bool IsBot { get; init; }
    
    [DataMember(Order = 5)]
    public bool IsAppUser { get; init; }
    
    [DataMember(Order = 6)]
    public bool IsPrimaryOwner { get; init; }
}