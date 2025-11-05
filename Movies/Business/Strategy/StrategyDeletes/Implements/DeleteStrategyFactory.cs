using Business.Strategy.StrategyDeletes.Interfaces;
using Data.Interfaces.DataGeneric;
using Entity.Domain.Enums;
using Entity.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Strategy.StrategyDeletes.Implements
{
    public static class DeleteStrategyFactory
    {
        public static IStrategyDeletes<T> GetStrategy<T>(IDataGeneric<T> repository, DeleteType deleteType) where T : BaseModel
        {
            return deleteType switch
            {
                DeleteType.Logical when repository is IDataGeneric<T> => new DeleteLogical<T>(),
                DeleteType.Persistent => new DeletePersistent<T>(),
                _ => throw new InvalidOperationException("Tipo de borrado no soportado para este repositorio.")
            };
        }
    }
}
