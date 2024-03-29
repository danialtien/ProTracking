﻿using Microsoft.EntityFrameworkCore;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using ProTracking.Infrastructures.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Infrastructures.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        private ApplicationDbContext db;

        public CustomerRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(Customer entity)
        {
            await db.Customers.AddAsync(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(Expression<Func<Customer, bool>>? filter = null, string[]? includeProperties = null)
        {
            if (includeProperties != null && filter != null)
            {
                return await includeProperties!.Aggregate(db.Customers.AsQueryable(),
                    (entity, property) => entity.Include(property))
                    .Where(filter!)
                    .ToListAsync();
            }
            return await db.Customers.ToListAsync();
        }

        public Customer GetById(int? id)
        {
            return db.Customers.FirstOrDefault(c => c.Id == id);
        }

        public Customer? GetUserLogin(LoginDTO login)
        {
            return db.Customers.FirstOrDefault(c => c.Email == login.Email && c.Password == login.Password);
        }

        public async Task<Customer?> GetByIdAsync(int id)
        {
            var result = await db.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            db.Entry(result!).State = EntityState.Detached;
            return result;
        }

        public async Task<bool> SoftRemoveAsync(Customer entity)
        {
            entity.Status = "Inactive";
            db.Customers.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public Customer? GetLast()
        {
            return db.Customers.LastOrDefault();
        }


        public async Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            Customer? result = await db.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
            if (result != null)
            {
                await SoftRemoveAsync(result);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(Customer entity)
        {
            db.Customers.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRangeAsync(List<Customer> entities)
        {
            db.Customers.UpdateRange(entities);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return await db.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }

        public async Task<bool> UpdateCutomerAndAccountTypeAsync(int customerId, int accountTypeId)
        {
            Customer? result = await db.Customers.FirstOrDefaultAsync(x => x.Id == customerId);
            if(result != null)
            {
                result.AccountTypeId = accountTypeId;
                return await db.SaveChangesAsync() > 0;
            }
            return false;
        }
    }
}
