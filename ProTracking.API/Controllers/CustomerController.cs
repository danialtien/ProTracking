using Microsoft.AspNetCore.Mvc;
using ProTracking.API.Services.IServices;
using ProTracking.Application.ViewModels;
using ProTracking.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProTracking.API.Controllers
{
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly ICustomerService service;

        public CustomerController(ICustomerService _service)
        {
            this.service = _service;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public Task<IEnumerable<CustomerRegisterDTO>> GetAll()
        {
            return service.GetAllAsync();
        }



        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
