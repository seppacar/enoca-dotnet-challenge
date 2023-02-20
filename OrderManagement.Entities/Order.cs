using OrderManagement.Entities.Abstract;

namespace OrderManagement.Entities
{
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        //Delete before migrating again not needed since we have CreatedAt field
        public DateTime OrderDate { get; set; }
        public virtual Product Product { get; set; }
        public int? ProductId { get; set; }
        public virtual Company Company { get; set; }
        public int? CompanyId { get; set; }
    }
}
