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
    public class ProjectRepo : IProjectRepo
    {
        private ApplicationDbContext db;

        public ProjectRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(Project entity)
        {
            await db.Projects.AddAsync(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Project>> GetAllAsync(Expression<Func<Project, bool>>? filter = null, string[]? includeProperties = null)
        {
            if (includeProperties != null && filter != null)
            {
                return await includeProperties!.Aggregate(db.Projects.AsQueryable(),
                    (entity, property) => entity.Include(property))
                    .Where(filter!)
                    .ToListAsync();
            }
            return await db.Projects.ToListAsync();
        }

        public async Task<IEnumerable<Project>> GetAllProjectByCreator(int createdBy)
        {
            return await db.Projects.Where(c => c.CreatedBy == createdBy).ToListAsync();
        }

        public Project GetById(int id)
        {
            return db.Projects.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Project> GetByIdAsync(int id)
        {
            var result = await db.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<bool> SoftRemoveAsync(Project entity)
        {
            entity.Status = "Inactive";
            db.Projects.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            Project? result = await db.Projects.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
            if (result != null)
            {
                await SoftRemoveAsync(result);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(Project entity)
        {
            db.Projects.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRangeAsync(List<Project> entities)
        {
            db.Projects.UpdateRange(entities);
            return await db.SaveChangesAsync() > 0;
        }
    }
}
