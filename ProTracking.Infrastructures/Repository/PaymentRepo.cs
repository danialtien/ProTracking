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
    public class PaymentRepo : IPaymentRepo
    {
        private ApplicationDbContext db;

        public PaymentRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(Payment entity)
        {
            Payment Payment = entity;
            await db.Payments.AddAsync(Payment);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync(Expression<Func<Payment, bool>>? filter = null, string[]? includeProperties = null)
        {
            if (includeProperties != null && filter != null)
            {
                return await includeProperties!
                    .Aggregate(db.Payments.AsQueryable(),
                    (entity, property) => entity.Include(property))
                    .Where(filter!)
                    .ToListAsync();
            }
            return await db.Payments.ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetByAccountTypeAsync(string accountType)
        {
            return await db.Payments.Where(c => c.AccessKey.ToLower() == accountType.ToLower()).ToListAsync();
        }

        public async Task<Payment?> GetByIdAsync(int id)
        {
            var result = await db.Payments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Payment> GetPaymentByAccountTypeAndPayment(string accountType, string payment)
        {
            return await db.Payments.Where(c => c.AccessKey.ToLower() == accountType.ToLower() && c.Title.ToLower() == payment.ToLower()).FirstOrDefaultAsync();
        }
    }
}
