using Business.Strategy.StrategyDeletes.Interfaces;
using Data.Interfaces.DataGeneric;
using Entity.Domain.Enums;
using Entity.Domain.Models.Base;

namespace Business.Strategy.StrategyDeletes.Implements
{
    public class DeletePersistent<T> : IStrategyDeletes<T> where T : BaseModel
    {
        public DeleteType Type => DeleteType.Persistent;
        public async Task<bool> DeleteAsync(int id, IDataGeneric<T> repository)
        {
            return await repository.DeleteAsync(id);
        }
    }
}
