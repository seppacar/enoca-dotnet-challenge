using Microsoft.AspNetCore.Mvc;
using OrderManagement.BLL.DTO;
using OrderManagement.BLL.Service;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _service;

        public OrderController()
        {
            _service = new OrderService();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] OrderPostDTO order)
        {
            var result = _service.CreateOrder(order);
            return Content(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = _service.GetById(id);
            if (order == null)
            {
                return NotFound();

            }
            return Ok(order);
        }

        [HttpGet(Name = "Get all orders")]
        public async Task<IActionResult> Get()
        {
            var response = _service.GetAll();

            return Ok(response);
        }
    }
}
