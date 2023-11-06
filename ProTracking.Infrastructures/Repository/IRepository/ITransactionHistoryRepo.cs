using ProTracking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Infrastructures.Repository
{
    public interface ITransactionHistoryRepo : IGenericRepository<TransactionHistory>
    {
        TransactionHistory GetByCustomerIdAndActive(int CustomerId, bool isActive);
        Task<IEnumerable<TransactionHistory>> GetByUserId(int id);
        Task<TransactionHistory> GetById(int id);
    }
}
