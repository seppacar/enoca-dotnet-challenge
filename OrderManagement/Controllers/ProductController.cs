using Microsoft.AspNetCore.Mvc;
using OrderManagement.BLL.DTO;
using OrderManagement.BLL.Service;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController()
        {
            _service = new ProductService();
        }


        [HttpGet(Name = "Get all products")]
        public async Task<IActionResult> Get()
        {
            var response = _service.GetAll();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = _service.GetById(id);
            if (product == null)
            {
                return NotFound();

            }
            return Ok(product);
        }

        [HttpPost(Name = "Create a new product")]
        public async Task<IActionResult> Post([FromBody] ProductPostDTO product)
        {
            _service.AddProduct(product);
            return Created("Created entity", product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductPostDTO product)
        {
            var result = _service.UpdateProduct(id, product);
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Post(int id)
        {
            _service.RemoveProduct(id);
            return NoContent();
        }
    }
}
