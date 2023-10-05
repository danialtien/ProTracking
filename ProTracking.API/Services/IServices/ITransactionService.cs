using ProTracking.Application.ViewModels;
using ProTracking.Application.ViewModels.FilterModel;
using ProTracking.Domain.Entities;
using System.Linq.Expressions;
using System.Transactions;

namespace ProTracking.API.Services.IServices
{
    public interface ITransactionService : IGenericService<TransactionHistory>
    {

    }
}
