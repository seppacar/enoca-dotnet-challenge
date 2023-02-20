using Microsoft.EntityFrameworkCore;
using OrderManagement.Entities;

namespace OrderManagement.DAL.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Replace MSSQL Server String
            optionsBuilder.UseSqlServer("Server=THINKPAD\\SQLEXPRESS;Database=enocaOrderManagement;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Navigation builder
            modelBuilder.Entity<Product>().Navigation(p => p.Company).AutoInclude();
            modelBuilder.Entity<Order>().Navigation(o => o.Company).AutoInclude();
            modelBuilder.Entity<Order>().Navigation(o => o.Product).AutoInclude();

            //Seed data
            modelBuilder.Entity<Company>().HasData(
                new Company()
                {
                    Id = 1,
                    CompanyName = "enoca",
                    CompanyStatus = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.MinValue,
                    OrderStartTime = new TimeSpan(09, 0, 0),
                    OrderFinishTime = new TimeSpan(16, 0, 0)
                }, new Company()
                {
                    Id = 2,
                    CompanyName = "Kardemir",
                    CompanyStatus = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.MinValue,
                    OrderStartTime = new TimeSpan(09, 0, 0),
                    OrderFinishTime = new TimeSpan(22, 0, 0)
                }, new Company()
                {
                    Id = 3,
                    CompanyName = "RINO",
                    CompanyStatus = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.MinValue,
                    OrderStartTime = new TimeSpan(09, 0, 0),
                    OrderFinishTime = new TimeSpan(13, 30, 0)
                });

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    CompanyId = 1,
                    ProductName = "Software-1",
                    Price = 12345,
                    Stock = 15,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.MinValue,
                }, new Product()
                {
                    Id = 2,
                    CompanyId = 2,
                    ProductName = "S235JR",
                    Price = 150000,
                    Stock = 22,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.MinValue,
                }, new Product()
                {
                    Id = 3,
                    CompanyId = 2,
                    ProductName = "B420",
                    Price = 12345,
                    Stock = 30,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.MinValue,
                }, new Product()
                {
                    Id = 4,
                    CompanyId = 3,
                    ProductName = "Office 365",
                    Price = 125,
                    Stock = 14,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.MinValue,
                }, new Product()
                {
                    Id = 5,
                    CompanyId = 3,
                    ProductName = "Microsoft Surface Laptop",
                    Price = 1250,
                    Stock = 12,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.MinValue,
                }
                );
        }



        public DbSet<Company> Companies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
