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
        private readonly ApplicationDbContext _dbContext;

        public AccountTypeRepo(ApplicationDbContext db)
        {
            this._dbContext = db;
        }

        public Task<bool> AddAsync(AccountType entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AccountType>> GetAllAsync(Expression<Func<AccountType, bool>>? filter = null, string[]? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountType> GetByIdAsync(int id)
        {
            return await _dbContext.AccountTypes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> SoftRemoveAsync(AccountType entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(AccountType entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRangeAsync(List<AccountType> entities)
        {
            throw new NotImplementedException();
        }
    }
}
