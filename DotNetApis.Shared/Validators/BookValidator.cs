using DotNetApis.Shared.Models;
using FluentValidation;

namespace DotNetApis.Shared.Validators;

/// <summary>
/// Validator for model of type <see cref="Book"/>.
/// </summary>
public class BookValidator : AbstractValidator<Book>
{
    /// <summary>
    /// Setup of a book validator.
    /// </summary>
    public BookValidator()
    {
        RuleFor(_ => _.Author)
            .NotEmpty()
            .WithMessage("Author is mandatory");

        RuleFor(_ => _.Title)
            .NotEmpty()
            .WithMessage("Title is mandatory");
    }
}