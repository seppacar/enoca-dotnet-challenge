using OrderManagement.BLL.DTO;
using OrderManagement.DAL.Repository;
using OrderManagement.Entities;

namespace OrderManagement.BLL.Service
{
    public class ProductService
    {
        private ProductRepository _repo;
        private CompanyService _companyService;

        public ProductService()
        {
            _repo = new ProductRepository();
            _companyService = new CompanyService();
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            var products = _repo.GetAll();

            var result = from product in products
                         select new ProductDTO()
                         {
                             ProductId = product.Id,
                             ProductName = product.ProductName,
                             Company = new CompanyDTO()
                             {
                                 CompanyId = product.Company.Id,
                                 CompanyName = product.Company.CompanyName,
                                 CompanyStatus = product.Company.CompanyStatus,
                                 OrderStartTime = product.Company.OrderStartTime,
                                 OrderFinishTime = product.Company.OrderFinishTime,
                             },
                             Price = product.Price,
                             Stock = product.Stock
                         };
            return result;
        }

        public ProductDTO GetById(int id)
        {
            var product = _repo.GetById(id);
            if (product == null)
                return null;

            var dto = new ProductDTO()
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Stock = product.Stock,
                Company = new CompanyDTO()
                {
                    CompanyId = product.Company.Id,
                    CompanyName = product.Company.CompanyName,
                    CompanyStatus = product.Company.CompanyStatus,
                    OrderStartTime = product.Company.OrderStartTime,
                    OrderFinishTime = product.Company.OrderFinishTime,
                }
            };
            return dto;
        }

        public void AddProduct(ProductPostDTO product)
        {
            var productToAdd = new Product()
            {
                ProductName = product.ProductName,
                Price = product.Price,
                CompanyId = product.CompanyId,
                Stock = product.Stock,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.MinValue
            };

            _repo.Add(productToAdd);
        }

        public bool UpdateProduct(int id, ProductPostDTO product)
        {
            var productToUpdate = _repo.GetById(id);
            if (productToUpdate == null)
            {
                return false;
            }
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.Price = product.Price;
            productToUpdate.Stock = product.Stock;
            productToUpdate.Company = _companyService.GetCompanyDomainById(product.CompanyId);
            productToUpdate.UpdatedAt = DateTime.Now;

            _repo.Update(productToUpdate);
            return true;
        }

        public void RemoveProduct(int id)
        {
            _repo.Delete(id);
        }
    }
}
