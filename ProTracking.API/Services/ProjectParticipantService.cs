using AutoMapper;
using ProTracking.API.Services.IServices;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using ProTracking.Infrastructures.Repository;
using System.Linq.Expressions;

namespace ProTracking.API.Services
{
    public class ProjectParticipantService : IProjectParticipantService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectParticipantService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<bool> AddAsync(ProjectParticipantDTO entity)
        {
            if (entity == null) return false;
            Customer customer = _unitOfWork.CustomerRepo.GetById(entity.CustomerId);
            Project project = _unitOfWork.ProjectRepo.GetById(entity.ProjectId);
            if(customer == null || project == null) return false;
            entity.IsLeader = false;
            ProjectParticipant obj = _mapper.Map<ProjectParticipant>(entity);
            bool result = await _unitOfWork.ProjectParticipantRepo.AddAsync(obj);
            return result;
        }

        public async Task<IEnumerable<ProjectParticipant>> GetAll(Expression<Func<ProjectParticipant, bool>>? filter = null, string[]? includeProperties = null)
        {
            var _data = await _unitOfWork.ProjectParticipantRepo.GetAllAsync(filter, includeProperties);
            return _data;
        }

        public async Task<ProjectParticipantDTO> GetById(int id)
        {
            ProjectParticipant? obj = await _unitOfWork.ProjectParticipantRepo.GetByIdAsync(id);
            ProjectParticipantDTO dto = _mapper.Map<ProjectParticipantDTO>(obj);
            return dto;
        }

        public async Task<bool> SoftRemove(ProjectParticipantDTO entity)
        {
            if (entity == null) return false;
            ProjectParticipant obj = _mapper.Map<ProjectParticipant>(entity);
            bool result = await _unitOfWork.ProjectParticipantRepo.SoftRemoveAsync(obj);
            return result;

        }

        public async Task<bool> SoftRemoveByID(int entityId)
        {
            ProjectParticipantDTO? obj = await GetById(entityId);
            if (obj != null)
            {
                await SoftRemove(obj);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(ProjectParticipantDTO entity)
        {
            if (entity != null)
            {
                ProjectParticipant obj = _mapper.Map<ProjectParticipant>(entity);
                bool result = await _unitOfWork.ProjectParticipantRepo.UpdateAsync(obj);
                return result;
            }
            return false;
        }

        public async Task<bool> UpdateRange(List<ProjectParticipantDTO> entities)
        {
            if (entities != null)
            {
                List<ProjectParticipant> objs = _mapper.Map<List<ProjectParticipant>>(entities);
                return await _unitOfWork.ProjectParticipantRepo.UpdateRangeAsync(objs);
            }
            return false;
        }
    }
}
