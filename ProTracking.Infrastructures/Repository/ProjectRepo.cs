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

        public Task<IEnumerable<Project>> GetAll(Expression<Func<Project, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<Project> GetByIdAsync(Expression<Func<Project, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemove(Project entity)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemoveByID(int entityId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Project entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRange(List<Project> entities)
        {
            throw new NotImplementedException();
        }
    }
}
