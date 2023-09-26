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
    public class CustomerRepo : ICustomerRepo
    {
        private ApplicationDbContext db;

        public CustomerRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Task<bool> AddAsync(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAll(Expression<Func<Customer, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByIdAsync(Expression<Func<Customer, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemove(Customer entity)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemoveByID(int entityId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRange(List<Customer> entities)
        {
            throw new NotImplementedException();
        }
    }
}
