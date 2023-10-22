using ProTracking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Infrastructures.Repository
{
    public interface IPaymentRepo
    {
        Task<IEnumerable<Payment>> GetAllAsync(Expression<Func<Payment, bool>>? filter = null, string[]? includeProperties = null);
        Task<Payment> GetByIdAsync(int id);
        Task<bool> AddAsync(Payment entity);
    }
}
