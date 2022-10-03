using DotNetApis.Shared.Models;
using DotNetApis.Shared.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNetApis.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly BookService _bookService;

    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [Produces(typeof(List<Book>))]
    [ActionName("GetBooks")]
    [Tags("Books")]
    public IActionResult GetBooks() =>
         Ok(_bookService.GetBooks());

    [HttpPost]
    [Produces(typeof(Book))]
    [ActionName("AddBook")]
    [Tags("Books")]
    public IActionResult AddBook([FromBody] Book book) =>
        Created("/books", _bookService.AddBook(book));
    
    [HttpGet("{isbn}")]
    [Produces(typeof(Book))]
    [ActionName("GetBook")]
    [Tags("Books")]
    public IActionResult GetBook(string isbn) =>
        Ok(_bookService.GetBook(isbn));

    [HttpPut("{isbn}")]
    [Produces(typeof(Book))]
    [ActionName("UpdateBook")]
    [Tags("Books")]
    public IActionResult UpdateBook(string isbn, [FromBody] Book book) =>
        Created($"/books/{isbn}", _bookService.UpdateBook(isbn, book));

    [HttpDelete("{isbn}")]
    [ActionName("DeleteBook")]
    [Tags("Books")]
    public IActionResult DeleteBook(string isbn)
    {
        _bookService.DeleteBook(isbn);
        return NoContent();
    }
}