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
    public class TodoRepo : ITodoRepo
    {
        private ApplicationDbContext db;

        public TodoRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(Todo entity)
        {
            throw new NotImplementedException();
        }

        public Todo Get(Expression<Func<Todo, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Todo> GetAll(Expression<Func<Todo, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(Todo entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Todo> entity)
        {
            throw new NotImplementedException();
        }

        public void update(Todo obj)
        {
            throw new NotImplementedException();
        }
    }
}
