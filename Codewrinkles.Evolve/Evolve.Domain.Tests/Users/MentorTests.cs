// MentorTests.cs
using Xunit;
using Evolve.Domain.Users;
using System;

namespace Evolve.Domain.Tests.Users;

public class MentorTests
{
    [Fact]
    public void Mentor_DefaultValues_AreSetCorrectly()
    {
        // Arrange & Act
        Mentor mentor = new Mentor();

        // Assert
        Assert.NotNull(mentor);
        Assert.Equal(Guid.Empty, mentor.MentorId);
        Assert.Null(mentor.UserDetails);
    }

    [Fact]
    public void Mentor_SetMentorId_SetsValueCorrectly()
    {
        // Arrange
        Mentor mentor = new Mentor();
        Guid expectedId = Guid.NewGuid();

        // Act
        mentor.MentorId = expectedId;

        // Assert
        Assert.Equal(expectedId, mentor.MentorId);
    }

    [Fact]
    public void Mentor_SetUserDetails_SetsValueCorrectly()
    {
        // Arrange
        Mentor mentor = new Mentor();
        Name name = Name.Create("Jane", "Smith");
        UserDetails userDetails = UserDetails.Create("jane.smith@example.com", name);

        // Act
        mentor.UserDetails = userDetails;

        // Assert
        Assert.Equal(userDetails, mentor.UserDetails);
    }
}