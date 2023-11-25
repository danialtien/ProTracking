using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using System.Linq.Expressions;

namespace ProTracking.API.Services.IServices
{
    public interface IProjectService
    {
        Task<bool> AddAsync(ProjectDTO entity);
        Task<IEnumerable<Project>> GetAll(Expression<Func<Project, bool>>? filter = null, string[]? includeProperties = null);
        Task<GetProjectWithTodoAndPaties> GetProjectByIdWithTodoAndParticipant(int id);
        Task<bool> SoftRemove(Project entity);
        Task<bool> SoftRemoveByID(int entityId);
        Task<bool> UpdateAsync(ProjectDTO entity);
        Task<bool> UpdateRange(List<ProjectDTO> entities);
        Task<ICollection<ProjectDTO>> GetAllProjectByUserId(int createdBy);
    }
}
