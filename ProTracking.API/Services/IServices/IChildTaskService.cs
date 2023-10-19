using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using System.Linq.Expressions;

namespace ProTracking.API.Services.IServices
{
    public interface IChildTaskService 
    {
        Task<bool> AddAsync(ChildTaskDTO entity);
        Task<IEnumerable<ChildTask>> GetAll(Expression<Func<ChildTask, bool>>? filter = null, string[]? includeProperties = null);
        Task<ChildTaskDTO> GetById(int id);
        Task<bool> SoftRemove(ChildTaskDTO entity);
        Task<bool> SoftRemoveByID(int entityId);
        Task<bool> UpdateAsync(ChildTaskDTO entity);
        Task<bool> UpdateRange(List<ChildTaskDTO> entities);
    }
}
