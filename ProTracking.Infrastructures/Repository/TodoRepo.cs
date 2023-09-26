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

        public Task<IEnumerable<Todo>> GetAll(Expression<Func<Todo, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<Todo> GetByIdAsync(Expression<Func<Todo, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemove(Todo entity)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemoveByID(int entityId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Todo entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRange(List<Todo> entities)
        {
            throw new NotImplementedException();
        }
    }
}
