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
    public class TransactionHistoryRepo : ITransactionHistoryRepo
    {
        private ApplicationDbContext db;

        public TransactionHistoryRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(TransactionHistory entity)
        {
            throw new NotImplementedException();
        }

        public TransactionHistory Get(Expression<Func<TransactionHistory, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionHistory> GetAll(Expression<Func<TransactionHistory, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(TransactionHistory entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<TransactionHistory> entity)
        {
            throw new NotImplementedException();
        }

        public void update(TransactionHistory obj)
        {
            throw new NotImplementedException();
        }
    }
}
