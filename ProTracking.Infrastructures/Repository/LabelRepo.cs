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
    public class LabelRepo : ILabelRepo
    {
        private ApplicationDbContext db;

        public LabelRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(Label entity)
        {
            await db.Labels.AddAsync(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Label>> GetAllAsync(Expression<Func<Label, bool>>? filter = null, string[]? includeProperties = null)
        {
            if (includeProperties != null && filter != null)
            {
                return await includeProperties!.Aggregate(db.Labels.AsQueryable(),
                    (entity, property) => entity.Include(property))
                    .Where(filter!)
                    .ToListAsync();
            }
            return await db.Labels.ToListAsync();
        }

        public Label GetById(int id)
        {
            return db.Labels.FirstOrDefault(c => c.Id == id);
        }

        public async Task<Label?> GetByIdAsync(int id)
        {
            var result = await db.Labels.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<bool> SoftRemoveAsync(Label entity)
        {
            db.Labels.Remove(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            Label? result = await db.Labels.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
            if (result != null)
            {
                await SoftRemoveAsync(result);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(Label entity)
        {
            db.Labels.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRangeAsync(List<Label> entities)
        {
            db.Labels.UpdateRange(entities);
            return await db.SaveChangesAsync() > 0;
        }
    }
}
