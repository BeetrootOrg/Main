using ConsoleApp.Extensions;
using ConsoleApp.Models.Domain;
using Shouldly;
using Xunit;

namespace ConsoleApp.Tests;

public class UserExtensionsTests
{
    [Theory]
    [InlineData(false, false, false, false, false, true)]
    [InlineData(true, true, true, true, true, false)]
    [InlineData(true, false, false, false, false, false)]
    [InlineData(false, true, false, false, false, false)]
    [InlineData(false, false, true, false, false, false)]
    [InlineData(false, false, false, true, false, false)]
    [InlineData(false, false, false, false, true, false)]
    public void CheckIsStudent(bool isBot, bool isAdmin, bool isOwner, bool isAppUser, bool isPrimaryOwner, bool expected)
    {
        // Arrange
        var user = new User
        {
            IsAdmin = isAdmin,
            IsBot = isBot,
            IsOwner = isOwner,
            IsAppUser = isAppUser,
            IsPrimaryOwner = isPrimaryOwner
        };
        
        // Act
        var result = user.IsStudent();
        
        // Assert
        result.ShouldBe(expected);
    }
}