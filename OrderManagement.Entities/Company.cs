using OrderManagement.Entities.Abstract;

namespace OrderManagement.Entities
{
    public class Company : BaseEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public bool CompanyStatus { get; set; }
        public TimeSpan OrderStartTime { get; set; }
        public TimeSpan OrderFinishTime { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
