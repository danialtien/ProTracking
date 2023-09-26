﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Infrastructures.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        Task<bool> AddAsync(T entity);
        bool Update(T entity);
        bool UpdateRange(List<T> entities);
        bool SoftRemove(T entity);
        bool SoftRemoveByID(int entityId);
    }

}
