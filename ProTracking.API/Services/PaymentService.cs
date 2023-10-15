using AutoMapper;
using ProTracking.API.Services.IServices;
using ProTracking.Application.ViewModels;
using ProTracking.Application.ViewModels.FilterModel;
using ProTracking.Domain.Entities;
using ProTracking.Infrastructures.Repository;
using System.Linq.Expressions;

namespace ProTracking.API.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> AddAsync(Payment entity)
        {
            if (entity == null) return false;
            bool result = await _unitOfWork.PaymentRepo.AddAsync(entity);
            return result;
        }

        public async Task<IEnumerable<Payment>> GetAll(Expression<Func<Payment, bool>>? filter = null, string[]? includeProperties = null)
        {
            var _data = await _unitOfWork.PaymentRepo.GetAllAsync(filter, includeProperties);
            return _data;
        }

        public async Task<Payment> GetById(int id)
        {
            Payment? payment = await _unitOfWork.PaymentRepo.GetByIdAsync(id);
            return payment;
        }

        //public Task<IEnumerable<Payment>> GetFilterAsync(PaymentFilteringModel entity)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> SoftRemove(Payment entity)
        {
            if (entity == null) return false;
            bool result = await _unitOfWork.PaymentRepo.SoftRemoveAsync(entity);
            return result;
        }

        public async Task<bool> SoftRemoveByID(int entityId)
        {
            Payment? payment = await GetById(entityId);
            if (payment != null)
            {
                await SoftRemove(payment);
            }
            return false;
        }

        public async Task<bool> UpdateAsync(Payment entity)
        {
            if (entity != null)
            {
                bool result = await _unitOfWork.PaymentRepo.UpdateAsync(entity);
                return result;
            }
            return false;
        }

        public async Task<bool> UpdateRange(List<Payment> entities)
        {
            if (entities != null)
            {
                return await _unitOfWork.PaymentRepo.UpdateRangeAsync(entities);
            }
            return false;
        }
    }
}
