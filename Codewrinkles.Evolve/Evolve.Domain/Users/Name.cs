

using Evolve.Domain.Users.Exceptions;
using System.Diagnostics.CodeAnalysis;

namespace Evolve.Domain.Users;
public class Name
{
    [SetsRequiredMembers]
    private Name(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public string Initials => $"{FirstName[0].ToString().ToUpper()}{LastName[0].ToString().ToUpper()}";

    /// <summary>
    /// Create a new Name object
    /// </summary>
    /// <param name="firstName"></param>
    /// <param name="lastName"></param>
    /// <returns></returns>
    /// <exception cref="InvalidCastException">Throws if firstName or lastName length is not 
    /// between 2 and 100 characters</exception>
    public static Name Create(string firstName, string lastName)
    {
        
        if (string.IsNullOrWhiteSpace(firstName) || firstName.Length < 2 || firstName.Length > 100)
            throw new InvalidNameException("First name must be between 2 and 100 characters");

        return string.IsNullOrWhiteSpace(lastName) || lastName.Length < 2 || lastName.Length > 100
            ? throw new InvalidNameException("Last name must be between 2 and 100 characters")
            : new Name(firstName, lastName);
    }

}
