using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using System.Linq.Expressions;

namespace ProTracking.API.Services.IServices
{
    public interface IProjectParticipantService
    {
        Task<bool> AddAsync(ProjectParticipantDTO entity);
        Task<IEnumerable<ProjectParticipant>> GetAll(Expression<Func<ProjectParticipant, bool>>? filter = null, string[]? includeProperties = null);
        Task<ProjectParticipantDTO> GetById(int id);
        Task<bool> SoftRemove(ProjectParticipantDTO entity);
        Task<bool> SoftRemoveByID(int entityId);
        Task<bool> UpdateAsync(ProjectParticipantDTO entity);
        Task<bool> UpdateRange(List<ProjectParticipantDTO> entities);
        Task<IEnumerable<ProjectParticipant>> GetParticipantsByCustomerId(int customerId);
        Task<IEnumerable<ProjectParticipant>> GetByProjectId(int projectId);
    }
}
