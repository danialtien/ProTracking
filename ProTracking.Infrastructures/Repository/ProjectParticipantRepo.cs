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
    public class ProjectParticipantRepo : IProjectParticipantRepo
    {
        private ApplicationDbContext db;

        public ProjectParticipantRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Task<bool> AddAsync(ProjectParticipant entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProjectParticipant>> GetAll(Expression<Func<ProjectParticipant, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectParticipant> GetByIdAsync(Expression<Func<ProjectParticipant, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemove(ProjectParticipant entity)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemoveByID(int entityId)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProjectParticipant entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRange(List<ProjectParticipant> entities)
        {
            throw new NotImplementedException();
        }
    }
}
