﻿using Microsoft.AspNetCore.Mvc;
using ProTracking.API.Services;
using ProTracking.API.Services.IServices;
using ProTracking.Application.ViewModels;
using ProTracking.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProTracking.API.Controllers
{
    [ApiController]
    public class PaymentsController : BaseController
    {
        private readonly IPaymentService service;

        public PaymentsController(IPaymentService _service)
        {
            this.service = _service;
        }


        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Return all payments")]
        public async Task<IActionResult> GetAll()
        {
            var result = (await service.GetAll()).AsQueryable();

            var content = new
            {
                statusCode = 200,
                message = "Xử lý thành công!",
                listAllChildTask = result.ToList(),
                dateTime = DateTime.Now
            };

            var contentError = new
            {
                statusCode = 400,
                message = "Xử lý thất bại!",
                dateTime = DateTime.Now
            };
            return result.Count() > 0 ? Ok(content) : BadRequest(contentError);
        }



        // GET api/<PaymentsController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get payment by Id")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await service.GetById(id);
            var content = new
            {
                statusCode = 200,
                message = "Xử lý thành công!",
                PaymentById = result,
                dateTime = DateTime.Now
            };

            var contentError = new
            {
                statusCode = 400,
                message = "Xử lý thất bại!",
                dateTime = DateTime.Now
            };
            return result != null ? Ok(content) : BadRequest(contentError);
        }

        // POST api/<PaymentsController>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Create a new payment")]
        public async Task<IActionResult> Post(Payment entity)
        {
            var result = await service.AddAsync(entity);
            var content = new
            {
                statusCode = 201,
                message = "Xử lý thành công!",
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

        //// PUT api/<PaymentsController>/5
        //[HttpPut("{id}")]
        //[Produces("application/json")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[SwaggerOperation(Summary = "Update exist payment")]
        //public async Task<IActionResult> Update(int id, Payment entity)
        //{
        //    var exist = Exist(id);
        //    if (!exist) return NotFound();
        //    var result = await service.UpdateAsync(entity);
        //    return result ? Ok() : BadRequest();
        //}

        //// DELETE api/<PaymentsController>/5
        //[HttpDelete("{id}")]
        //[Produces("application/json")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[SwaggerOperation(Summary = "Set payment status inactive")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var exist = Exist(id);
        //    if (!exist) return NotFound();
        //    var result = await service.SoftRemoveByID(id);
        //    return result ? Ok() : BadRequest();
        //}

        private bool Exist(int id)
        {
            var payment = service.GetById(id);
            if (payment == null) return false;
            return true;
        }
    }
}
