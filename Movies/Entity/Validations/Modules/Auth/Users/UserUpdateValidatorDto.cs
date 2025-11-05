using Entity.DTOs.Auth.User.Update;
using FluentValidation;

namespace Entity.Validations.Modules.Auth.Users
{
    public class UserUpdateValidatorDto : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateValidatorDto()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.")
                .EmailAddress().WithMessage("El campo {PropertyName} debe ser un correo electrónico válido.")
                .MaximumLength(256).WithMessage("El campo {PropertyName} no debe exceder los {MaxLength} caracteres.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.")
                .MinimumLength(5).WithMessage("El campo {PropertyName} debe tener al menos {MinLength} caracteres.")
                .MaximumLength(100).WithMessage("El campo {PropertyName} no debe exceder los {MaxLength} caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.");
        }
    }
}
