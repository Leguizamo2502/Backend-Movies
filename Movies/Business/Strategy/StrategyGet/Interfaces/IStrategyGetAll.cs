using Data.Interfaces.DataGeneric;
using Entity.Domain.Enums;
using Entity.Domain.Models.Base;

namespace Business.Strategy.StrategyGet.Interfaces
{
    public interface IStrategyGetAll<T> where T : BaseModel
    {
        GetAllType Type { get; }
        public Task<IEnumerable<T>> GetAll(IDataGeneric<T> repository);
    }
}
