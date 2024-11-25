

using Evolve.Domain.Users.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Evolve.Domain.Users;
public class UserDetails
{
    [SetsRequiredMembers]
    private UserDetails(string email, Name name)
    {
        Email = email;
        Name = name;
    }
    
    // EF Core will need this
    private UserDetails() {}
    public required string Email { get; set; }
    public required Name Name { get; set; }

    /// <summary>
    /// Create a new UserDetails object
    /// </summary>
    /// <param name="email"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    /// <exception cref="InvalidEmailFormatException"></exception>
    public static UserDetails Create(string email, Name name)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new InvalidEmailFormatException("Email cannot be null or empty");
        return !new EmailAddressAttribute().IsValid(email)
            ? throw new InvalidEmailFormatException($"\"{email}\" is not a valid email format")
            : new UserDetails(email, name);
    }
}
