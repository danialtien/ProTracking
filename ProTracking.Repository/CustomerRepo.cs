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
    public class CustomerRepo : ICustomerRepo
    {
        private ApplicationDbContext db;

        public CustomerRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Get(Expression<Func<Customer, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll(Expression<Func<Customer, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Customer> entity)
        {
            throw new NotImplementedException();
        }

        public void update(Customer obj)
        {
            throw new NotImplementedException();
        }
    }
}
