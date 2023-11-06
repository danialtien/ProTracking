using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> AddAsync(TransactionHistory entity)
        {
            TransactionHistory TransactionHistory = entity;
            /*TransactionHistory.Project = await db.Projects.FirstOrDefaultAsync(c => c.Id == TransactionHistory.ProjectId);
            TransactionHistory.Label = await db.Labels.FirstOrDefaultAsync(c => c.Id == TransactionHistory.LabelId);
            TransactionHistory.Customer = await db.Customers.FirstOrDefaultAsync(c => c.Id == TransactionHistory.CreatedBy);*/
            await db.TransactionHistory.AddAsync(TransactionHistory);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<TransactionHistory>> GetAllAsync(Expression<Func<TransactionHistory, bool>>? filter = null, string[]? includeProperties = null)
        {
            if (includeProperties != null && filter != null)
            {
                return await includeProperties!
                    .Aggregate(db.TransactionHistory.AsQueryable(),
                    (entity, property) => entity.Include(property))
                    .Where(filter!)
                    .ToListAsync();
            }
            return await db.TransactionHistory.ToListAsync();
        }

        public IEnumerable<TransactionHistory> GetAllByCustomerId(int customerId)
        {
            return db.TransactionHistory.Where(t => t.CustomerId == customerId).ToList();
        }

        public TransactionHistory GetByCustomerIdAndActive(int CustomerId, bool isActive)
        {
            return db.TransactionHistory.Where(t => t.CustomerId == CustomerId && isActive).FirstOrDefault();
        }

        public Task<TransactionHistory> GetById(int id)
        {
            return db.TransactionHistory.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TransactionHistory?> GetByIdAsync(int id)
        {
            var result = await db.TransactionHistory.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<IEnumerable<TransactionHistory>> GetByUserId(int id)
        {
            return await db.TransactionHistory.Where( c=> c.CustomerId == id).OrderByDescending(c => c.PaymentDate).ToListAsync();
        }

        public async Task<bool> SoftRemoveAsync(TransactionHistory entity)
        {
            db.TransactionHistory.Remove(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            TransactionHistory? result = await db.TransactionHistory.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
            if (result != null)
            {
                await SoftRemoveAsync(result);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(TransactionHistory entity)
        {
            db.TransactionHistory.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRangeAsync(List<TransactionHistory> entities)
        {
            db.TransactionHistory.UpdateRange(entities);
            return await db.SaveChangesAsync() > 0;
        }
    }
}
