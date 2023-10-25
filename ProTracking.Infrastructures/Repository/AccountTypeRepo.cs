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
    public class AccountTypeRepo :IAccountTypeRepo
    {
        private ApplicationDbContext db;
        public AccountTypeRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(AccountType entity)
        {
            AccountType AccountType = entity;
            /*AccountType.Project = await db.Projects.FirstOrDefaultAsync(c => c.Id == AccountType.ProjectId);
            AccountType.Label = await db.Labels.FirstOrDefaultAsync(c => c.Id == AccountType.LabelId);
            AccountType.Customer = await db.Customers.FirstOrDefaultAsync(c => c.Id == AccountType.CreatedBy);*/
            await db.AccountTypes.AddAsync(AccountType);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<AccountType>> GetAllAsync(Expression<Func<AccountType, bool>>? filter = null, string[]? includeProperties = null)
        {
            if (includeProperties != null && filter != null)
            {
                return await includeProperties!
                    .Aggregate(db.AccountTypes.AsQueryable(),
                    (entity, property) => entity.Include(property))
                    .Where(filter!)
                    .ToListAsync();
            }
            return await db.AccountTypes.ToListAsync();
        }

        public async Task<AccountType?> GetByIdAsync(int id)
        {
            var result = await db.AccountTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<bool> SoftRemoveAsync(AccountType entity)
        {
            db.AccountTypes.Remove(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            AccountType? result = await db.AccountTypes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
            if (result != null)
            {
                await SoftRemoveAsync(result);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(AccountType entity)
        {
            db.AccountTypes.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRangeAsync(List<AccountType> entities)
        {
            db.AccountTypes.UpdateRange(entities);
            return await db.SaveChangesAsync() > 0;
        }
    }
}
