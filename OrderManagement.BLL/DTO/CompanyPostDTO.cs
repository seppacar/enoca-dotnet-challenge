namespace OrderManagement.BLL.DTO
{
    public class CompanyPostDTO
    {
        public string CompanyName { get; set; }
        public bool CompanyStatus { get; set; }
        public int OrderStartHour { get; set; }
        public int OrderStartMinute { get; set; }
        public int OrderFinishHour { get; set; }
        public int OrderFinishMinute { get; set; }
    }
}
