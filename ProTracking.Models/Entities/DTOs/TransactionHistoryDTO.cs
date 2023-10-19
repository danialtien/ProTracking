using ProTracking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Domain.Entities.DTOs
{
    public class TransactionHistoryDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AccountTypeId { get; set; }
        public int PaymentId { get; set; }
        public string? Content { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime StartDate { get; set; }
        public double Amount { get; set; }
    }
}
