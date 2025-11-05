using Entity.DTOs.Reviews.Create;
using Entity.Validations.Generic;
using FluentValidation;

namespace Entity.Validations.Modules.Reviews
{
    public class ReviewCreateValidatorDto : AbstractValidator<ReviewCreateDto>
    {
        public ReviewCreateValidatorDto()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.UserId).IdRules();
            RuleFor(x => x.MovieId).IdRules();
            RuleFor(x => x.Rating)
                .NotEmpty().WithMessage("El Rating es obligatorio")
                .InclusiveBetween(1, 5).WithMessage("El Rating debe estar entre 1 y 5");
        }
    }
}
