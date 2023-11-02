using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProTracking.API.Services;
using ProTracking.API.Services.IServices;
using ProTracking.Application.ViewModels;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using ProTracking.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;

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
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            if (userRole == RoleEnum.Admin.ToString())
            {
                // Admins can access all transaction history
                return await service.GetById(id);
            }
            else if (userRole == RoleEnum.Customer.ToString())
            {
                // Customers can only access their own transaction history
                var transaction = await service.GetById(id);

                if (transaction != null && transaction.CustomerId.ToString() == currentUserId)
                {
                    return transaction;
                }
            }

            return null; // Return 404 for unauthorized access
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

            if (result)
            {
                // Assuming you have a method to generate the picture URL based on the payment entity
                string pictureUrl = service.GeneratePictureUrl(entity);

                // You can also include the picture URL in the response JSON
                var response = new
                {
                    Payment = entity,
                    PictureUrl = pictureUrl
                };

                return Created(pictureUrl, response);
            }
            else
            {
                return BadRequest();
            }
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


        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Update exist transaction history for Admin ")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateTransactionForAdminOnly(int id, TransactionHistoryDTO entity, bool isBanking)
        {
            var exist = Exist(id);
            if (!exist) return NotFound();
            var result = await service.UpdateForAdminOnlyAsync(entity, isBanking);
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
