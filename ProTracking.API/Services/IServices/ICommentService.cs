using ProTracking.Application.ViewModels;
using ProTracking.Application.ViewModels.FilterModel;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using System.Linq.Expressions;

namespace ProTracking.API.Services.IServices
{
    public interface ICommentService
    {
        Task<bool> AddAsync(CommentDTO entity);
        Task<IEnumerable<Comment>> GetAll(Expression<Func<Comment, bool>>? filter = null, string[]? includeProperties = null);
        Task<CommentDTO> GetById(int id);
        Task<bool> SoftRemove(CommentDTO entity);
        Task<bool> SoftRemoveByID(int entityId);
        Task<bool> UpdateAsync(CommentDTO entity);
        Task<bool> UpdateRange(List<CommentDTO> entities);
    }
}
