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
    public class TransactionHistoryRepo : ITransactionHistoryRepo
    {
        private ApplicationDbContext db;

        public TransactionHistoryRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Task<bool> AddAsync(TransactionHistory entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionHistory>> GetAllAsync(Expression<Func<TransactionHistory, bool>>? filter = null, string[]? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionHistory> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftRemoveAsync(TransactionHistory entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(TransactionHistory entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRangeAsync(List<TransactionHistory> entities)
        {
            throw new NotImplementedException();
        }
    }
}
