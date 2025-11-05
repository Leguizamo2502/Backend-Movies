using Business.Strategy.StrategyDeletes.Interfaces;
using Data.Interfaces.DataGeneric;
using Entity.Domain.Enums;
using Entity.Domain.Models.Base;

namespace Business.Strategy.StrategyDeletes.Implements
{
    public class DeleteLogical<T> : IStrategyDeletes<T> where T : BaseModel
    {
        public DeleteType Type => DeleteType.Logical;
        public async Task<bool> DeleteAsync(int id, IDataGeneric<T> repository)
        {
            // Aseguramos que el repositorio implemente IDataExtend<T>
            return await repository.DeleteLogicAsync(id);
        }
    }
}
