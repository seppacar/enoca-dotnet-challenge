using OrderManagement.Entities.Abstract;

namespace OrderManagement.Entities
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public virtual Company Company { get; set; }
        public int CompanyId { get; set; }
    }
}
