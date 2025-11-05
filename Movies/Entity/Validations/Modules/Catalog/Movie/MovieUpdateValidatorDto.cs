using Entity.DTOs.Catalog.Movie.Update;
using Entity.Validations.Generic;
using FluentValidation;

namespace Entity.Validations.Modules.Catalog.Movie
{
    public class MovieUpdateValidatorDto : AbstractValidator<MovieUpdateDto>
    {
        public MovieUpdateValidatorDto()
        {
            RuleFor(x => x.Id).IdRules();
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("EL titulo es obligatorio.");
        }
    }
}
