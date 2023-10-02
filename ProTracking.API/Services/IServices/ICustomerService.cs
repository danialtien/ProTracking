using ProTracking.Application.ViewModels;
using ProTracking.Application.ViewModels.FilterModel;
using ProTracking.Domain.Entities;
using System.Linq.Expressions;

namespace ProTracking.API.Services.IServices
{
    public interface ICustomerService : IGenericService<Customer>
    {
        Task<IEnumerable<Customer>> GetFilterAsync(CustomerFilteringModel entity);
    }
}
