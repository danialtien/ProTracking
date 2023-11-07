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
    public class TransactionHistoryRepo : ITransactionHistoryRepo
    {
        private ApplicationDbContext db;
        public TransactionHistoryRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> AddAsync(TransactionHistory entity)
        {
            TransactionHistory TransactionHistory = entity;
            TransactionHistory.Payment = await db.Payments.FirstOrDefaultAsync(c => c.Id == TransactionHistory.PaymentId);
            TransactionHistory.AccountType = await db.AccountTypes.FirstOrDefaultAsync(c => c.Id == TransactionHistory.AccountTypeId);
            TransactionHistory.Customer = await db.Customers.FirstOrDefaultAsync(c => c.Id == TransactionHistory.CustomerId);
            await db.TransactionHistory.AddAsync(TransactionHistory);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<TransactionHistory>> GetAllAsync(Expression<Func<TransactionHistory, bool>>? filter = null, string[]? includeProperties = null)
        {

            return await db.TransactionHistory
                        .Join(db.Payments,
                              transaction => transaction.PaymentId,
                              payment => payment.Id,
                              (transaction, payment) => new { Transaction = transaction, Payment = payment })
                        .Join(db.AccountTypes,
                              combined => combined.Transaction.AccountTypeId,
                              accountType => accountType.Id,
                              (combined, accountType) => new { combined.Transaction, combined.Payment, AccountType = accountType })
                        .Join(db.Customers,
                              combined => combined.Transaction.CustomerId,
                              customer => customer.Id,
                              (combined, customer) => new TransactionHistory
                              {
                                  Id = combined.Transaction.Id,
                                  CustomerId = combined.Transaction.CustomerId,
                                  AccountTypeId = combined.Transaction.AccountTypeId,
                                  PaymentId = combined.Transaction.PaymentId,
                                  Content = combined.Transaction.Content,
                                  PaymentDate = combined.Transaction.PaymentDate,
                                  StartDate = combined.Transaction.StartDate,
                                  EndDate = combined.Transaction.EndDate,
                                  IsActive = combined.Transaction.IsActive,
                                  Amount = combined.Transaction.Amount,
                                  IsBanking = combined.Transaction.IsBanking,
                                  Customer = customer,
                                  Payment = combined.Payment,
                                  AccountType = combined.AccountType
                              })
                        .OrderByDescending(x => x.IsBanking == false)
                        .OrderByDescending(x => x.PaymentDate)
                        .ToListAsync();
        }


        public TransactionHistory GetByCustomerIdAndActive(int CustomerId, bool isActive)
        {
            return db.TransactionHistory.Where(t => t.CustomerId == CustomerId && isActive).FirstOrDefault();
        }

        public async Task<TransactionHistory> GetById(int id)
        {
            return await db.TransactionHistory.Join(db.Payments,
                              transaction => transaction.PaymentId,
                              payment => payment.Id,
                              (transaction, payment) => new { Transaction = transaction, Payment = payment })
                        .Join(db.AccountTypes,
                              combined => combined.Transaction.AccountTypeId,
                              accountType => accountType.Id,
                              (combined, accountType) => new { combined.Transaction, combined.Payment, AccountType = accountType })
                        .Join(db.Customers,
                              combined => combined.Transaction.CustomerId,
                              customer => customer.Id,
                              (combined, customer) => new TransactionHistory
                              {
                                  Id = combined.Transaction.Id,
                                  CustomerId = combined.Transaction.CustomerId,
                                  AccountTypeId = combined.Transaction.AccountTypeId,
                                  PaymentId = combined.Transaction.PaymentId,
                                  Content = combined.Transaction.Content,
                                  PaymentDate = combined.Transaction.PaymentDate,
                                  StartDate = combined.Transaction.StartDate,
                                  EndDate = combined.Transaction.EndDate,
                                  IsActive = combined.Transaction.IsActive,
                                  Amount = combined.Transaction.Amount,
                                  IsBanking = combined.Transaction.IsBanking,
                                  Customer = customer,
                                  Payment = combined.Payment,
                                  AccountType = combined.AccountType
                              }).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<TransactionHistory?> GetByIdAsync(int id)
        {
            var result = await db.TransactionHistory.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<IEnumerable<TransactionHistory>> GetByUserId(int id)
        {
            return await db.TransactionHistory.Join(db.Payments,
                              transaction => transaction.PaymentId,
                              payment => payment.Id,
                              (transaction, payment) => new { Transaction = transaction, Payment = payment })
                        .Join(db.AccountTypes,
                              combined => combined.Transaction.AccountTypeId,
                              accountType => accountType.Id,
                              (combined, accountType) => new { combined.Transaction, combined.Payment, AccountType = accountType })
                        .Join(db.Customers,
                              combined => combined.Transaction.CustomerId,
                              customer => customer.Id,
                              (combined, customer) => new TransactionHistory
                              {
                                  Id = combined.Transaction.Id,
                                  CustomerId = combined.Transaction.CustomerId,
                                  AccountTypeId = combined.Transaction.AccountTypeId,
                                  PaymentId = combined.Transaction.PaymentId,
                                  Content = combined.Transaction.Content,
                                  PaymentDate = combined.Transaction.PaymentDate,
                                  StartDate = combined.Transaction.StartDate,
                                  EndDate = combined.Transaction.EndDate,
                                  IsActive = combined.Transaction.IsActive,
                                  Amount = combined.Transaction.Amount,
                                  IsBanking = combined.Transaction.IsBanking,
                                  Customer = customer,
                                  Payment = combined.Payment,
                                  AccountType = combined.AccountType
                              }).Where(c => c.CustomerId == id)
                              .OrderByDescending(x => x.IsBanking == false)
                              .OrderByDescending(x => x.PaymentDate).ToListAsync();
        }

        public async Task<bool> SoftRemoveAsync(TransactionHistory entity)
        {
            db.TransactionHistory.Remove(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> SoftRemoveByIDAsync(int entityId)
        {
            TransactionHistory? result = await db.TransactionHistory.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entityId);
            if (result != null)
            {
                await SoftRemoveAsync(result);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(TransactionHistory entity)
        {
            db.TransactionHistory.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRangeAsync(List<TransactionHistory> entities)
        {
            db.TransactionHistory.UpdateRange(entities);
            return await db.SaveChangesAsync() > 0;
        }
    }
}
