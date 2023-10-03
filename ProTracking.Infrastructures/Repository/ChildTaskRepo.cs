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
        private ApplicationDbContext _dbContext;

        public ChildTaskRepo(ApplicationDbContext db)
        {
            this._dbContext = db;
        }

        public Task<bool> AddAsync(ChildTask entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ChildTask>> GetAllAsync(Expression<Func<ChildTask, bool>>? filter = null, string[]? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<ChildTask> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftRemoveAsync(ChildTask entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ChildTask entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRangeAsync(List<ChildTask> entities)
        {
            throw new NotImplementedException();
        }
    }
}
