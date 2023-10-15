using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ProTracking.API.Services.IServices;
using ProTracking.Domain.Entities.DTOs;
using ProTracking.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProTracking.API.Controllers
{
    [ApiController]
    public class LabelsController : BaseController
    {
        private readonly ILabelService service;

        public LabelsController(ILabelService _service)
        {
            this.service = _service;
        }

        [EnableQuery]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get All Label by OData Label - Done")]
        public async Task<IEnumerable<Label>> GetAllOData()
        {
            return (await service.GetAll()).AsQueryable();
        }

        // POST api/<LabelsController>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Create a new Label - Done")]
        public async Task<IActionResult> Post(LabelDTO entity)
        {
            var result = await service.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }

        // PUT api/<LabelsController>/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Update exist Label - Done")]
        public async Task<IActionResult> Update(int id, LabelDTO dto)
        {
            var exist = Exist(id);
            if (!exist) return NotFound();
            var result = await service.UpdateAsync(dto);
            return result ? Ok() : BadRequest();
        }

        // DELETE api/<LabelsController>/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Delete exist Label by Id - Done")]
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
