using FluentValidation;
using SuperheroApi.Core.DTOs;

namespace SuperheroApi.Core.Models.Superhero
{
    public class SuperheroValidator : AbstractValidator<SuperheroDto>
    {
        public SuperheroValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(3, 50).WithMessage("Name must be between 3 and 50 characters.");

            RuleFor(x => x.Powers)
                .NotEmpty().WithMessage("Powers are required.");
        }
    }
}
