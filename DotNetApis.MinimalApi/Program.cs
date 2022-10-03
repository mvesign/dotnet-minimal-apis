using DotNetApis.Shared.Filters;
using DotNetApis.Shared.Models;
using DotNetApis.Shared.Services;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Self-owned services
builder.Services.AddSingleton<BookService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Error handling
builder.Services.AddMvc(_ => _.Filters.Add(typeof(ErrorsExceptionFilter)));

var app = builder.Build();

// Endpoints
app.MapGet("/books", ([FromServices] BookService bookService) => Results.Ok(bookService.GetBooks()))
    .Produces<List<Book>>()
    .WithName("GetBooks")
    .WithTags("Books");

app.MapPost("/books", ([FromBody] Book book, [FromServices] BookService bookService) => Results.Created("/books", bookService.AddBook(book)))
    .Accepts<Book>("application/json")
    .Produces<Book>(StatusCodes.Status201Created)
    .WithName("AddBook")
    .WithTags("Books");

app.MapGet("/books/{isbn}", (string isbn, [FromServices] BookService bookService) => Results.Ok(bookService.GetBook(isbn)))
    .Produces<Book>()
    .WithName("GetBook")
    .WithTags("Books");

app.MapPut("/books/{isbn}", (string isbn, [FromBody] Book book, [FromServices] BookService bookService) => Results.Created($"/books/{isbn}", bookService.UpdateBook(isbn, book)))
    .Accepts<Book>("application/json")
    .Produces<Book>(StatusCodes.Status201Created)
    .WithName("UpdateBook")
    .WithTags("Books");

app.MapDelete("/books/{isbn}", (string isbn, [FromServices] BookService bookService) =>
    {
        bookService.DeleteBook(isbn);
        return Results.NoContent();
    })
    .Produces(StatusCodes.Status204NoContent)
    .WithName("DeleteBook")
    .WithTags("Books");

// Swagger UI
app.UseSwagger();
app.UseSwaggerUI();

app.Run();
