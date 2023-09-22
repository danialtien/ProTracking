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
    public class ProjectParticipantRepo : IProjectParticipantRepo
    {
        private ApplicationDbContext db;

        public ProjectParticipantRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(ProjectParticipant entity)
        {
            throw new NotImplementedException();
        }

        public ProjectParticipant Get(Expression<Func<ProjectParticipant, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectParticipant> GetAll(Expression<Func<ProjectParticipant, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(ProjectParticipant entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<ProjectParticipant> entity)
        {
            throw new NotImplementedException();
        }

        public void update(ProjectParticipant obj)
        {
            throw new NotImplementedException();
        }
    }
}
