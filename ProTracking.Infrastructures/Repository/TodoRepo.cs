using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProTracking.Domain.Entities;
using ProTracking.Infrastructures.Data;
using System.Linq.Expressions;

namespace ProTracking.Infrastructures.Repository
{
    public class TodoRepo : ITodoRepo
    {
        private ApplicationDbContext db;
        private IMapper _mapper;
        public TodoRepo(ApplicationDbContext db, IMapper mapper)
        {
            this.db = db;
            this._mapper = mapper;
        }

        public async Task<bool> AddAsync(Todo entity)
        {
            Todo todo = entity;
            /*todo.Project = await db.Projects.FirstOrDefaultAsync(c => c.Id == todo.ProjectId);
            todo.Label = await db.Labels.FirstOrDefaultAsync(c => c.Id == todo.LabelId);
            todo.Customer = await db.Customers.FirstOrDefaultAsync(c => c.Id == todo.CreatedBy);*/
            await db.Todos.AddAsync(todo);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Todo>> GetAllAsync(Expression<Func<Todo, bool>>? filter = null, string[]? includeProperties = null)
        {
            if (includeProperties != null && filter != null)
            {
                return await includeProperties!
                    .Aggregate(db.Todos.AsQueryable(),
                    (entity, property) => entity.Include(property))
                    .Where(filter!)
                    .ToListAsync();
            }
            return await db.Todos.ToListAsync();
        }

        public IEnumerable<Todo> GetAllByProjectId(int projectId)
        {
            return db.Todos.Where(t => t.ProjectId == projectId).ToList();
        }

        public async Task<Todo?> GetByIdAsync(int id)
        {
            var result = await db.Todos.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> SoftRemoveAsync(Todo entity)
        {
            db.Todos.Remove(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            Todo? result = await db.Todos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
            if (result != null)
            {
                await SoftRemoveAsync(result);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(Todo entity)
        {
            db.Todos.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRangeAsync(List<Todo> entities)
        {
            db.Todos.UpdateRange(entities);
            return await db.SaveChangesAsync() > 0;
        }

        private async Task<Todo> UpdateProjectForTodo(Todo entity)
        {
            if (entity != null)
            {
                if (entity.Project != null)
                {
                    if (entity.ProjectId != entity.Project.Id)
                    {
                        entity.Project = await db.Projects.FirstAsync(c => c.Id == entity.ProjectId);
                    }
                }
                else
                {
                    entity.Project = await db.Projects.FirstAsync(c => c.Id == entity.ProjectId);
                }
            }
            return entity;
        }
    }
}
