using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> AddAsync(ProjectParticipant entity)
        {
            await db.ProjectParticipants.AddAsync(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ProjectParticipant>> GetAllAsync(Expression<Func<ProjectParticipant, bool>>? filter = null, string[]? includeProperties = null)
        {
            if (includeProperties != null && filter != null)
            {
                return await includeProperties!.Aggregate(db.ProjectParticipants.AsQueryable(),
                    (entity, property) => entity.Include(property))
                    .Where(filter!)
                    .ToListAsync();
            }
            return await db.ProjectParticipants.ToListAsync();
        }

        public async Task<ProjectParticipant> GetByIdAsync(int id)
        {
            var result = await db.ProjectParticipants.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<bool> SoftRemoveAsync(ProjectParticipant entity)
        {
            db.ProjectParticipants.Remove(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            ProjectParticipant? result = await db.ProjectParticipants.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
            if (result != null)
            {
                await SoftRemoveAsync(result);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(ProjectParticipant entity)
        {
            db.ProjectParticipants.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRangeAsync(List<ProjectParticipant> entities)
        {
            db.ProjectParticipants.UpdateRange(entities);
            return await db.SaveChangesAsync() > 0;
        }
    }
}
