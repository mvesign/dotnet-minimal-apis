using FluentValidation.Results;

namespace DotNetApis.Shared.Exceptions;

/// <summary>
/// Received model contains invalid data.
/// </summary>
public class InvalidModelException : Exception
{
    /// <inheritdoc />
    public InvalidModelException(string message) : base(message) { }

    /// <inheritdoc />
    public InvalidModelException(ValidationResult validationResult)
    {
        Messages = validationResult
            .Errors
            .Select(_ => $"{_.PropertyName}: {_.ErrorMessage}")
            .ToArray();
    }

    /// <summary>
    /// Set of messages that describes the exception.
    /// </summary>
    public string[]? Messages { get; set; }
}