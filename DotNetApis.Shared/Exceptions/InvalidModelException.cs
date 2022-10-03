namespace DotNetApis.Shared.Exceptions;

public class InvalidModelException : Exception
{
    public InvalidModelException(string message) : base(message) { }
}