using System.ComponentModel.DataAnnotations;

namespace ProTracking.Domain.Entities
{
    public class AccountType
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public int Index { get; set; }
    }
}
