using Entity.DTOs.Catalog.MovieGenre.Update;
using Entity.Validations.Generic;
using FluentValidation;

namespace Entity.Validations.Modules.Catalog.MovieGenre
{
    public class MovieGenreUpdateValidatorDto : AbstractValidator<MovieGenreUpdateDto>
    {
        public MovieGenreUpdateValidatorDto()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Id).IdRules();
            RuleFor(x => x.MovieId).IdRules();
            RuleFor(x => x.GenreId).IdRules();
        }
    }
}
