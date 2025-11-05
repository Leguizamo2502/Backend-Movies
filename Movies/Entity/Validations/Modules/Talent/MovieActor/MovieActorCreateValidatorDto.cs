using Entity.DTOs.Talent.MovieActor.Create;
using Entity.Validations.Generic;
using FluentValidation;

namespace Entity.Validations.Modules.Talent.MovieActor
{
    public class MovieActorCreateValidatorDto : AbstractValidator<MovieActorCreateDto>
    {
        public MovieActorCreateValidatorDto()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.ActorId).IdRules();
            RuleFor(x => x.MovieId).IdRules();

        }
    }
}
