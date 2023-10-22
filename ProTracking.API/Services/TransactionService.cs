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
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<bool> AddAsync(TransactionHistoryDTO entity)
        {
            // if(!_validation.CreateObjectIsValid(entity)) return false;
            TransactionHistory TransactionHistory = _mapper.Map<TransactionHistory>(entity);
            bool result = await _unitOfWork.TransactionHistoryRepo.AddAsync(TransactionHistory);
            return result;
        }

        public async Task<IEnumerable<TransactionHistory>> GetAll(Expression<Func<TransactionHistory, bool>>? filter = null, string[]? includeProperties = null)
        {
            var _data = (await _unitOfWork.TransactionHistoryRepo.GetAllAsync(filter, includeProperties)).Select(TransactionHistory => _mapper.Map<TransactionHistory>(TransactionHistory));
            return _data;
        }

        public async Task<TransactionHistoryDTO> GetById(int id)
        {
            if (id == 0) return null;
            TransactionHistory? obj = await _unitOfWork.TransactionHistoryRepo.GetByIdAsync(id);
            TransactionHistoryDTO TransactionHistoryDTO = _mapper.Map<TransactionHistoryDTO>(obj);
            return TransactionHistoryDTO;
        }

        public async Task<bool> SoftRemove(TransactionHistoryDTO entity)
        {
            if (entity == null) return false;
            TransactionHistory TransactionHistory = _mapper.Map<TransactionHistory>(entity);
            bool result = await _unitOfWork.TransactionHistoryRepo.SoftRemoveAsync(TransactionHistory);
            return result;

        }

        public async Task<bool> SoftRemoveByID(int entityId)
        {
            TransactionHistoryDTO? obj = await GetById(entityId);
            if (obj != null)
            {
                await SoftRemove(obj);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(TransactionHistoryDTO entity)
        {
            if (entity != null)
            {
                TransactionHistory TransactionHistory = _mapper.Map<TransactionHistory>(entity);
                bool result = await _unitOfWork.TransactionHistoryRepo.UpdateAsync(TransactionHistory);
                return result;
            }
            return false;
        }

        public async Task<bool> UpdateRange(List<TransactionHistoryDTO> entities)
        {
            if (entities != null)
            {
                List<TransactionHistory> TransactionHistory = _mapper.Map<List<TransactionHistory>>(entities);
                return await _unitOfWork.TransactionHistoryRepo.UpdateRangeAsync(TransactionHistory);
            }
            return false;
        }
    }
}
