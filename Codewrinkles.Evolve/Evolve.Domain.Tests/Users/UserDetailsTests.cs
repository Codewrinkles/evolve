// UserDetailsTests.cs
using Xunit;
using Evolve.Domain.Users;
using Evolve.Domain.Users.Exceptions;

public class UserDetailsTests
{
    [Fact]
    public void Create_ValidEmailAndName_ReturnsUserDetailsObject()
    {
        // Arrange
        string email = "john.doe@example.com";
        Name name = Name.Create("John", "Doe");

        // Act
        UserDetails userDetails = UserDetails.Create(email, name);

        // Assert
        Assert.NotNull(userDetails);
        Assert.Equal(email, userDetails.Email);
        Assert.Equal(name, userDetails.Name);
    }

    [Theory]
    [InlineData("invalid-email")]
    public void Create_InvalidEmail_ThrowsInvalidEmailFormatException(string invalidEmail)
    {
        // Arrange
        Name name = Name.Create("John", "Doe");

        // Act & Assert
        var exception = Assert.Throws<InvalidEmailFormatException>(() => UserDetails.Create(invalidEmail, name));
        Assert.Equal($"\"{invalidEmail}\" is not a valid email format", exception.Message);
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("")]
    [InlineData(null)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1012:Null should only be used for nullable parameters", Justification = "<Pending>")]
    public void Create_NullOrEmptyEmail_ThrowsInvalidEmailFormatException(string invalidEmail)
    {
        // Arrange
        Name name = Name.Create("John", "Doe");
        // Act & Assert
        var exception = Assert.Throws<InvalidEmailFormatException>(() => UserDetails.Create(invalidEmail, name));
        Assert.Equal("Email cannot be null or empty", exception.Message);
    }
}
