using FluentValidation;
using BookStore.Models;

namespace BookStore.Validations
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Заглавието е задължително.");
            RuleFor(x => x.Year).GreaterThan(0).WithMessage("Годината трябва да е положителна.");
        }
    }
}