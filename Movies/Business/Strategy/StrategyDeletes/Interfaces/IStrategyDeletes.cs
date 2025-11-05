using Data.Interfaces.DataGeneric;
using Entity.Domain.Enums;
using Entity.Domain.Models.Base;

namespace Business.Strategy.StrategyDeletes.Interfaces
{
    public interface IStrategyDeletes<T> where T : BaseModel
    {
        DeleteType Type { get; }
        Task<bool> DeleteAsync(int id, IDataGeneric<T> repository);
    }
}
