using Entity.DTOs.Catalog.Genre.Create;
using FluentValidation;

namespace Entity.Validations.Modules.Catalog.Genre
{
    public class GenreCreateValidatorDto : AbstractValidator<GenreCreateDto>
    {
        public GenreCreateValidatorDto()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.")
                .MinimumLength(3).WithMessage("El campo {PropertyName} debe tener al menos {MinLength} caracteres.")
                .MaximumLength(100).WithMessage("El campo {PropertyName} no debe exceder los {MaxLength} caracteres.");

        }
    }
}
