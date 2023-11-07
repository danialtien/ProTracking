using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using System.Linq.Expressions;

namespace ProTracking.API.Services.IServices
{
    public interface ITodoService 
    {
        Task<Todo> AddAsync(TodoDTO entity);
        Task<IEnumerable<Todo>> GetAll(Expression<Func<Todo, bool>>? filter = null, string[]? includeProperties = null);
        Task<TodoDTO> GetById(int id);
        Task<bool> SoftRemove(TodoDTO entity);
        Task<bool> SoftRemoveByID(int entityId);
        Task<bool> UpdateAsync(TodoDTO entity);
        Task<bool> UpdateRange(List<TodoDTO> entities);
    }
}
