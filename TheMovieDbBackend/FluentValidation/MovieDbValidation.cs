using FluentValidation;
using TheMovieDbBackend.Core.Entity;

namespace TheMovieDbBackend.API.FluentValidation
{
    public class MovieDbValidation : AbstractValidator<MovieDb>
    {
        public MovieDbValidation()
        {
            RuleFor(r=>r.Note).NotEmpty().MaximumLength(25).WithMessage("Note must be length 25");
            RuleFor(r => r.Rate).NotEmpty().GreaterThanOrEqualTo(1).LessThanOrEqualTo(10).WithMessage("Rate must be between 1-10");


        }
    }
}
