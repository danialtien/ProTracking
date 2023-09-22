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
    public class ProjectRepo : IProjectRepo
    {
        private ApplicationDbContext db;

        public ProjectRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(Project entity)
        {
            throw new NotImplementedException();
        }

        public void Add(Comment entity)
        {
            throw new NotImplementedException();
        }

        public Project Get(Expression<Func<Project, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public Comment Get(Expression<Func<Comment, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetAll(Expression<Func<Project, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetAll(Expression<Func<Comment, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(Project entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Comment entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Project> entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Comment> entity)
        {
            throw new NotImplementedException();
        }

        public void update(Project obj)
        {
            throw new NotImplementedException();
        }

        public void update(Comment obj)
        {
            throw new NotImplementedException();
        }
    }
}
