using Entity.DTOs.Watchlists.Update;
using Entity.Validations.Generic;
using FluentValidation;

namespace Entity.Validations.Modules.Watchlists
{
    public class WatchlistUpdateValidatorDto : AbstractValidator<WatchlistUpdateDto>
    {
        public WatchlistUpdateValidatorDto()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Id).IdRules();
            RuleFor(x => x.UserId).IdRules();
            RuleFor(x => x.MovieId).IdRules();

        }
    }
}
