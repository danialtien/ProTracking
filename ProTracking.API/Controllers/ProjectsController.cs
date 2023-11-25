using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ProTracking.API.Services.IServices;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProTracking.API.Controllers
{
    public class ProjectsController : BaseController
    {
        private readonly IProjectService service;

        public ProjectsController(IProjectService _service)
        {
            this.service = _service;
        }

        // GET api/<ProjectsController>/all
        [HttpGet]
        //[Authorize(Roles = "Customer")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get All Projects by Created by")]
        public async Task<IActionResult> GetAllOData([Required] int createdBy)
        {
            var projects = (await service.GetAllProjectByUserId(createdBy));

            var content = new
            {
                statusCode = 200,
                message = "Xử lý thành công!",
                content = new
                {
                    listProjectByCreator = projects.ToList(),
                },
                dateTime = DateTime.Now
            };

            var contentError = new
            {
                statusCode = 400,
                message = "Không có",
                dateTime = DateTime.Now
            };
            return projects.ToList().Count > 0 ? Ok(content) : Ok(contentError);
        }

        // GET api/<ProjectsController>/all
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get All Projects by UserId")]
        public async Task<IActionResult> GetAllProjectByUserId([Required] int userId)
        {
            var projects = (await service.GetAllProjectByUserId(userId));

            var content = new
            {
                statusCode = 200,
                message = "Xử lý thành công!",
                content = new
                {
                    listProjectByCreator = projects.ToList(),
                },
                dateTime = DateTime.Now
            };

            var contentError = new
            {
                statusCode = 400,
                message = "Không có",
                dateTime = DateTime.Now
            };
            return projects.ToList().Count > 0 ? Ok(content) : Ok(contentError);
        }
        // GET api/<ProjectsController>/all Admin
        [HttpGet]
        [EnableQuery]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get All Project by OData")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllODataForAdmin()
        {
            var projects = await service.GetAll();

            var content = new
            {
                statusCode = 200,
                message = "Xử lý thành công!",
                content = new
                {
                    listProjectForAdmin = projects.ToList(),
                },
                dateTime = DateTime.Now
            };
            return Ok(content);
        }

        [HttpGet]
        //[Authorize(Roles = "Customer")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get project by Id")]
        public async Task<IActionResult> GetProjectByIdWithTodoAndParticipant([Required]int id)
        {
            var project = await service.GetProjectByIdWithTodoAndParticipant(id);

            var content = new
            {
                statusCode = 200,
                message = "Xử lý thành công!",
                content = new
                {
                    projectById = project,
                },
                dateTime = DateTime.Now
            };

            var contentError = new
            {
                statusCode = 400,
                message = "Không tìm thấy!",
                dateTime = DateTime.Now
            };
            return project != null ? Ok(content) : Ok(contentError);
        }

        // POST api/<ProjectsController>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Create a new project")]
        public async Task<IActionResult> Post(ProjectDTO entity)
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
                message = "Xử lý thấy bại!",
                dateTime = DateTime.Now
            };
            return result ? Ok(content) : Ok(contentError);
        }

        // PUT api/<ProjectsController>/5
        [HttpPut]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Update exist project")]
        public async Task<IActionResult> Update(ProjectDTO entity)
        {

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

        // DELETE api/<ProjectsController>/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Delete exist project")]
        public async Task<IActionResult> Delete(int id)
        {
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
            var result = await service.SoftRemoveByID(id);
            return result ? Ok(content) : Ok(contentError);
        }

        private bool Exist(int id)
        {
            var obj = service.GetProjectByIdWithTodoAndParticipant(id);
            if (obj == null) return false;
            return true;
        }
    }
}
