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
    public class ChildTaskRepo : IChildTaskRepo
    {
        private ApplicationDbContext db;

        public ChildTaskRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(ChildTask entity)
        {
            await db.ChildTasks.AddAsync(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<ChildTask>> GetAllAsync(Expression<Func<ChildTask, bool>>? filter = null, string[]? includeProperties = null)
        {
            if (includeProperties != null && filter != null)
            {
                return await includeProperties!.Aggregate(db.ChildTasks.AsQueryable(),
                    (entity, property) => entity.Include(property))
                    .Where(filter!)
                    .ToListAsync();
            }
            return await db.ChildTasks.ToListAsync();
        }

        public async Task<ChildTask?> GetByIdAsync(int id)
        {
            var result = await db.ChildTasks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<bool> SoftRemoveAsync(ChildTask entity)
        {
            db.ChildTasks.Remove(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            ChildTask? result = await db.ChildTasks.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
            if (result != null)
            {
                await SoftRemoveAsync(result);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(ChildTask entity)
        {
            db.ChildTasks.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRangeAsync(List<ChildTask> entities)
        {
            db.ChildTasks.UpdateRange(entities);
            return await db.SaveChangesAsync() > 0;
        }
    }
}
