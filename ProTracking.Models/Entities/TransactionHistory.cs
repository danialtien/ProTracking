using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Domain.Entities
{
    public class TransactionHistory
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AccountTypeId { get; set; }
        public int PaymentId { get; set; }
        public string? Content { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public DateTime StartDate { get; set; }

        public double Amount { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        [ForeignKey(nameof(PaymentId))]
        public Payment Payment { get; set; }
    }
}
