using OrderManagement.BLL.DTO;
using OrderManagement.DAL.Repository;
using OrderManagement.Entities;

namespace OrderManagement.BLL.Service
{
    public class OrderService
    {
        private readonly OrderRepository _repo;
        private readonly CompanyService _companyService;
        private readonly ProductService _productService;

        public OrderService()
        {
            _companyService = new CompanyService();
            _repo = new OrderRepository();
            _productService = new ProductService();
        }

        public string CreateOrder(OrderPostDTO order)
        {
            var now = new TimeSpan(order.OrderHour, order.OrderMinute, 0);
            var product = _productService.GetById(order.ProductId);
            if (product == null)
            {
                return "Please provide correct Product  ";
            }
            else if (!(now <= product.Company.OrderFinishTime && now >= product.Company.OrderStartTime))
            {
                return "Out of working hours!";
            }
            else
            {
                var orderToAdd = new Order()
                {
                    CompanyId = product.Company.CompanyId,
                    ProductId = order.ProductId,
                    CustomerName = order.CustomerName,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.MinValue,
                };

                _repo.Add(orderToAdd);

                //Decrement stock after successful order
                product.Stock = product.Stock - 1;
                return "Order created successfully";
            }

        }

        public OrderDTO GetById(int id)
        {
            var order = _repo.GetById(id);
            if (order == null)
            {
                return null;
            }
            return new OrderDTO()
            {
                OrderId = order.Id,
                CustomerName = order.CustomerName,
                ProductName = order.Product.ProductName,
                CompanyName = order.Company.CompanyName,
                OrderDate = order.OrderDate,
            };
        }

        public IEnumerable<OrderDTO> GetAll()
        {
            var orders = _repo.GetAll();

            var result = from order in orders
                         select new OrderDTO()
                         {
                             OrderId = order.Id,
                             CustomerName = order.CustomerName,
                             CompanyName = order.Company.CompanyName,
                             ProductName = order.Product.ProductName,
                             OrderDate = order.OrderDate,
                         };
            return result;
        }
    }
}
