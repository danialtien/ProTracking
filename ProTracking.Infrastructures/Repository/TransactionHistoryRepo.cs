﻿using ProTracking.Domain.Entities;
using ProTracking.Infrastructures.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Infrastructures.Repository
{
    public class TransactionHistoryRepo : ITransactionHistoryRepo
    {
        private ApplicationDbContext db;

        public TransactionHistoryRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public Task<bool> AddAsync(TransactionHistory entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TransactionHistory>> GetAll(Expression<Func<TransactionHistory, bool>>? filter = null, string? includeProperties = null)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionHistory> GetByIdAsync(Expression<Func<TransactionHistory, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemove(TransactionHistory entity)
        {
            throw new NotImplementedException();
        }

        public bool SoftRemoveByID(int entityId)
        {
            throw new NotImplementedException();
        }

        public bool Update(TransactionHistory entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRange(List<TransactionHistory> entities)
        {
            throw new NotImplementedException();
        }
    }
}