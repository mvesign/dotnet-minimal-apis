using DotNetApis.Shared.Models;

namespace DotNetApis.Shared.Abstractions.Services;

/// <summary>
/// Perform actions on the book collection.
/// </summary>
public interface IBookService
{
    /// <summary>
    /// Get an overview of all books of type <see cref="Book"/>.
    /// </summary>
    /// <returns>Set of books of type <see cref="Book"/>.</returns>
    IEnumerable<Book> GetBooks();

    /// <summary>
    /// Add a new book to the collection.
    /// </summary>
    /// <param name="book">Book of type <see cref="Book"/>.</param>
    /// <returns>Book of type <see cref="Book"/>.</returns>
    Book AddBook(Book? book);

    /// <summary>
    /// Get book linked to a given ISBN.
    /// </summary>
    /// <param name="isbn">ISBN.</param>
    /// <returns>Book of type <see cref="Book"/>.</returns>
    Book GetBook(string isbn);

    /// <summary>
    /// Update an existing book.
    /// </summary>
    /// <param name="isbn">ISBN.</param>
    /// <param name="book">Book of type <see cref="Book"/>.</param>
    /// <returns>Book of type <see cref="Book"/>.</returns>
    Book UpdateBook(string isbn, Book? book);

    /// <summary>
    /// Delete a book from the collection.
    /// </summary>
    /// <param name="isbn">ISBN.</param>
    /// <remarks>No error is thrown when a book is already deleted.</remarks>
    void DeleteBook(string isbn);
}