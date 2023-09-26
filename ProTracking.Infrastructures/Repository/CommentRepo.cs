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
    public class CommentRepo : ICommentRepo
    {
        private ApplicationDbContext db;

        public CommentRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Task<bool> AddAsync(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Comment>> GetAll(Expression<Func<Comment, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetByIdAsync(Expression<Func<Comment, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemove(Comment entity)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemoveByID(int entityId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Comment entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRange(List<Comment> entities)
        {
            throw new NotImplementedException();
        }
    }
}
