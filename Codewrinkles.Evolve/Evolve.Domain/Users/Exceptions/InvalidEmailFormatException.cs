namespace Evolve.Domain.Users.Exceptions;
public class InvalidEmailFormatException : Exception
{
    public InvalidEmailFormatException()
    {       
    }

    public InvalidEmailFormatException(string message) 
        : base(message)
    {
    }

    public InvalidEmailFormatException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }
}
