using ProTracking.Application.ViewModels;
using ProTracking.Application.ViewModels.FilterModel;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using System.Linq.Expressions;
using System.Transactions;

namespace ProTracking.API.Services.IServices
{
    public interface ITransactionService
    {
        Task<bool> AddAsync(TransactionHistoryDTO entity);
        Task<IEnumerable<TransactionHistory>> GetAll(Expression<Func<TransactionHistory, bool>>? filter = null, string[]? includeProperties = null);
        Task<TransactionHistoryDTO> GetById(int id);
        Task<bool> SoftRemove(TransactionHistoryDTO entity);
        Task<bool> SoftRemoveByID(int entityId);
        Task<bool> UpdateAsync(TransactionHistoryDTO entity);
        Task<bool> UpdateRange(List<TransactionHistoryDTO> entities);
        public string GeneratePictureUrl(TransactionHistoryDTO entity);
    }
}
