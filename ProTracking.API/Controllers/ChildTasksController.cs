using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ProTracking.API.Services.IServices;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProTracking.API.Controllers
{
    [ApiController]
    public class ChildTasksController : BaseController
    {
        private readonly IChildTaskService service;

        public ChildTasksController(IChildTaskService _service)
        {
            this.service = _service;
        }

        [EnableQuery]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get All ChildTask by OData ChildTask - Done")]
        public async Task<IEnumerable<ChildTask>> GetAllOData()
        {
            return (await service.GetAll()).AsQueryable();
        }

        // POST api/<ChildTasksController>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Create a new ChildTask - Done")]
        public async Task<IActionResult> Post(ChildTaskDTO entity)
        {
            var result = await service.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }

        // PUT api/<ChildTasksController>/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Update exist ChildTask - Done")]
        public async Task<IActionResult> Update(int id, ChildTaskDTO dto)
        {
            var exist = Exist(id);
            if (!exist) return NotFound();
            var result = await service.UpdateAsync(dto);
            return result ? Ok() : BadRequest();
        }

        // DELETE api/<ChildTasksController>/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Delete exist ChildTask by Id - Done")]
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
