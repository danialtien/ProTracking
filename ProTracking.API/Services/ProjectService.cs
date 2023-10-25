using AutoMapper;
using ProTracking.API.Services.IServices;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using ProTracking.Infrastructures.Repository;
using System.Linq.Expressions;

namespace ProTracking.API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<bool> AddAsync(ProjectDTO entity)
        {
            if (entity == null) return false;
            Customer customer = _unitOfWork.CustomerRepo.GetById(entity.CreatedBy);
            if (customer == null) return false;
            Project obj = _mapper.Map<Project>(entity);
            bool result = await _unitOfWork.ProjectRepo.AddAsync(obj);
            if (result)
            {
                ProjectParticipant participant = new()
                {
                    ProjectId = obj.Id,
                    CustomerId = customer.Id,
                    Project = obj,
                    Customer = customer,
                    IsLeader = true
                };
                await _unitOfWork.ProjectParticipantRepo.AddAsync(participant);
            }
            return result;
        }

        public async Task<IEnumerable<Project>> GetAll(Expression<Func<Project, bool>>? filter = null, string[]? includeProperties = null)
        {
            var _data = await _unitOfWork.ProjectRepo.GetAllAsync(filter, includeProperties);
            return _data;
        }

        public async Task<ProjectDTO> GetById(int id)
        {
            if (id == 0) return null;
            Project obj = await _unitOfWork.ProjectRepo.GetByIdAsync(id);
            return _mapper.Map<ProjectDTO>(obj);
        }

        public async Task<bool> SoftRemove(ProjectDTO entity)
        {
            if (entity == null) return false;
            Project obj = _mapper.Map<Project>(entity);
            bool result = await _unitOfWork.ProjectRepo.SoftRemoveAsync(obj);
            return result;

        }

        public async Task<bool> SoftRemoveByID(int entityId)
        {
            ProjectDTO? obj = await GetById(entityId);
            if (obj != null)
            {
                await SoftRemove(obj);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(ProjectDTO entity)
        {
            if (entity != null)
            {
                if (_unitOfWork.CustomerRepo.GetById(entity.CreatedBy) == null) return false;
                Project obj = _mapper.Map<Project>(entity);
                bool result = await _unitOfWork.ProjectRepo.UpdateAsync(obj);
                return result;
            }
            return false;
        }

        public async Task<bool> UpdateRange(List<ProjectDTO> entities)
        {
            if (entities != null)
            {
                List<Project> objs = _mapper.Map<List<Project>>(entities);
                return await _unitOfWork.ProjectRepo.UpdateRangeAsync(objs);
            }
            return false;
        }
    }
}
