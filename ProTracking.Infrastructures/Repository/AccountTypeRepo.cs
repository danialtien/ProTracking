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
    public class AccountTypeRepo : IAccountTypeRepo
    {
        private ApplicationDbContext db;

        public AccountTypeRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Task<bool> AddAsync(AccountType entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AccountType>> GetAll(Expression<Func<AccountType, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<AccountType> GetByIdAsync(Expression<Func<AccountType, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemove(AccountType entity)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemoveByID(int entityId)
        {
            throw new NotImplementedException();
        }

        public bool Update(AccountType entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRange(List<AccountType> entities)
        {
            throw new NotImplementedException();
        }
    }
}
