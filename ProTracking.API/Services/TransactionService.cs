using AutoMapper;
using ProTracking.API.Services.IServices;
using ProTracking.Application.ViewModels;
using ProTracking.Application.ViewModels.FilterModel;
using ProTracking.Domain.Entities;
using ProTracking.Infrastructures.Repository;
using System.Linq.Expressions;

namespace ProTracking.API.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> AddAsync(TransactionHistory entity)
        {
            if (entity == null) return false;
            bool result = await _unitOfWork.TransactionHistoryRepo.AddAsync(entity);
            return result;
        }

        public async Task<IEnumerable<TransactionHistory>> GetAll(Expression<Func<TransactionHistory, bool>>? filter = null, string[]? includeProperties = null)
        {
            var _data = await _unitOfWork.TransactionHistoryRepo.GetAllAsync(filter, includeProperties);
            return _data;
        }

        public async Task<TransactionHistory> GetById(int id)
        {
            TransactionHistory? transaction = await _unitOfWork.TransactionHistoryRepo.GetByIdAsync(id);
            return transaction;
        }

        //public Task<IEnumerable<TransactionHistory>> GetFilterAsync(TransactionHistoryFilteringModel entity)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> SoftRemove(TransactionHistory entity)
        {
            if (entity == null) return false;
            bool result = await _unitOfWork.TransactionHistoryRepo.SoftRemoveAsync(entity);
            return result;
        }

        public async Task<bool> SoftRemoveByID(int entityId)
        {
            TransactionHistory? transaction = await GetById(entityId);
            if (transaction != null)
            {
                await SoftRemove(transaction);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(TransactionHistory entity)
        {
            if (entity != null)
            {
                bool result = await _unitOfWork.TransactionHistoryRepo.UpdateAsync(entity);
                return result;
            }
            return false;
        }

        public async Task<bool> UpdateRange(List<TransactionHistory> entities)
        {
            if (entities != null)
            {
                return await _unitOfWork.TransactionHistoryRepo.UpdateRangeAsync(entities);
            }
            return false;
        }
    }
}
