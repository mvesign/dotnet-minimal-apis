using DotNetApis.Shared.Abstractions.Services;
using DotNetApis.Shared.Exceptions;
using DotNetApis.Shared.Models;

namespace DotNetApis.Shared.Services;

/// <inheritdoc />
public class BookService : IBookService
{
    #region Pre-setup set of books

    private readonly List<Book> _books = new()
    {
        new Book
        {
            Isbn = "978-0132350884",
            Title = "Clean Code: A Handbook of Agile Software Craftsmanship",
            Author = "Robert C. Martin"
        },
        new Book
        {
            Isbn = "978-0262033848",
            Title = "Introduction to Algorithms",
            Author = "Thomas H. Cormen, Charles E. Leiserson, Ronald L. Rivest, Clifford Stein"
        },
        new Book
        {
            Isbn = "978-0137081073",
            Title = "Structure and Interpretation of Computer Programs (SICP)",
            Author = "Harold Abelson, Gerald Jay Sussman, Julie Sussman"
        },
        new Book
        {
            Isbn = "978-0137081073",
            Title = "The Clean Coder: A Code of Conduct for Professional Programmers",
            Author = "Robert C. Martin"
        },
        new Book
        {
            Isbn = "978-0735619678",
            Title = "Code Complete: A Practical Handbook of Software Construction",
            Author = "Steve McConnell"
        },
        new Book
        {
            Isbn = "978-0201633610",
            Title = "Design Patterns: Elements of Reusable Object-Oriented Software",
            Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides, Grady Booch (Foreword)"
        },
        new Book
        {
            Isbn = "978-0135957059",
            Title = "The Pragmatic Programmer",
            Author = "Andrew Hunt, David Thomas"
        },
        new Book
        {
            Isbn = "978-0596007126",
            Title = "Head First Design Patterns: A Brain-Friendly Guide",
            Author = "Eric Freeman, Bert Bates, Kathy Sierra, Elisabeth Robson"
        },
        new Book
        {
            Isbn = "978-0134757599",
            Title = "Refactoring: Improving the Design of Existing Code",
            Author = "Martin Fowler"
        },
        new Book
        {
            Isbn = "978-0321751041",
            Title = "The Art of Computer Programming, Volumes 1-4",
            Author = "Donald E. Knuth"
        }
    };

    #endregion

    /// <inheritdoc />
    public IEnumerable<Book> GetBooks() =>
        _books;

    /// <inheritdoc />
    public Book AddBook(Book? book)
    {
        if (book == null)
            throw new ArgumentNullException(nameof(book));

        _books.Add(book);
        return book;
    }

    /// <inheritdoc />
    public Book GetBook(string isbn)
    {
        var book = _books.FirstOrDefault(_ => string.Equals(_.Isbn, isbn, StringComparison.OrdinalIgnoreCase));
        if (book == null)
            throw new NotFoundException($"No book found for ISBN '{isbn}'");

        return book;
    }

    /// <inheritdoc />
    public Book UpdateBook(string isbn, Book? book)
    {
        if (book == null)
            throw new ArgumentNullException(nameof(book));

        if (!string.IsNullOrWhiteSpace(book.Isbn) && !string.Equals(book.Isbn, isbn, StringComparison.OrdinalIgnoreCase))
            throw new InvalidModelException($"ISBN '{isbn}' is different than '{book.Isbn}'");
        
        var match = _books.FirstOrDefault(_ => string.Equals(_.Isbn, isbn, StringComparison.OrdinalIgnoreCase));
        if (match == null)
            throw new NotFoundException($"No book found for ISBN '{isbn}'");

        book.Isbn = isbn;

        _books.Remove(match);
        _books.Add(book);
        return book;
    }

    /// <inheritdoc />
    public void DeleteBook(string isbn)
    {
        var match = _books.FirstOrDefault(_ => string.Equals(_.Isbn, isbn, StringComparison.OrdinalIgnoreCase));
        if (match != null)
            _books.Remove(match);
    }
}