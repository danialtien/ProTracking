using ProTracking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Domain.Entities.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string? Avatar { get; set; }
        public DateTime RegisteredAt { get; set; }
        public DateTime LastLoginAt { get; set; }
        public string? Status { get; set; }
        public RoleEnum? Role { get; set; }
        public string? GoogleId { get; set; }
        public string? GoogleEmail { get; set; }
        public string? OAuthToken { get; set; }
        public DateTime OAuthExpiry { get; set; }
        public int AccountTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
