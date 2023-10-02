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

        public Task<IEnumerable<ProjectParticipant>> GetAllAsync(Expression<Func<ProjectParticipant, bool>>? filter = null, string[]? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectParticipant> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftRemoveAsync(ProjectParticipant entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(ProjectParticipant entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRangeAsync(List<ProjectParticipant> entities)
        {
            throw new NotImplementedException();
        }
    }
}
