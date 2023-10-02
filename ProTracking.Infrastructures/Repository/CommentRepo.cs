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

        public Task<IEnumerable<Comment>> GetAllAsync(Expression<Func<Comment, bool>>? filter = null, string[]? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<Comment> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftRemoveAsync(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRangeAsync(List<Comment> entities)
        {
            throw new NotImplementedException();
        }
    }
}
