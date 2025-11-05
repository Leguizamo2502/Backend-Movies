using Entity.DTOs.Catalog.Genre.Update;
using Entity.Validations.Generic;
using FluentValidation;

namespace Entity.Validations.Modules.Catalog.Genre
{
    public class GenreUpdateValidatorDto : AbstractValidator<GenreUpdateDto>
    {
        public GenreUpdateValidatorDto()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Id).IdRules();
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.")
                .MinimumLength(3).WithMessage("El campo {PropertyName} debe tener al menos {MinLength} caracteres.")
                .MaximumLength(100).WithMessage("El campo {PropertyName} no debe exceder los {MaxLength} caracteres.");
        }
    }
}
