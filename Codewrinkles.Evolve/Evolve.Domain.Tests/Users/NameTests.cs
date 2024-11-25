// NameTests.cs
using Xunit;
using Evolve.Domain.Users;
using System;
using System.Xml.Linq;
using Evolve.Domain.Users.Exceptions;

public class NameTests
{
    [Fact]
    public void Create_ValidFirstNameAndLastName_ReturnsNameObject()
    {
        // Arrange
        string firstName = "John";
        string lastName = "Doe";

        // Act
        Name name = Name.Create(firstName, lastName);

        // Assert
        Assert.NotNull(name);
        Assert.Equal(firstName, name.FirstName);
        Assert.Equal(lastName, name.LastName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("A")]
    [InlineData("ThisIsAFirstNameThatIsWayTooLongAndShouldExceedTheMaximumAllowedNumberOfCharactersInAFirstNamexxxxxxxxxxxxxx")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1012:Null should only be used for nullable parameters", Justification = "<Pending>")]
    public void Create_InvalidFirstName_ThrowsInvalidCastException(string invalidFirstName)
    {
        // Arrange
        string lastName = "Doe";

        // Act & Assert
        var exception = Assert.Throws<InvalidNameException>(() => Name.Create(invalidFirstName, lastName));
        Assert.Equal("First name must be between 2 and 100 characters", exception.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("B")]
    [InlineData("ThisIsALastNameThatIsWayTooLongAndShouldExceedTheMaximumAllowedNumberOfCharactersInALastNamexxxxxxxxxxxxxxx")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "xUnit1012:Null should only be used for nullable parameters", Justification = "<Pending>")]
    public void Create_InvalidLastName_ThrowsInvalidCastException(string invalidLastName)
    {
        // Arrange
        string firstName = "John";

        // Act & Assert
        var exception = Assert.Throws<InvalidNameException>(() => Name.Create(firstName, invalidLastName));
        Assert.Equal("Last name must be between 2 and 100 characters", exception.Message);
    }

    [Fact]
    public void FullName_ReturnsConcatenatedFirstNameAndLastName()
    {
        // Arrange
        Name name = Name.Create("John", "Doe");

        // Act
        string fullName = name.FullName;

        // Assert
        Assert.Equal("John Doe", fullName);
    }

    [Fact]
    public void Initials_ReturnsCapitalizedFirstLettersOfNames()
    {
        // Arrange
        Name name = Name.Create("john", "doe");

        // Act
        string initials = name.Initials;

        // Assert
        Assert.Equal("JD", initials);
    }
}
