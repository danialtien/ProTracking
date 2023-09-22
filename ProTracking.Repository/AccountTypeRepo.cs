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
    public class AccountTypeRepo : IAccountTypeRepo
    {
        private ApplicationDbContext db;

        public AccountTypeRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(AccountType entity)
        {
            throw new NotImplementedException();
        }

        public AccountType Get(Expression<Func<AccountType, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountType> GetAll(Expression<Func<AccountType, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(AccountType entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<AccountType> entity)
        {
            throw new NotImplementedException();
        }

        public void update(AccountType obj)
        {
            throw new NotImplementedException();
        }
    }
}
