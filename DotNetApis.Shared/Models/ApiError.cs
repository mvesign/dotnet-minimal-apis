using JetBrains.Annotations;

namespace DotNetApis.Shared.Models;

/// <summary>
/// Error details.
/// </summary>
/// <param name="Messages">Set of messages why the error has occurred.</param>
[PublicAPI]
public record ApiError(params string[] Messages);