using Entity.DTOs.Auth;
using FluentValidation;

namespace Entity.Validations.Modules.Auth
{
    public class LoginUserValidatorDto : AbstractValidator<LoginUserDto>
    {
        public LoginUserValidatorDto()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.")
                .EmailAddress().WithMessage("El campo {PropertyName} debe ser un correo electrónico válido.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("El campo {PropertyName} es obligatorio.");
        }
    }
}
