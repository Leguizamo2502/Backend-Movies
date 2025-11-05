using Entity.Domain.Models.Base;

namespace Utilities.Business
{
    public static class InitializeLogical
    {
        public static void InitializeLogicalState(BaseModel entity)
        {
            entity.IsDeleted = false;
            entity.Active = true;

        }
    }
}
