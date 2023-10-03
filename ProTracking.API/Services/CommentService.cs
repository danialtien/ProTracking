using AutoMapper;
using ProTracking.API.Services.IServices;
using ProTracking.Application.ViewModels;
using ProTracking.Application.ViewModels.FilterModel;
using ProTracking.Domain.Entities;
using ProTracking.Infrastructures.Repository;
using System.Linq.Expressions;

namespace ProTracking.API.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> AddAsync(Comment entity)
        {
            if (entity == null) return false;
            bool result = await _unitOfWork.CommentRepo.AddAsync(entity);
            return result;
        }

        public async Task<IEnumerable<Comment>> GetAll(Expression<Func<Comment, bool>>? filter = null, string[]? includeProperties = null)
        {
            var _data = await _unitOfWork.CommentRepo.GetAllAsync(filter, includeProperties);
            return _data;
        }

        public async Task<Comment> GetById(int id)
        {
            Comment? comment = await _unitOfWork.CommentRepo.GetByIdAsync(id);
            return comment;
        }

        //public Task<IEnumerable<Comment>> GetFilterAsync(CommentFilteringModel entity)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> SoftRemove(Comment entity)
        {
            if (entity == null) return false;
            bool result = await _unitOfWork.CommentRepo.SoftRemoveAsync(entity);
            return result;
        }

        public async Task<bool> SoftRemoveByID(int entityId)
        {
            Comment? comment = await GetById(entityId);
            if (comment != null)
            {
                await SoftRemove(comment);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(Comment entity)
        {
            if (entity != null)
            {
                bool result = await _unitOfWork.CommentRepo.UpdateAsync(entity);
                return result;
            }
            return false;
        }

        public async Task<bool> UpdateRange(List<Comment> entities)
        {
            if (entities != null)
            {
                return await _unitOfWork.CommentRepo.UpdateRangeAsync(entities);
            }
            return false;
        }
    }
}
