using Entity.DTOs.Talent.Actor.Create;
using FluentValidation;

namespace Entity.Validations.Modules.Talent.Actor
{
    public class ActorCreateValidatorDto : AbstractValidator<ActorCreateDto>
    {
        public ActorCreateValidatorDto()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.")
                .MinimumLength(5).WithMessage("El campo {PropertyName} debe tener al menos {MinLength} caracteres.")
                .MaximumLength(100).WithMessage("El campo {PropertyName} no debe exceder los {MaxLength} caracteres.");

        }
    }
}
