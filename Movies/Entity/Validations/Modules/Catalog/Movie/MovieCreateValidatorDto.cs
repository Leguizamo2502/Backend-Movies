using Entity.DTOs.Catalog.Movie.Create;
using FluentValidation;

namespace Entity.Validations.Modules.Catalog.Movie
{
    public class MovieCreateValidatorDto : AbstractValidator<MovieCreateDto>
    {
        public MovieCreateValidatorDto()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("EL titulo es obligatorio.");

        }
    }
}
