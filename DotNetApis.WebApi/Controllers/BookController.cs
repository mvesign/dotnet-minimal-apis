using DotNetApis.Shared.Models;
using DotNetApis.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApis.WebApi.Controllers;

/// <summary>
/// Endpoints to manage the books collection.
/// </summary>
[ApiController]
[Route("[controller]s")]
public class BookController : ControllerBase
{
    private readonly BookService _bookService;

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="bookService">Service of type <see cref="BookService"/>.</param>
    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }

    /// <summary>
    /// Get an overview of all books of type <see cref="Book"/>.
    /// </summary>
    /// <returns>Set of books of type <see cref="Book"/>.</returns>
    [HttpGet]
    [Produces(typeof(List<Book>))]
    [ActionName("GetBooks")]
    [Tags("Books")]
    public IActionResult GetBooks() =>
         Ok(_bookService.GetBooks());

    /// <summary>
    /// Add a new book to the collection.
    /// </summary>
    /// <param name="book">Book of type <see cref="Book"/>.</param>
    /// <returns>Book of type <see cref="Book"/>.</returns>
    [HttpPost]
    [Produces(typeof(Book))]
    [ActionName("AddBook")]
    [Tags("Books")]
    public IActionResult AddBook([FromBody] Book book) =>
        Created("/books", _bookService.AddBook(book));

    /// <summary>
    /// Get book linked to a given ISBN.
    /// </summary>
    /// <param name="isbn">ISBN.</param>
    /// <returns>Book of type <see cref="Book"/>.</returns>
    [HttpGet("{isbn}")]
    [Produces(typeof(Book))]
    [ActionName("GetBook")]
    [Tags("Books")]
    public IActionResult GetBook(string isbn) =>
        Ok(_bookService.GetBook(isbn));

    /// <summary>
    /// Update an existing book.
    /// </summary>
    /// <param name="isbn">ISBN.</param>
    /// <param name="book">Book of type <see cref="Book"/>.</param>
    /// <returns>Book of type <see cref="Book"/>.</returns>
    [HttpPut("{isbn}")]
    [Produces(typeof(Book))]
    [ActionName("UpdateBook")]
    [Tags("Books")]
    public IActionResult UpdateBook(string isbn, [FromBody] Book book) =>
        Created($"/books/{isbn}", _bookService.UpdateBook(isbn, book));

    /// <summary>
    /// Delete a book from the collection.
    /// </summary>
    /// <param name="isbn">ISBN.</param>
    /// <remarks>No error is thrown when a book is already deleted.</remarks>
    [HttpDelete("{isbn}")]
    [ActionName("DeleteBook")]
    [Tags("Books")]
    public IActionResult DeleteBook(string isbn)
    {
        _bookService.DeleteBook(isbn);
        return NoContent();
    }
}