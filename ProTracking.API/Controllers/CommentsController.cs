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
        public async Task<IEnumerable<Comment>> GetAll()
        {
            return await service.GetAll(null, null);
        }



        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get comment by Id")]
        public async Task<Comment> Get(int id)
        {
            return await service.GetById(id);
        }

        // POST api/<CommentsController>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Create a new comment")]
        public async Task<IActionResult> Post(Comment entity)
        {
            var result = await service.AddAsync(entity);
            return result ? Ok() : BadRequest();
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Update exist comment")]
        public async Task<IActionResult> Update(int id, Comment entity)
        {
            var exist = Exist(id);
            if (!exist) return NotFound();
            var result = await service.UpdateAsync(entity);
            return result ? Ok() : BadRequest();
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
            return result ? Ok() : BadRequest();
        }

        private bool Exist(int id)
        {
            var comment = service.GetById(id);
            if (comment == null) return false;
            return true;
        }
    }
}
