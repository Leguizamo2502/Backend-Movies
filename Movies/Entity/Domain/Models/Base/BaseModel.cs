namespace Entity.Domain.Models.Base
{
    public class BaseModel
    {
        public int Id { get; set; }
        public bool Active { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
