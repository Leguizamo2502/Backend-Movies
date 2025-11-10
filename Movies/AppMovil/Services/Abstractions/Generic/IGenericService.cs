namespace AppMovil.Services.Abstractions.Generic
{
    public interface IGenericService<TSelect, TCreate, TUpdate>
    {
        Task<IEnumerable<TSelect>> GetAllAsync();
        Task<TSelect?> GetAsync(int id);
        Task<int> CreateAsync(TCreate dto);
        Task UpdateAsync(int id, TUpdate dto);
        Task DeleteAsync(int id);
    }

}
