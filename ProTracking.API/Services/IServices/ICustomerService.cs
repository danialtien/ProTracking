using ProTracking.Application.ViewModels;
using ProTracking.Domain.Entities;

namespace ProTracking.API.Services.IServices
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerRegisterDTO>> GetAllAsync();


    }
}
