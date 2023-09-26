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
    public class ChildTaskRepo : IChildTaskRepo
    {
        private ApplicationDbContext db;

        public ChildTaskRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Task<bool> AddAsync(ChildTask entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ChildTask>> GetAll(Expression<Func<ChildTask, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<ChildTask> GetByIdAsync(Expression<Func<ChildTask, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemove(ChildTask entity)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemoveByID(int entityId)
        {
            throw new NotImplementedException();
        }

        public bool Update(ChildTask entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRange(List<ChildTask> entities)
        {
            throw new NotImplementedException();
        }
    }
}
