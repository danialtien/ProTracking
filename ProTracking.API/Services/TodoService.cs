using AutoMapper;
using ProTracking.API.Services.IServices;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using ProTracking.Infrastructures.Repository;
using System.Linq.Expressions;

namespace ProTracking.API.Services
{
    public class TodoService : ITodoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TodoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<bool> AddAsync(TodoDTO entity)
        {
            if (entity == null) return false;
            Todo todo = _mapper.Map<Todo>(entity);
            bool result = await _unitOfWork.TodoRepo.AddAsync(todo);
            return result;
        }

        public async Task<IEnumerable<Todo>> GetAll(Expression<Func<Todo, bool>>? filter = null, string[]? includeProperties = null)
        {
            var _data = (await _unitOfWork.TodoRepo.GetAllAsync(filter, includeProperties)).Select(todo => _mapper.Map<Todo>(todo));
            return _data;
        }

        public async Task<TodoDTO> GetById(int id)
        {
            Todo? obj = await _unitOfWork.TodoRepo.GetByIdAsync(id);
            TodoDTO todoDTO = _mapper.Map<TodoDTO>(obj);
            return todoDTO;
        }

        public async Task<bool> SoftRemove(TodoDTO entity)
        {
            if (entity == null) return false;
            Todo todo = _mapper.Map<Todo>(entity);
            bool result = await _unitOfWork.TodoRepo.SoftRemoveAsync(todo);
            return result;

        }

        public async Task<bool> SoftRemoveByID(int entityId)
        {
            TodoDTO? obj = await GetById(entityId);
            if (obj != null)
            {
                await SoftRemove(obj);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(TodoDTO entity)
        {
            if (entity != null)
            {
                Todo todo = _mapper.Map<Todo>(entity);
                bool result = await _unitOfWork.TodoRepo.UpdateAsync(todo);
                return result;
            }
            return false;
        }

        public async Task<bool> UpdateRange(List<TodoDTO> entities)
        {
            if (entities != null)
            {
                List<Todo> todo = _mapper.Map<List<Todo>>(entities);
                return await _unitOfWork.TodoRepo.UpdateRangeAsync(todo);
            }
            return false;
        }
    }
}
