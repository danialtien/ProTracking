using ProTracking.Domain.Entities;
using ProTracking.Infrastructures.Data;
using ProTracking.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Repository
{
    public class PaymentRepo : IPaymentRepo
    {
        private ApplicationDbContext db;

        public PaymentRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(Payment entity)
        {
            throw new NotImplementedException();
        }

        public Payment Get(Expression<Func<Payment, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Payment> GetAll(Expression<Func<Payment, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(Payment entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Payment> entity)
        {
            throw new NotImplementedException();
        }

        public void update(Payment obj)
        {
            throw new NotImplementedException();
        }
    }
}
