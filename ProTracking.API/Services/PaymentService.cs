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

        public async Task<IEnumerable<Payment>> GetPaymentByAccountType(string accountType)
        {
            return await _unitOfWork.PaymentRepo.GetByAccountTypeAsync(accountType);
        }

        public async Task<Payment> GetPaymentByAccountTypeAndPayment(string accountType, string payment)
        {
            return await _unitOfWork.PaymentRepo.GetPaymentByAccountTypeAndPayment(accountType, payment);
        }
    }
}
