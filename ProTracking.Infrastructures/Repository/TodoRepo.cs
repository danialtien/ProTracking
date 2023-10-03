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
    public class TodoRepo : ITodoRepo
    {
        private ApplicationDbContext db;

        public TodoRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Task<bool> AddAsync(Todo entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Todo>> GetAllAsync(Expression<Func<Todo, bool>>? filter = null, string[]? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<Todo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftRemoveAsync(Todo entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Todo entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRangeAsync(List<Todo> entities)
        {
            throw new NotImplementedException();
        }
    }
}
