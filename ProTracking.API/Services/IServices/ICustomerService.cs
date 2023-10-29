using ProTracking.Application.ViewModels;
using ProTracking.Application.ViewModels.FilterModel;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using System.Linq.Expressions;

namespace ProTracking.API.Services.IServices
{
    public interface ICustomerService : IGenericService<Customer>
    {
        string checkLogin(LoginDTO login);
        Task<MessageHandler> RegisterAccount(RegisterDTO registerDTO);
        Task<IEnumerable<Customer>> GetFilterAsync(CustomerFilteringModel entity);
        Task<Customer> GetCustomerByEmailAsync(string email);

    }
}
