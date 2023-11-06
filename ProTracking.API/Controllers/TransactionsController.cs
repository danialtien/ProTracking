using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProTracking.API.Services;
using ProTracking.API.Services.IServices;
using ProTracking.Application.ViewModels;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using ProTracking.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections;
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
        [Authorize(Roles = "Admin")]
        public async Task<IEnumerable<TransactionHistory>> GetAll()
        {
            return await service.GetAll(null, null);
        }

        // GET api/<TransactionsController>/5
        [HttpGet("{userId}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get transaction history by UserId")]
        public async Task<IActionResult> Get(int userId)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            IEnumerable<TransactionHistoryDTO> list = new List<TransactionHistoryDTO>();
            if (userRole == RoleEnum.Admin.ToString())
            {
                list = await service.GetByUserId(userId);
            }
            else if (userRole == RoleEnum.Customer.ToString() && currentUserId == userId.ToString())
            {
                // Customers can only access their own transaction history
                list = await service.GetByUserId(userId);
            }

            var content = new
            {
                statusCode = 200,
                message = "Xử lý thành công!",
                listTransaction = list,
                dateTime = DateTime.Now
            };

            var contentError = new
            {
                statusCode = 404,
                message = "Không tìm thấy!",
                dateTime = DateTime.Now
            };
            return list!.Count() >  0 ? Ok(content) : NotFound(contentError);
        }

        // POST api/<TransactionsController>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Create a new transaction history")]
        public async Task<IActionResult> Post(TransactionHistoryDTO entity)
        {
            entity.IsBanking = false;
            var result = await service.AddAsync(entity);

            var content = new
            {
                statusCode = 200,
                message = "Thực hiện thành công! Xử lý giao dịch sẽ được thực hiện trong vòng 24h",
                dateTime = DateTime.Now
            };

            var contentError = new
            {
                statusCode = 400,
                message = "Xử lý thất bại!",
                dateTime = DateTime.Now
            };
            return result ? Ok(content) : BadRequest(contentError);
        }

        // PUT api/<TransactionsController>/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Update exist transaction history")]
        [Authorize(Roles = "Admin")]
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


        private bool Exist(int id)
        {
            var transaction = service.GetById(id);
            if (transaction == null) return false;
            return true;
        }
    }
}
