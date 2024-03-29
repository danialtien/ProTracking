﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ProTracking.API.Services;
using ProTracking.API.Services.IServices;
using ProTracking.Application.ViewModels;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

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


        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Return all customers")]
        [Authorize(Roles = "Admin")]
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
            return result.Count() > 0 ? Ok(content) : Ok(contentError);
        }



        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get Customer by Id")]
        public async Task<IActionResult> Get(int id)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            bool check = false;
            var result = await service.GetById(id);

            var content = new
            {
                statusCode = 200,
                message = "Xử lý thành công!",
                AccountTypeById = result,
                dateTime = DateTime.Now
            };

            var contentError = new
            {
                statusCode = 400,
                message = "Not found!",
                dateTime = DateTime.Now
            };

            if (result == null)
            {
                return Ok(contentError);
            }
            if (currentUserId == result.Id.ToString() && userRole == RoleEnum.Customer.ToString())
            {
                return Ok(content);
            }

            if (currentUserId == result.Id.ToString() && userRole == RoleEnum.Admin.ToString())
            {
                return Ok(content);
            }

            return Ok(contentError);
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get Customer by email")]
        public IActionResult GetByEmail([Required] string email)
        {
            var result = service.GetCustomerByEmailAsync(email);
            var content = new
            {
                statusCode = 200,
                message = "Xử lý thành công!",
                AccountTypeById = result,
                dateTime = DateTime.Now
            };

            var contentError = new
            {
                statusCode = 400,
                message = "Xử lý thất bại!",
                dateTime = DateTime.Now
            };
            return result.Result != null ? Ok(content) : Ok(contentError);
        }

        // POST api/<CustomersController>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Create a new customer")]
        public async Task<IActionResult> Post(Customer entity)
        {
            var result = await service.AddAsync(entity);
            var content = new
            {
                statusCode = 200,
                message = "Xử lý thành công!",
                dateTime = DateTime.Now
            };

            var contentError = new
            {
                statusCode = 400,
                message = "Xử lý thất bại!",
                dateTime = DateTime.Now
            };
            return result ? Ok(content) : Ok(contentError);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Update exist customer")]
        public async Task<IActionResult> Update(int id, Customer entity)
        {
            var exist = Exist(id);
            if (!exist) return NotFound();
            var result = await service.UpdateAsync(entity);
            var content = new
            {
                statusCode = 200,
                message = "Xử lý thành công!",
                dateTime = DateTime.Now
            };

            var contentError = new
            {
                statusCode = 400,
                message = "Xử lý thất bại!",
                dateTime = DateTime.Now
            };
            return result ? Ok(content) : Ok(contentError);
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Set customer status inactive")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var exist = Exist(id);
            if (!exist) return NotFound();
            var result = await service.SoftRemoveByID(id);
            var content = new
            {
                statusCode = 200,
                message = "Xử lý thành công!",
                dateTime = DateTime.Now
            };

            var contentError = new
            {
                statusCode = 400,
                message = "Xử lý thất bại!",
                dateTime = DateTime.Now
            };
            return result ? Ok(content) : Ok(contentError);
        }



        /*        // GET api/<CustomersController>/5
                [HttpGet("{email}")]
                [Produces("application/json")]
                [ProducesResponseType(StatusCodes.Status200OK)]
                [ProducesResponseType(StatusCodes.Status404NotFound)]
                [SwaggerOperation(Summary = "Get Customer by Email")]
                public async Task<Customer> GetByEmail(string email)
                {
                    return await service.GetByEmail(email);
                }*/
        private bool Exist(int id)
        {
            var customer = service.GetById(id);
            if (customer == null) return false;
            return true;
        }
    }
}
