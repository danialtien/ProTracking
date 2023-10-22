using ProTracking.Application.ViewModels;
using ProTracking.Application.ViewModels.FilterModel;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using System.Linq.Expressions;

namespace ProTracking.API.Services.IServices
{
    public interface IPaymentService 
    {
        Task<bool> AddAsync(Payment entity);
        Task<IEnumerable<Payment>> GetAll(Expression<Func<Payment, bool>>? filter = null, string[]? includeProperties = null);
        Task<Payment> GetById(int id);
        /*Task<bool> UpdateAsync(Payment entity);
        Task<bool> UpdateRange(List<Payment> entities);*/
    }
}
