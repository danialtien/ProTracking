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
    public class ChildTaskRepo : IChildTaskRepo
    {
        private ApplicationDbContext db;

        public ChildTaskRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(ChildTask entity)
        {
            throw new NotImplementedException();
        }

        public ChildTask Get(Expression<Func<ChildTask, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChildTask> GetAll(Expression<Func<ChildTask, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(ChildTask entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<ChildTask> entity)
        {
            throw new NotImplementedException();
        }

        public void update(ChildTask obj)
        {
            throw new NotImplementedException();
        }
    }
}
