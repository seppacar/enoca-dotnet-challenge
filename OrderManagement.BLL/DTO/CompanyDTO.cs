namespace OrderManagement.BLL.DTO
{
    public class CompanyDTO
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public bool CompanyStatus { get; set; }
        public TimeSpan OrderStartTime { get; set; }
        public TimeSpan OrderFinishTime { get; set; }
    }
}
