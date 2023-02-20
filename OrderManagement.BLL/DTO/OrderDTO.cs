namespace OrderManagement.BLL.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
    }
}
