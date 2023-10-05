using ProTracking.Application.ViewModels;
using ProTracking.Domain.Entities;
using System.Linq.Expressions;

namespace ProTracking.API.Services.IServices
{
    public interface IGenericService<T> where T : class
    {
        Task<bool> AddAsync(T entity);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string[]? includeProperties = null);
        Task<T> GetById(int id);
        Task<bool> SoftRemove(T entity);
        Task<bool> SoftRemoveByID(int entityId);
        Task<bool> UpdateAsync(T entity);
        Task<bool> UpdateRange(List<T> entities);
    }
}
