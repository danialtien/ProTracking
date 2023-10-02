using AutoMapper;
using ProTracking.API.Services.IServices;
using ProTracking.Application.ViewModels;
using ProTracking.Application.ViewModels.FilterModel;
using ProTracking.Domain.Entities;
using ProTracking.Infrastructures.Repository;
using System.Linq.Expressions;

namespace ProTracking.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> AddAsync(Customer entity)
        {
            if (entity == null) return false;
            if (entity.AccountTypeId > 4 && entity.AccountTypeId < 1) return false;
            entity.AccountType = await _unitOfWork.AccountTypeRepo.GetByIdAsync(entity.AccountTypeId);
            bool result = await _unitOfWork.CustomerRepo.AddAsync(entity);
            return result;
        }

        public async Task<IEnumerable<Customer>> GetAll(Expression<Func<Customer, bool>>? filter = null, string[]? includeProperties = null)
        {
            var _data = await _unitOfWork.CustomerRepo.GetAllAsync(filter, includeProperties);
            return _data;
        }

        public async Task<Customer> GetById(int id)
        {
            Customer? customer = await _unitOfWork.CustomerRepo.GetByIdAsync(id);
            return customer;
        }

        public Task<IEnumerable<Customer>> GetFilterAsync(CustomerFilteringModel entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SoftRemove(Customer entity)
        {
            if (entity == null) return false;
            bool result = await _unitOfWork.CustomerRepo.SoftRemoveAsync(entity);
            return result;
        }

        public async Task<bool> SoftRemoveByID(int entityId)
        {
            Customer? customer = await GetById(entityId);
            if (customer != null)
            {
                await SoftRemove(customer);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(Customer entity)
        {
            if (entity != null)
            {
                if (entity.AccountTypeId > 4 && entity.AccountTypeId < 1) return false;
                entity.AccountType = await _unitOfWork.AccountTypeRepo.GetByIdAsync(entity.AccountTypeId);
                bool result = await _unitOfWork.CustomerRepo.UpdateAsync(entity);
                return result;
            }
            return false;
        }

        public async Task<bool> UpdateRange(List<Customer> entities)
        {
            if (entities != null)
            {
                return await _unitOfWork.CustomerRepo.UpdateRangeAsync(entities);
            }
            return false;
        }
    }
}
