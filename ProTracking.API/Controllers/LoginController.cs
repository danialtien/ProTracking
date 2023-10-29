﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProTracking.API.Services.IServices;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using Swashbuckle.AspNetCore.Annotations;

namespace ProTracking.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ICustomerService service;

        public LoginController(ICustomerService _service)
        {
            this.service = _service;
        }

        [HttpPost("Login")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Login")]
        public IActionResult Login(LoginDTO login)
        {
            if (login == null) return NotFound("Account does not exist");
            string token = service.checkLogin(login);
            return token is null ? NotFound("Account does not exist") : Ok(token);
        }

        // POST api/<CustomersController>
        [HttpPost("Register")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Create a new customer")]
        public async Task<IActionResult> Post(RegisterDTO entity)
        {
            MessageHandler result = await service.RegisterAccount(entity);
            if(result.StatusCode == 201)
            {
                return Ok(result);
            } else
            {
                return BadRequest(result);
            }
        }
    }
}