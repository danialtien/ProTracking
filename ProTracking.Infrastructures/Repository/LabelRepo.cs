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

        public Task<bool> AddAsync(Label entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Label>> GetAll(Expression<Func<Label, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<Label> GetByIdAsync(Expression<Func<Label, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemove(Label entity)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemoveByID(int entityId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Label entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRange(List<Label> entities)
        {
            throw new NotImplementedException();
        }
    }
}
