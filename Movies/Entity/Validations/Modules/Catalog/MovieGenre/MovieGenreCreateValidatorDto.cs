using Entity.DTOs.Catalog.MovieGenre.Create;
using Entity.Validations.Generic;
using FluentValidation;

namespace Entity.Validations.Modules.Catalog.MovieGenre
{
    public class MovieGenreCreateValidatorDto : AbstractValidator<MovieGenreCreateDto>
    {
        public MovieGenreCreateValidatorDto()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.MovieId).IdRules();
            RuleFor(x => x.GenreId).IdRules();

        }
    }
}
