namespace DotNetApis.Shared.Exceptions;

/// <summary>
/// Received model contains invalid data.
/// </summary>
public class InvalidModelException : Exception
{
    /// <inheritdoc />
    public InvalidModelException(string message) : base(message) { }
}