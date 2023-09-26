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

        public Task<IEnumerable<Payment>> GetAll(Expression<Func<Payment, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<Payment> GetByIdAsync(Expression<Func<Payment, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemove(Payment entity)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemoveByID(int entityId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Payment entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRange(List<Payment> entities)
        {
            throw new NotImplementedException();
        }
    }
}
