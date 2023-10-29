using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using ProTracking.API.Services.IServices;
using ProTracking.Application.ViewModels;
using ProTracking.Application.ViewModels.FilterModel;
using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using ProTracking.Domain.Enums;
using ProTracking.Infrastructures.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace ProTracking.API.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper mapper;
        private readonly IConfiguration _config;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            this.mapper = mapper;
            _config = config;
        }

        public async Task<bool> AddAsync(Customer entity)
        {
            if (entity == null) return false;
            if (entity.AccountTypeId > 4 && entity.AccountTypeId < 1) return false;
            entity.AccountType = await _unitOfWork.AccountTypeRepo.GetByIdAsync(entity.AccountTypeId);
            bool result = await _unitOfWork.CustomerRepo.AddAsync(entity);
            Customer customer = _unitOfWork.CustomerRepo.GetLast();

            if (result && customer != null)
            {
                await _unitOfWork.TransactionHistoryRepo.AddAsync(new TransactionHistory
                {
                    CustomerId = customer.Id,
                    AccountTypeId = 1,
                    PaymentId = 1,
                    Content = "Free",
                    PaymentDate = DateTime.Now,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(3),
                    Amount = 0,
                });
            }
            return result;
        }

        public async Task<MessageHandler> RegisterAccount(RegisterDTO entity)
        {
            if (entity == null) return new MessageHandler
            {
                StatusCode = 403,
                Message = "Values can not be null"
            };
            if (entity.Password != entity.ConfirmPassword) new MessageHandler
            {
                StatusCode = 403,
                Message = "Password should be the same"
            };

            Customer customer = new()
            {
                Email = entity.Email,
                Password = entity.Password,
                Username = entity.Username,
                Phone = entity.Phone,
                RegisteredAt = DateTime.Now,
                Role = RoleEnum.Customer,
                Status = StringConstUtil.ACTIVE,
                AccountTypeId = 1,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3)
            };
            bool result = await _unitOfWork.CustomerRepo.AddAsync(customer);
            if (result)
            {
                return new MessageHandler
                {
                    StatusCode = 201,
                    Message = "Created Successfully"
                };
            }
            return new MessageHandler
            {
                StatusCode = 403,
                Message = "Created Failure"
            };
        }


        public string checkLogin(LoginDTO login)
        {
            Customer customer = _unitOfWork.CustomerRepo.GetUserLogin(login);
            if (customer == null) return null;
            // Mapper Customer sang lop CustomerToken
            CustomerToken userToken = mapper.Map<CustomerToken>(customer);
            return GenerateTokenString(userToken);
        }

        public string GenerateTokenString(CustomerToken user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier , user.Username),
                new Claim(ClaimTypes.Email , user.Email),
                new Claim(ClaimTypes.Role , user.Role),
                new Claim("AccountType" , user.AccountType),
                new Claim("StartDate" , user.StartDate.ToString()),
                new Claim("EndDate" , user.EndDate.ToString())
            };

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                issuer: _config.GetSection("Jwt:Issuer").Value,
                audience: _config.GetSection("Jwt:Audience").Value,
                signingCredentials: credential
                );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return tokenString;
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

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return await _unitOfWork.CustomerRepo.GetCustomerByEmailAsync(email);
        }

    }
}
