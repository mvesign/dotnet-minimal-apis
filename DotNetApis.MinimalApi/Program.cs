using DotNetApis.Shared.Abstractions.Services;
using DotNetApis.Shared.Filters;
using DotNetApis.Shared.Models;
using DotNetApis.Shared.Services;
using DotNetApis.Shared.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Self-owned services
builder.Services.AddSingleton<IBookService, BookService>();

// Validators
builder.Services.AddScoped<IValidator<Book>, BookValidator>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Error handling
builder.Services.AddMvc(_ => _.Filters.Add(typeof(ErrorsExceptionFilter)));

var app = builder.Build();

// Endpoints
app.MapGet("/books", (IBookService bookService) => Results.Ok(bookService.GetBooks()))
    .Produces<List<Book>>()
    .WithName("GetBooks")
    .WithTags("Books");

app.MapPost("/books", async ([FromBody] Book book, IBookService bookService, IValidator<Book> validator) =>
    {
        var validationResult = await validator.ValidateAsync(book);
        return validationResult.IsValid
            ? Results.Created("/books", bookService.AddBook(book))
            : Results.ValidationProblem(validationResult.ToDictionary());
    })
    .Accepts<Book>("application/json")
    .Produces<Book>(StatusCodes.Status201Created)
    .WithName("AddBook")
    .WithTags("Books");

app.MapGet("/books/{isbn}", (string isbn, IBookService bookService) => Results.Ok(bookService.GetBook(isbn)))
    .Produces<Book>()
    .WithName("GetBook")
    .WithTags("Books");

app.MapPut("/books/{isbn}", async (string isbn, [FromBody] Book book, IBookService bookService, IValidator<Book> validator) =>
    {
        var validationResult = await validator.ValidateAsync(book);
        return validationResult.IsValid
            ? Results.Created($"/books/{isbn}", bookService.UpdateBook(isbn, book))
            : Results.ValidationProblem(validationResult.ToDictionary());
    })
    .Accepts<Book>("application/json")
    .Produces<Book>(StatusCodes.Status201Created)
    .WithName("UpdateBook")
    .WithTags("Books");

app.MapDelete("/books/{isbn}", (string isbn, [FromServices] IBookService bookService) =>
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
