using Entity.DTOs.Talent.Actor.Update;
using Entity.Validations.Generic;
using FluentValidation;

namespace Entity.Validations.Modules.Talent.Actor
{
    public class ActorUpdateValidatorDto : AbstractValidator<ActorUpdateDto>
    {
        public ActorUpdateValidatorDto()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Id).IdRules();
            
        }
    }
}
