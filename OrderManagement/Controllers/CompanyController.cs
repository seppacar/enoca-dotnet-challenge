using Microsoft.AspNetCore.Mvc;
using OrderManagement.BLL.DTO;
using OrderManagement.BLL.Service;

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _service;

        public CompanyController()
        {
            _service = new CompanyService();
        }


        [HttpGet(Name = "Get all companies")]
        public async Task<IActionResult> Get()
        {
            var response = _service.GetAll();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var company = _service.GetById(id);
            if (company == null)
            {
                return NotFound();

            }
            return Ok(company);
        }

        [HttpPost(Name = "Add a company")]
        public async Task<IActionResult> Post([FromBody] CompanyPostDTO company)
        {
            _service.AddCompany(company);
            return Created("Created entity", company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CompanyPostDTO company)
        {
            var result = _service.UpdateCompany(id, company);
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
            _service.RemoveCompany(id);
            return NoContent();
        }
    }

}
