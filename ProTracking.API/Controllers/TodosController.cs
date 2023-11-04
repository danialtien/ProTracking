using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ProTracking.API.Services.IServices;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProTracking.API.Controllers
{
    [ApiController]
    public class TodosController : BaseController
    {
        private readonly ITodoService service;

        public TodosController(ITodoService _service)
        {
            this.service = _service;
        }


        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get All Todo by Filtering Todo - Done")]
        public async Task<IActionResult> GetAllByFilter(
            [Required]int? projectId,
            int? todoId,
            int? labelId,
            string? title,
            string? status,
            DateTime? startDate,
            DateTime? endDate,
            int? assignee,
            int? createdBy)
        {
            // Start with a base query for Todo items
            var query = (await service.GetAll()).AsQueryable();

            // Apply filters based on the provided parameters
            if (projectId.HasValue)
            {
                query = query.Where(todo => todo.ProjectId == projectId.Value);
            }

            if (todoId.HasValue)
            {
                query = query.Where(todo => todo.Id == todoId.Value);
            }

            if (labelId.HasValue)
            {
                query = query.Where(todo => todo.LabelId == labelId.Value);
            }

            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(todo => todo.Title.Contains(title));
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(todo => todo.Status == status);
            }

            if (startDate != null)
            {
                query = query.Where(todo => todo.StartDate >= startDate);
            }

            if (endDate != null)
            {
                query = query.Where(todo => todo.EndDate <= endDate);
            }

            if (assignee > 0)
            {
                query = query.Where(todo => todo.Assignee == assignee);
            }

            if (createdBy > 0)
            {
                query = query.Where(todo => todo.CreatedBy == createdBy);
            }

            // Include related properties (eager loading)
            /*query = query.Include(todo => todo.Project)
                        .Include(todo => todo.Label)
                        .Include(todo => todo.Customer);*/

            // Execute the query and return the filtered Todo items
             var result = query.ToList().Count > 0;

            var content = new
            {
                statusCode = 200,
                message = "Xử lý thành công!",
                listTodoFilter = query.ToList(),
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

        [EnableQuery]
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Get All Todo by OData Todo - Done")]
        public async Task<IActionResult> GetAllOData([Required] int ProjectId)
        { 
            
            var getAllTodoByProjectId = (await service.GetAll()).AsQueryable().Where(p => p.ProjectId == ProjectId);
            var result = getAllTodoByProjectId.ToList().Count > 0;
            var content = new
            {
                statusCode = 200,
                message = "Xử lý thành công!",
                listTodoByProjectId = getAllTodoByProjectId.ToList(),
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

        // POST api/<TodosController>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Create a new Todo - Done")]
        public async Task<IActionResult> Post(TodoDTO entity)
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

        // PUT api/<TodosController>/5
        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Update exist Todo ")]
        public async Task<IActionResult> Update(int id, TodoDTO dto)
        {
            var exist = Exist(id);
            if (!exist) return NotFound();
            var result = await service.UpdateAsync(dto);
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


        [HttpPut]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Update Todo Status")]
        public async Task<IActionResult> UpdateTodoStatusByTodoId(int todoId, string status)
        {
            var todoDTO = await service.GetById(todoId);
            if(todoDTO == null) return NotFound();
            todoDTO.Status = status;
            var result = await service.UpdateAsync(todoDTO);
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

        // DELETE api/<TodosController>/5
        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Delete exist Todo by Id - Done")]
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
            var obj = service.GetById(id);
            if (obj == null) return false;
            return true;
        }
    }
}
