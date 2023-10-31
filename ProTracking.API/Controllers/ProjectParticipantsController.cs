using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ProTracking.API.Services.IServices;
using ProTracking.Domain.Entities.DTOs;
using ProTracking.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using ProTracking.API.Services;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProTracking.API.Controllers
{
    [ApiController]
    public class ProjectParticipantsController : BaseController
    {
        private readonly IProjectParticipantService service;
        private readonly ICustomerService customerService;

        public ProjectParticipantsController(IProjectParticipantService _service, ICustomerService _customerService)
        {
            this.service = _service;
            this.customerService = _customerService;
        }

        [EnableQuery]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get All ProjectParticipant by OData ProjectParticipant - Done")]
        public async Task<IEnumerable<ProjectParticipant>> GetAllODataForAdmin()
        {
            return (await service.GetAll()).AsQueryable();
        }

        [EnableQuery]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get All ProjectParticipant by OData ProjectParticipant - Done")]
        public async Task<IEnumerable<ProjectParticipant>> GetAllOData([Required] int ProjectId)
        {
            return (await service.GetAll()).AsQueryable().Where(c => c.ProjectId == ProjectId);
        }

        // POST api/<ProjectParticipantsController>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Create a new ProjectParticipant - Done")]
        public async Task<IActionResult> Post(ProjectParticipantDTO entity)
        {
            // Get the customer's account type
            //var customer = await customerService.GetById(entity.CustomerId);
            //if (customer == null)
            //{
            //    return BadRequest("Customer not found.");
            //}

            // Get the customer's JWT token
            string customerToken = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");

            // Check if the customer token is present
            if (string.IsNullOrEmpty(customerToken))
            {
                return BadRequest("Customer token not provided.");
            }

            // Parse the JWT token to obtain claims
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(customerToken);

            // Extract the "AccountType" claim
            string accountType = token.Claims.FirstOrDefault(c => c.Type == "AccountType")?.Value;

            if (string.IsNullOrEmpty(accountType))
            {
                return BadRequest("AccountType claim not found in the token.");
            }

            int maxParticipants = 0;

            // Determine the maximum number of participants based on the account type
            switch (accountType)
            {
                case "Free":
                    maxParticipants = 3;
                    break;
                case "Standard":
                    maxParticipants = 10;
                    break;
                case "Premium":
                    maxParticipants = int.MaxValue; // Unlimited for Premium
                    break;
                default:
                    return BadRequest("Invalid account type.");
            }

            // Check the number of existing participants for the customer
            var existingParticipants = await service.GetParticipantsByCustomerId(entity.CustomerId);
            if (existingParticipants.Count() >= maxParticipants)
            {
                return BadRequest($"Customers with '{accountType}' accounts can only add up to {maxParticipants} participants.");
            }

            // Customers with other account types can add participants without restrictions
            var result = await service.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }


        // PUT api/<ProjectParticipantsController>/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Update exist ProjectParticipant - Done")]
        public async Task<IActionResult> Update(int id, ProjectParticipantDTO dto)
        {
            var exist = Exist(id);
            if (!exist) return NotFound();
            var result = await service.UpdateAsync(dto);
            return result ? Ok() : BadRequest();
        }

        // DELETE api/<ProjectParticipantsController>/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Delete exist ProjectParticipant by Id - Done")]
        public async Task<IActionResult> Delete(int id)
        {
            var exist = Exist(id);
            if (!exist) return NotFound();
            var result = await service.SoftRemoveByID(id);
            return result ? Ok() : BadRequest();
        }

        private bool Exist(int id)
        {
            var obj = service.GetById(id);
            if (obj == null) return false;
            return true;
        }
    }
}
