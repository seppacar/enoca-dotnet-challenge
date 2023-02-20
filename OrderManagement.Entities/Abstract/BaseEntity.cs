namespace OrderManagement.Entities.Abstract
{
    public abstract class BaseEntity : IBaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
