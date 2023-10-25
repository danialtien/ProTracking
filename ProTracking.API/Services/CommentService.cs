using AutoMapper;
using ProTracking.API.Services.IServices;
using ProTracking.Application.ViewModels;
using ProTracking.Application.ViewModels.FilterModel;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using ProTracking.Infrastructures.Repository;
using System.Linq.Expressions;

namespace ProTracking.API.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<bool> AddAsync(CommentDTO entity)
        {
            // if(!_validation.CreateObjectIsValid(entity)) return false;
            Comment Comment = _mapper.Map<Comment>(entity);
            bool result = await _unitOfWork.CommentRepo.AddAsync(Comment);
            return result;
        }

        public async Task<IEnumerable<Comment>> GetAll(Expression<Func<Comment, bool>>? filter = null, string[]? includeProperties = null)
        {
            var _data = (await _unitOfWork.CommentRepo.GetAllAsync(filter, includeProperties)).Select(Comment => _mapper.Map<Comment>(Comment));
            return _data;
        }

        public async Task<CommentDTO> GetById(int id)
        {
            if (id == 0) return null;
            Comment? obj = await _unitOfWork.CommentRepo.GetByIdAsync(id);
            CommentDTO CommentDTO = _mapper.Map<CommentDTO>(obj);
            return CommentDTO;
        }

        public async Task<bool> SoftRemove(CommentDTO entity)
        {
            if (entity == null) return false;
            Comment Comment = _mapper.Map<Comment>(entity);
            bool result = await _unitOfWork.CommentRepo.SoftRemoveAsync(Comment);
            return result;

        }

        public async Task<bool> SoftRemoveByID(int entityId)
        {
            CommentDTO? obj = await GetById(entityId);
            if (obj != null)
            {
                await SoftRemove(obj);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(CommentDTO entity)
        {
            if (entity != null)
            {
                Comment Comment = _mapper.Map<Comment>(entity);
                bool result = await _unitOfWork.CommentRepo.UpdateAsync(Comment);
                return result;
            }
            return false;
        }

        public async Task<bool> UpdateRange(List<CommentDTO> entities)
        {
            if (entities != null)
            {
                List<Comment> Comment = _mapper.Map<List<Comment>>(entities);
                return await _unitOfWork.CommentRepo.UpdateRangeAsync(Comment);
            }
            return false;
        }
    }
}
