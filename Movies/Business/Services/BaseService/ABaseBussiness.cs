using Business.Interfaces.BaseService;
using Entity.Domain.Enums;
using Entity.Domain.Models.Base;
using Entity.DTOs.Base;

namespace Business.Services.BaseService
{
    public abstract class ABaseBussiness<TEntity, TSelect, TCreate, TUpdate> : IBaseBusiness<TSelect, TCreate, TUpdate> 
        where TEntity : BaseModel where TUpdate : BaseDto
    {
        public abstract Task<TCreate> CreateAsync(TCreate dto);
        public abstract Task<bool> DeleteAsync(int id);
        public abstract Task<bool> DeleteAsync(int id, DeleteType deleteType);
        public abstract Task<IEnumerable<TSelect>> GetAllAsync();
        public abstract Task<IEnumerable<TSelect>> GetAllAsync(GetAllType g);
        public abstract Task<TSelect?> GetByIdAsync(int id);
        public abstract Task<bool> RestoreLogical(int id);
        public abstract Task<bool> UpdateAsync(TUpdate dto);
    }
}
