﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProTracking.API.Services.IServices;
using ProTracking.Application.ViewModels;
using ProTracking.Application.ViewModels.FilterModel;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using ProTracking.Infrastructures.Repository;
using System.Linq.Expressions;

namespace ProTracking.API.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<bool> AddAsync(TransactionHistoryDTO entity)
        {
            // if(!_validation.CreateObjectIsValid(entity)) return false;
            TransactionHistory TransactionHistory = _mapper.Map<TransactionHistory>(entity);
            bool result = await _unitOfWork.TransactionHistoryRepo.AddAsync(TransactionHistory);
            return result;
        }

        public async Task<IEnumerable<TransactionHistory>> GetAll(Expression<Func<TransactionHistory, bool>>? filter = null, string[]? includeProperties = null)
        {
            var _data = (await _unitOfWork.TransactionHistoryRepo.GetAllAsync(filter, includeProperties)).Select(TransactionHistory => _mapper.Map<TransactionHistory>(TransactionHistory));
            return _data;
        }

        public async Task<IEnumerable<TransactionHistory>> GetByUserId(int id)
        {
            if (id == 0) return null;
            IEnumerable<TransactionHistory> obj = await _unitOfWork.TransactionHistoryRepo.GetByUserId(id);
            return obj;
        }

        public async Task<bool> SoftRemove(TransactionHistoryDTO entity)
        {
            if (entity == null) return false;
            TransactionHistory TransactionHistory = _mapper.Map<TransactionHistory>(entity);
            bool result = await _unitOfWork.TransactionHistoryRepo.SoftRemoveAsync(TransactionHistory);
            return result;

        }


        public async Task<bool> UpdateAsync(TransactionHistoryDTO entity)
        {
            if (entity != null)
            {
                TransactionHistory TransactionHistory = _mapper.Map<TransactionHistory>(entity);
                bool result = await _unitOfWork.TransactionHistoryRepo.UpdateAsync(TransactionHistory);
                return result;
            }
            return false;
        }

        public async Task<bool> UpdateForAdminOnlyAsync(int transactionId, bool isBanking)
        {
            var entity = await GetById(transactionId);
            if (entity != null)
            {
                if (entity.IsBanking)
                {
                    return true;
                }
                if (isBanking)
                {
                    entity.IsBanking = isBanking;
                    entity.PaymentDate = DateTime.Now;
                    entity.IsActive = true;
                    entity.StartDate = DateTime.Now;
                    entity.EndDate = DateTime.Now.AddDays(30);
                    /*Customer customer = await _unitOfWork.CustomerRepo.GetByIdAsync(entity.CustomerId);
                    customer.AccountTypeId = entity.AccountTypeId;*/
                    var result1 = await _unitOfWork.TransactionHistoryRepo.UpdateAsync(entity);
                    var result2 = await _unitOfWork.CustomerRepo.UpdateCutomerAndAccountTypeAsync(entity.CustomerId, entity.AccountTypeId);
                    return result1 && result2;
                } else
                {
                    return false;
                }
            }
            return false;
        }

        public async Task<bool> UpdateRange(List<TransactionHistoryDTO> entities)
        {
            if (entities != null)
            {
                List<TransactionHistory> TransactionHistory = _mapper.Map<List<TransactionHistory>>(entities);
                return await _unitOfWork.TransactionHistoryRepo.UpdateRangeAsync(TransactionHistory);
            }
            return false;
        }

        public string GeneratePictureUrl(TransactionHistoryDTO entity)
        {
            // Replace the ID in the URL with the actual file ID from your Google Drive link
            string fileID = "1jiHspsf70p00gZIe7tpedr-y1w1QHfqX";

            // Construct the URL using the file ID
            string pictureUrl = "https://drive.google.com/uc?id=" + fileID;
            return pictureUrl;
        }

        public async Task<TransactionHistory> GetById(int id)
        {
            if (id == 0) return null;
            TransactionHistory obj = await _unitOfWork.TransactionHistoryRepo.GetById(id);
            return obj;
        }
    }
}
