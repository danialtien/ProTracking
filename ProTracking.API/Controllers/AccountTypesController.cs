using Microsoft.AspNetCore.Mvc;
using ProTracking.API.Services;
using ProTracking.API.Services.IServices;
using ProTracking.Application.ViewModels;
using ProTracking.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProTracking.API.Controllers
{
    [ApiController]
    public class AccountTypeController : BaseController
    {
        private readonly IAccountTypeService service;

        public AccountTypeController(IAccountTypeService _service)
        {
            this.service = _service;
        }


        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Return all account types")]
        public async Task<IEnumerable<AccountType>> GetAll()
        {
            return await service.GetAll(null, null);
        }



        // GET api/<AccountTypesController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get account type by Id")]
        public async Task<AccountType> Get(int id)
        {
            return await service.GetById(id);
        }

        // POST api/<AccountTypesController>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Create a new account type")]
        public async Task<IActionResult> Post(AccountType entity)
        {
            var result = await service.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }

        // PUT api/<AccountTypesController>/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Update exist account type")]
        public async Task<IActionResult> Update(int id, AccountType entity)
        {
            var exist = Exist(id);
            if (!exist) return NotFound();
            var result = await service.UpdateAsync(entity);
            return result ? Ok() : BadRequest();
        }

        // DELETE api/<AccountTypesController>/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Set account type status inactive")]
        public async Task<IActionResult> Delete(int id)
        {
            var exist = Exist(id);
            if (!exist) return NotFound();
            var result = await service.SoftRemoveByID(id);
            return result ? Ok() : BadRequest();
        }

        private bool Exist(int id)
        {
            var accountType = service.GetById(id);
            if (accountType == null) return false;
            return true;
        }
    }
}
