using Entity.Domain.Enums;

namespace Business.Interfaces.BaseService
{
    public interface IBaseBusiness<TSelect,TCreate,TUpdate>
    {
        Task<IEnumerable<TSelect>> GetAllAsync();
        Task<IEnumerable<TSelect>> GetAllAsync(GetAllType g);
        Task<TSelect?> GetByIdAsync(int id);
        Task<TCreate> CreateAsync(TCreate dto);
        Task<bool> UpdateAsync(TUpdate dto);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(int id, DeleteType deleteType);
        Task<bool> RestoreLogical(int id);
    }
}
