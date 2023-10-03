using ProTracking.Domain.Entities;
using ProTracking.Infrastructures.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Infrastructures.Repository
{
    public class PaymentRepo : IPaymentRepo
    {
        private ApplicationDbContext db;

        public PaymentRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Task<bool> AddAsync(Payment entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Payment>> GetAllAsync(Expression<Func<Payment, bool>>? filter = null, string[]? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftRemoveAsync(Payment entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Payment entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRangeAsync(List<Payment> entities)
        {
            throw new NotImplementedException();
        }
    }
}
