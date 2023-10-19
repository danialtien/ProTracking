using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using System.Linq.Expressions;

namespace ProTracking.API.Services.IServices
{
    public interface ILabelService
    {
        Task<bool> AddAsync(LabelDTO entity);
        Task<IEnumerable<Label>> GetAll(Expression<Func<Label, bool>>? filter = null, string[]? includeProperties = null);
        Task<LabelDTO> GetById(int id);
        Task<bool> SoftRemove(LabelDTO entity);
        Task<bool> SoftRemoveByID(int entityId);
        Task<bool> UpdateAsync(LabelDTO entity);
        Task<bool> UpdateRange(List<LabelDTO> entities);
    }
}
