using Business.Strategy.StrategyGet.Interfaces;
using Data.Interfaces.DataGeneric;
using Entity.Domain.Enums;
using Entity.Domain.Models.Base;

namespace Business.Strategy.StrategyGet.Implements
{
    public static class GetStrategyFactory
    {
        public static IStrategyGetAll<T> GetStrategyGet<T>(IDataGeneric<T> repository, GetAllType getAllType) where T : BaseModel
        {
            return getAllType switch
            {
                GetAllType.GetAll => new StrategyGetAll<T>(),
                GetAllType.GetAllDeletes when repository is IDataGeneric<T> => new StrategyGetDeletes<T>(),
                _ => throw new InvalidOperationException("Tipo de get no soprtado en este repositorio")
            };
        }
    }
}
