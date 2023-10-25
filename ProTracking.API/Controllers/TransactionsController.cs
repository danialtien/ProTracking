using Microsoft.AspNetCore.Mvc;
using ProTracking.API.Services;
using ProTracking.API.Services.IServices;
using ProTracking.Application.ViewModels;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProTracking.API.Controllers
{
    [ApiController]
    public class TransactionsController : BaseController
    {
        private readonly ITransactionService service;

        public TransactionsController(ITransactionService _service)
        {
            this.service = _service;
        }


        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Return all transaction histories")]
        public async Task<IEnumerable<TransactionHistory>> GetAll()
        {
            return await service.GetAll(null, null);
        }



        // GET api/<TransactionsController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get transaction history by Id")]
        public async Task<TransactionHistoryDTO> Get(int id)
        {
            return await service.GetById(id);
        }

        // POST api/<TransactionsController>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Create a new transaction history")]
        public async Task<IActionResult> Post(TransactionHistoryDTO entity)
        {
            var result = await service.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }

        // PUT api/<TransactionsController>/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Update exist transaction history")]
        public async Task<IActionResult> Update(int id, TransactionHistoryDTO entity)
        {
            var exist = Exist(id);
            if (!exist) return NotFound();
            var result = await service.UpdateAsync(entity);
            return result ? Ok() : BadRequest();
        }

        // DELETE api/<TransactionsController>/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Set transaction history status inactive")]
        public async Task<IActionResult> Delete(int id)
        {
            var exist = Exist(id);
            if (!exist) return NotFound();
            var result = await service.SoftRemoveByID(id);
            return result ? Ok() : BadRequest();
        }

        private bool Exist(int id)
        {
            var transaction = service.GetById(id);
            if (transaction == null) return false;
            return true;
        }
    }
}
