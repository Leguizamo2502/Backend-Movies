using Business.Strategy.StrategyDeletes.Implements;
using Business.Strategy.StrategyGet.Implements;
using Data.Interfaces.DataGeneric;
using Entity.Domain.Enums;
using Entity.Domain.Models.Base;
using Entity.DTOs.Base;
using MapsterMapper;
using Utilities.Business;

namespace Business.Services.BaseService
{
    public class BaseBusiness<TEntity, TSelect, TCreate, TUpdate> : ABaseBussiness<TEntity, TSelect, TCreate, TUpdate>
        where TEntity : BaseModel where TUpdate : BaseDto
    {
        protected readonly IMapper _mapper;
        protected readonly IDataGeneric<TEntity> _data;
        public BaseBusiness(IMapper mapper, IDataGeneric<TEntity> data)
        {
            _mapper = mapper;
            _data = data;
        }
        public override async Task<IEnumerable<TSelect>> GetAllAsync()
        {
            try
            {
                var entities = await _data.GetAllAsync();
                return _mapper.Map<IEnumerable<TSelect>>(entities);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error al obtener todos los registros.", ex);
            }
        }

        public override async Task<IEnumerable<TSelect>> GetAllAsync(GetAllType getAllType)
        {
            try
            {
                var strategy = GetStrategyFactory.GetStrategyGet<TEntity>(_data, getAllType);
                var entities = await strategy.GetAll(_data);
                return _mapper.Map<IEnumerable<TSelect>>(entities);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error al obtener registros con estrategia {getAllType}.", ex);
            }
        }

        public override async Task<TSelect?> GetByIdAsync(int id)
        {
            try
            {
                BusinessValidationHelper.ThrowIfZeroOrLess(id, "El ID debe ser mayor que cero.");

                var entity = await _data.GetByIdAsync(id);
                return entity == null ? default : _mapper.Map<TSelect>(entity);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error al obtener el registro con ID {id}.", ex);
            }
        }
        public override async Task<TCreate> CreateAsync(TCreate dto)
        {
            try
            {
                BusinessValidationHelper.ThrowIfNull(dto, "El DTO no puede ser nulo.");

                var entity = _mapper.Map<TEntity>(dto);
                InitializeLogical.InitializeLogicalState(entity); // Inicializa estado lógico (is_deleted = false)

                var created = await _data.CreateAsync(entity);
                return _mapper.Map<TCreate>(created);
            }
            catch (Exception ex)
            {
                throw new BusinessException("Error al crear el registro.", ex);
            }
        }
        public override async Task<bool> UpdateAsync(TUpdate dto)
        {
            try
            {
                BusinessValidationHelper.ThrowIfNull(dto, "El DTO no puede ser nulo.");

                var entity = _mapper.Map<TEntity>(dto);
                InitializeLogical.InitializeLogicalState(entity); // Inicializa estado lógico (is_deleted = false)

                return await _data.UpdateAsync(entity);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error al actualizar el registro: {ex.Message}", ex);
            }
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            try
            {
                BusinessValidationHelper.ThrowIfZeroOrLess(id, "El ID debe ser mayor que cero.");
                return await _data.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error al eliminar el registro con ID {id}.", ex);
            }
        }


        public override async Task<bool> DeleteAsync(int id, DeleteType deleteType)
        {
            try
            {
                BusinessValidationHelper.ThrowIfZeroOrLess(id, "El ID debe ser mayor que cero.");

                var strategy = DeleteStrategyFactory.GetStrategy<TEntity>(_data, deleteType);
                return await strategy.DeleteAsync(id, _data);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error al eliminar registro (ID: {id}) con estrategia {deleteType}.", ex);
            }
        }


        public override async Task<bool> RestoreLogical(int id)
        {
            try
            {
                BusinessValidationHelper.ThrowIfZeroOrLess(id, "El ID debe ser mayor que cero.");

                return await _data.RestoreAsync(id);
            }
            catch (Exception ex)
            {
                throw new BusinessException($"Error al restaurar el registro con ID {id}.", ex);
            }
        }

    }
}
