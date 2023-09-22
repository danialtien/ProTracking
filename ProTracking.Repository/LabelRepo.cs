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
    public class LabelRepo : ILabelRepo
    {
        private ApplicationDbContext db;

        public LabelRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(Label entity)
        {
            throw new NotImplementedException();
        }

        public Label Get(Expression<Func<Label, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Label> GetAll(Expression<Func<Label, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(Label entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Label> entity)
        {
            throw new NotImplementedException();
        }

        public void update(Label obj)
        {
            throw new NotImplementedException();
        }
    }
}
