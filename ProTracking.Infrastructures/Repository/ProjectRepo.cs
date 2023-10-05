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
    public class ProjectRepo : IProjectRepo
    {
        private ApplicationDbContext db;

        public ProjectRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Task<bool> AddAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Project>> GetAllAsync(Expression<Func<Project, bool>>? filter = null, string[]? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftRemoveAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Project entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRangeAsync(List<Project> entities)
        {
            throw new NotImplementedException();
        }
    }
}
