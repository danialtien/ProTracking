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
    public class CommentsController : BaseController
    {
        private readonly ICommentService service;

        public CommentsController(ICommentService _service)
        {
            this.service = _service;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Return all comments")]
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

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get comment by Id")]
        public async Task<IActionResult> Get(int id)
        {
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
                message = "Xử lý thất bại!",
                dateTime = DateTime.Now
            };
            return result != null ? Ok(content) : BadRequest(contentError);
        }

        // POST api/<CommentsController>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Create a new comment")]
        public async Task<IActionResult> Post(CommentDTO entity)
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

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Update exist comment")]
        public async Task<IActionResult> Update(int id, CommentDTO entity)
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
            return result ? Ok(content) : BadRequest(contentError);
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Set comment status inactive")]
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
            return result ? Ok(content) : BadRequest(contentError);
        }

        private bool Exist(int id)
        {
            var comment = service.GetById(id);
            if (comment == null) return false;
            return true;
        }
    }
}
