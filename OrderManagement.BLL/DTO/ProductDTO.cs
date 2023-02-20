﻿namespace OrderManagement.BLL.DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public CompanyDTO Company { get; set; }
    }
}
