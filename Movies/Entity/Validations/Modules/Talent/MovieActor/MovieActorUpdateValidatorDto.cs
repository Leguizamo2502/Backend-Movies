using Entity.DTOs.Talent.MovieActor.Update;
using Entity.Validations.Generic;
using FluentValidation;

namespace Entity.Validations.Modules.Talent.MovieActor
{
    public class MovieActorUpdateValidatorDto : AbstractValidator<MovieActorUpdatetDto>
    {
        public MovieActorUpdateValidatorDto()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Id).IdRules();
            RuleFor(x => x.ActorId).IdRules();
            RuleFor(x => x.MovieId).IdRules();

        }
    }
}
