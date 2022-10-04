namespace DotNetApis.Shared.Models;

/// <summary>
/// Book details.
/// </summary>
public class Book
{
    /// <summary>
    /// ISBN.
    /// </summary>
    public string? Isbn { get; set; }

    /// <summary>
    /// Title.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Author.
    /// </summary>
    public string? Author { get; set; }
}