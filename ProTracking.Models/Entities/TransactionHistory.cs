using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime PaymentDate { get; set; }
        public DateTime StartDate { get; set; }

        public double Amount { get; set; }

        [NotMapped]
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        [NotMapped]
        [ForeignKey(nameof(PaymentId))]
        public Payment Payment { get; set; }
    }
}
