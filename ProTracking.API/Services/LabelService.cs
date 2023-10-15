using AutoMapper;
using ProTracking.API.Services.IServices;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using ProTracking.Infrastructures.Repository;
using System.Linq.Expressions;

namespace ProTracking.API.Services
{
    public class LabelService : ILabelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LabelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<bool> AddAsync(LabelDTO entity)
        {
            if (entity == null) return false;
            Label obj = _mapper.Map<Label>(entity);
            bool result = await _unitOfWork.LabelRepo.AddAsync(obj);
            return result;
        }

        public async Task<IEnumerable<Label>> GetAll(Expression<Func<Label, bool>>? filter = null, string[]? includeProperties = null)
        {
            var _data = await _unitOfWork.LabelRepo.GetAllAsync(filter, includeProperties);
            return _data;
        }

        public async Task<LabelDTO> GetById(int id)
        {
            Label? obj = await _unitOfWork.LabelRepo.GetByIdAsync(id);
            LabelDTO dto = _mapper.Map<LabelDTO>(obj);
            return dto;
        }

        public async Task<bool> SoftRemove(LabelDTO entity)
        {
            if (entity == null) return false;
            Label obj = _mapper.Map<Label>(entity);
            bool result = await _unitOfWork.LabelRepo.SoftRemoveAsync(obj);
            return result;
        }

        public async Task<bool> SoftRemoveByID(int entityId)
        {
            LabelDTO? obj = await GetById(entityId);
            if (obj != null)
            {
                await SoftRemove(obj);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(LabelDTO entity)
        {
            if (entity != null)
            {
                Label obj = _mapper.Map<Label>(entity);
                bool result = await _unitOfWork.LabelRepo.UpdateAsync(obj);
                return result;
            }
            return false;
        }

        public async Task<bool> UpdateRange(List<LabelDTO> entities)
        {
            if (entities != null)
            {
                List<Label> objs = _mapper.Map<List<Label>>(entities);
                return await _unitOfWork.LabelRepo.UpdateRangeAsync(objs);
            }
            return false;
        }
    }
}
