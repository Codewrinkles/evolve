using Evolve.Domain.Users;

namespace Evolve.Domain.Tests.Users;

public class MenteeTests
{
    [Fact]
    public void Mentee_DefaultValues_AreSetCorrectly()
    {
        // Arrange & Act
        Mentee mentee = new Mentee();

        // Assert
        Assert.NotNull(mentee);
        Assert.Equal(Guid.Empty, mentee.MenteeId);
        Assert.Null(mentee.UserDetails);
    }

    [Fact]
    public void Mentee_SetMenteeId_SetsValueCorrectly()
    {
        // Arrange
        Mentee mentee = new Mentee();
        Guid expectedId = Guid.NewGuid();

        // Act
        mentee.MenteeId = expectedId;

        // Assert
        Assert.Equal(expectedId, mentee.MenteeId);
    }

    [Fact]
    public void Mentee_SetUserDetails_SetsValueCorrectly()
    {
        // Arrange
        Mentee mentee = new Mentee();
        Name name = Name.Create("Alice", "Smith");
        UserDetails userDetails = UserDetails.Create("alice.smith@example.com", name);

        // Act
        mentee.UserDetails = userDetails;

        // Assert
        Assert.Equal(userDetails, mentee.UserDetails);
    }
}