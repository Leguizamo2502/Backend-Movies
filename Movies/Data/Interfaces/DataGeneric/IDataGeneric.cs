using Entity.Domain.Models.Base;

namespace Data.Interfaces.DataGeneric
{
    public interface IDataGeneric<T> where T : BaseModel
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetDeletes();
        Task<T?> GetByIdAsync(int id);
        Task<T> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteLogicAsync(int id);
        Task<bool> RestoreAsync(int id);
    }
}
