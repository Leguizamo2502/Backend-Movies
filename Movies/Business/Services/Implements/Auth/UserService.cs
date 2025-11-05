using Business.Interfaces.Implements.Auth;
using Business.Services.BaseService;
using Data.Interfaces.DataGeneric;
using Data.Interfaces.Implements.Auth;
using Entity.Domain.Models.Implements.Auth;
using Entity.DTOs.Auth.User.Create;
using Entity.DTOs.Auth.User.Select;
using Entity.DTOs.Auth.User.Update;
using MapsterMapper;
using Utilities.Business;
using Utilities.Custom;

namespace Business.Services.Implements.Auth.Users
{
    public class UserService : BaseBusiness<User, UserSelectDto, UserCreateDto, UserUpdateDto>, IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IMapper mapper, IDataGeneric<User> data, IUserRepository userRepository) : base(mapper, data)
        {
            _userRepository = userRepository;
        }

        public override async Task<UserCreateDto> CreateAsync(UserCreateDto dto)
        {
            try
            {
                BusinessValidationHelper.ThrowIfNull(dto, "El DTO no puede ser nulo.");

                if (await _userRepository.ExistsByEmailAsync(dto.Email))
                    throw new ValidationException("Correo ya registrado");

                var validPassword = BusinessValidationHelper.IsValidPassword(dto.Password);
                if (!validPassword)
                    throw new BusinessException("La contraseña debe tener al menos 6 caracteres y una mayúscula.");

                dto.Password = EncriptePassword.EncripteSHA256(dto.Password);

                var entity = _mapper.Map<User>(dto);
                InitializeLogical.InitializeLogicalState(entity);

                var created = await _userRepository.CreateAsync(entity);
                return _mapper.Map<UserCreateDto>(created);
            }
            catch (ValidationException)  
            {
                throw; 
            }
            catch (BusinessException)     
            {
                throw; 
            }
            catch (Exception ex)     
            {
                throw new BusinessException("Error al crear el registro.", ex);
            }
        }


        public override async Task<bool> UpdateAsync(UserUpdateDto dto)
        {
            try
            {
                BusinessValidationHelper.ThrowIfNull(dto, "El DTO no puede ser nulo.");

                if (await _userRepository.ExistsByEmailAsync(dto.Email))
                    throw new ValidationException("Correo ya registrado");

                var validPassword = BusinessValidationHelper.IsValidPassword(dto.Password);
                if (!validPassword)
                    throw new BusinessException("La contraseña debe tener al menos 6 caracteres y una mayúscula.");

                dto.Password = EncriptePassword.EncripteSHA256(dto.Password);

                var entity = _mapper.Map<User>(dto);
                InitializeLogical.InitializeLogicalState(entity);

                return await _userRepository.UpdateAsync(entity);
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (BusinessException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error al actualizar el registro.", ex);
            }
        }

    }
}
