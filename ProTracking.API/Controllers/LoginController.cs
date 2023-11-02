using Microsoft.AspNetCore.Http;
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

        /*[HttpPost("Login")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Login")]
        public IActionResult Login(LoginDTO login)
        {
            if (login == null) return NotFound("Account does not exist");
            string token = service.checkLogin(login);
            return token is null ? NotFound("Account does not exist") : Ok(token);
        }*/

        [HttpPost("Login")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Login")]
        public IActionResult Login(LoginDTO login)
        {
            string token = service.checkLogin(login);
            if (token is null)
            {
                return NotFound("Account does not exist");
            }
            else
            {
                Customer customer =  service.GetCustomerByEmailandPassword(login);
                var content = new
                {
                    statusCode = 200,
                    message = "Xử lý thành công!",
                    content = new
                    {
                        accessToken = token,
                        customer
                    },
                    dateTime = DateTime.Now
                };
                return Ok(content);
            }
        }

        /* public string Login(LoginDTO login)
         {
             if (login == null) return "Account does not exist";
             string token = service.checkLogin(login);
             return token is null ? "Account does not exist" : token;
         }*/

        /*// POST api/<CustomersController>
        [HttpPost("Register")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Create a new customer")]
        public async Task<IActionResult> Post(RegisterDTO entity)
        {
            MessageHandler result = await service.RegisterAccount(entity);
            if (result.StatusCode == 201)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }*/

        // POST api/<CustomersController>
        [HttpPost("Register")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Create a new customer")]
        public async Task<IActionResult> Post(RegisterDTO entity)
        {
            MessageHandler result = await service.RegisterAccount(entity);
            if (result.StatusCode == 201)
            {
                var content = new
                {
                    statusCode = 201,
                    message = "Xử lý thành công!",
                    dateTime = DateTime.Now
                };
                return Ok(content);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
