using AutoMapper;
using ProTracking.API.Services.IServices;
using ProTracking.Application.ViewModels;
using ProTracking.Domain.Entities;
using ProTracking.Infrastructures.Repository;

namespace ProTracking.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo repo;
        private readonly IMapper mapper;

        public CustomerService(ICustomerRepo customerRepo, IMapper mapper)
        {
            this.repo = customerRepo;
            this.mapper = mapper;
        }
        public IEnumerable<CustomerRegisterDTO> GetAll()
        {
            IEnumerable<CustomerRegisterDTO> _response = new List<CustomerRegisterDTO>();
            var _data =  this.repo.GetAll();
            if(_data != null )
            {
                _response = this.mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerRegisterDTO>>((IEnumerable<Customer>)_data);
            }
            return _response;
        }
    }
}
