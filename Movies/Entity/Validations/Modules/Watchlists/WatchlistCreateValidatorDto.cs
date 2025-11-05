using Entity.DTOs.Watchlists.Create;
using Entity.Validations.Generic;
using FluentValidation;

namespace Entity.Validations.Modules.Watchlists
{
    public class WatchlistCreateValidatorDto : AbstractValidator<WatchlistCreateDto>
    {
        public WatchlistCreateValidatorDto()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.UserId).IdRules();
            RuleFor(x => x.MovieId).IdRules();
        }
    }
}
