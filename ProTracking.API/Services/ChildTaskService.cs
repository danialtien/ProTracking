using AutoMapper;
using ProTracking.API.Services.IServices;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using ProTracking.Infrastructures.Repository;
using System.Linq.Expressions;

namespace ProTracking.API.Services
{
    public class ChildTaskService : IChildTaskService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChildTaskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<bool> AddAsync(ChildTaskDTO entity)
        {
            if (entity == null) return false;
            ChildTask obj = _mapper.Map<ChildTask>(entity);
            bool result = await _unitOfWork.ChildTaskRepo.AddAsync(obj);
            return result;
        }

        public async Task<IEnumerable<ChildTask>> GetAll(Expression<Func<ChildTask, bool>>? filter = null, string[]? includeProperties = null)
        {
            var _data = await _unitOfWork.ChildTaskRepo.GetAllAsync(filter, includeProperties);
            return _data;
        }

        public async Task<ChildTaskDTO> GetById(int id)
        {
            ChildTask? obj = await _unitOfWork.ChildTaskRepo.GetByIdAsync(id);
            ChildTaskDTO dto = _mapper.Map<ChildTaskDTO>(obj);
            return dto;
        }

        public async Task<bool> SoftRemove(ChildTaskDTO entity)
        {
            if (entity == null) return false;
            ChildTask obj = _mapper.Map<ChildTask>(entity);
            bool result = await _unitOfWork.ChildTaskRepo.SoftRemoveAsync(obj);
            return result;
        }

        public async Task<bool> SoftRemoveByID(int entityId)
        {
            ChildTaskDTO? obj = await GetById(entityId);
            if (obj != null)
            {
                await SoftRemove(obj);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(ChildTaskDTO entity)
        {
            if (entity != null)
            {
                ChildTask obj = _mapper.Map<ChildTask>(entity);
                bool result = await _unitOfWork.ChildTaskRepo.UpdateAsync(obj);
                return result;
            }
            return false;
        }

        public async Task<bool> UpdateRange(List<ChildTaskDTO> entities)
        {
            if (entities != null)
            {
                List<ChildTask> objs = _mapper.Map<List<ChildTask>>(entities);
                return await _unitOfWork.ChildTaskRepo.UpdateRangeAsync(objs);
            }
            return false;
        }
    }
}
