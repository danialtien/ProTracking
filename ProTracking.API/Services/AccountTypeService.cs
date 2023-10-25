using AutoMapper;
using ProTracking.API.Services.IServices;
using ProTracking.Application.ViewModels;
using ProTracking.Application.ViewModels.FilterModel;
using ProTracking.Domain.Entities;
using ProTracking.Infrastructures.Repository;
using System.Linq.Expressions;

namespace ProTracking.API.Services
{
    public class AccountTypeService : IAccountTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public AccountTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> AddAsync(AccountType entity)
        {
            if (entity == null) return false;
            bool result = await _unitOfWork.AccountTypeRepo.AddAsync(entity);
            return result;
        }

        public async Task<IEnumerable<AccountType>> GetAll(Expression<Func<AccountType, bool>>? filter = null, string[]? includeProperties = null)
        {
            var _data = await _unitOfWork.AccountTypeRepo.GetAllAsync(filter, includeProperties);
            return _data;
        }

        public async Task<AccountType> GetById(int id)
        {
            AccountType? accountType = await _unitOfWork.AccountTypeRepo.GetByIdAsync(id);
            return accountType;
        }


        public async Task<bool> SoftRemove(AccountType entity)
        {
            if (entity == null) return false;
            bool result = await _unitOfWork.AccountTypeRepo.SoftRemoveAsync(entity);
            return result;
        }

        public async Task<bool> SoftRemoveByID(int entityId)
        {
            AccountType? accountType = await GetById(entityId);
            if (accountType != null)
            {
                await SoftRemove(accountType);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(AccountType entity)
        {
            if (entity != null)
            {
                bool result = await _unitOfWork.AccountTypeRepo.UpdateAsync(entity);
                return result;
            }
            return false;
        }

        public async Task<bool> UpdateRange(List<AccountType> entities)
        {
            if (entities != null)
            {
                return await _unitOfWork.AccountTypeRepo.UpdateRangeAsync(entities);
            }
            return false;
        }
    }
}
