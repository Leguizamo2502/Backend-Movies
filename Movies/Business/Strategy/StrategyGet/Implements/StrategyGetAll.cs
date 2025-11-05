using Business.Strategy.StrategyGet.Interfaces;
using Data.Interfaces.DataGeneric;
using Entity.Domain.Enums;
using Entity.Domain.Models.Base;

namespace Business.Strategy.StrategyGet.Implements
{
    public class StrategyGetAll<T> : IStrategyGetAll<T> where T : BaseModel
    {
        public GetAllType Type => GetAllType.GetAll;

        public async Task<IEnumerable<T>> GetAll(IDataGeneric<T> repository)
        {
            return await repository.GetAllAsync();
        }
    }
}
