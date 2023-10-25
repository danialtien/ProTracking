using AutoMapper;
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
    public class CommentRepo : ICommentRepo
    {
        private ApplicationDbContext db;
        public CommentRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(Comment entity)
        {
            Comment Comment = entity;
            /*Comment.Project = await db.Projects.FirstOrDefaultAsync(c => c.Id == Comment.ProjectId);
            Comment.Label = await db.Labels.FirstOrDefaultAsync(c => c.Id == Comment.LabelId);
            Comment.Customer = await db.Customers.FirstOrDefaultAsync(c => c.Id == Comment.CreatedBy);*/
            await db.Comments.AddAsync(Comment);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync(Expression<Func<Comment, bool>>? filter = null, string[]? includeProperties = null)
        {
            if (includeProperties != null && filter != null)
            {
                return await includeProperties!
                    .Aggregate(db.Comments.AsQueryable(),
                    (entity, property) => entity.Include(property))
                    .Where(filter!)
                    .ToListAsync();
            }
            return await db.Comments.ToListAsync();
        }

        public IEnumerable<Comment> GetAllByTodoId(int todoId)
        {
            return db.Comments.Where(t => t.TodoId == todoId).ToList();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            var result = await db.Comments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<bool> SoftRemoveAsync(Comment entity)
        {
            db.Comments.Remove(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            Comment? result = await db.Comments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
            if (result != null)
            {
                await SoftRemoveAsync(result);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(Comment entity)
        {
            db.Comments.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRangeAsync(List<Comment> entities)
        {
            db.Comments.UpdateRange(entities);
            return await db.SaveChangesAsync() > 0;
        }


        private async Task<Comment> UpdateTodoForComment(Comment entity)
        {
            if (entity != null)
            {
                if (entity.Todo != null)
                {
                    if (entity.TodoId != entity.Todo.Id)
                    {
                        entity.Todo = await db.Todos.FirstAsync(c => c.Id == entity.TodoId);
                    }
                }
                else
                {
                    entity.Todo = await db.Todos.FirstAsync(c => c.Id == entity.TodoId);
                }
            }
            return entity;
        }
    }
}
