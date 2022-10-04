namespace DotNetApis.Shared.Exceptions;

/// <summary>
/// No object was found for a received request.
/// </summary>
public class NotFoundException : Exception
{
    /// <inheritdoc />
    public NotFoundException(string message) : base(message) { }
}