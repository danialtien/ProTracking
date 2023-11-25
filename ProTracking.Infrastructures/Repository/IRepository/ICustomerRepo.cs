using ProTracking.Domain.Entities;
using ProTracking.Domain.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Infrastructures.Repository
{
    public interface ICustomerRepo : IGenericRepository<Customer>
    {
        Customer GetById(int? id);

        Customer? GetLast();

        Customer? GetUserLogin(LoginDTO login);
        Task<Customer> GetCustomerByEmailAsync(string email);
        Task<bool> UpdateCutomerAndAccountTypeAsync(int customerId, int accountTypeId);
    }
}
