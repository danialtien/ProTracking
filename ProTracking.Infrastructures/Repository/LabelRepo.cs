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

        public Task<IEnumerable<Label>> GetAllAsync(Expression<Func<Label, bool>>? filter = null, string[]? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<Label> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftRemoveAsync(Label entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Label entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRangeAsync(List<Label> entities)
        {
            throw new NotImplementedException();
        }
    }
}
