using ProTracking.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProTracking.Domain.Entities
{
    public class ChildTask
    {
        [Key]
        public int Id { get; set; }
        public int TodoId { get; set; }
        public int? CreatedBy { get; set; }
        public string? Title { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public PriorityEnum? Priority { get; set; }
        [ForeignKey(nameof(TodoId))]
        public Todo Todo { get; set; }
    }
}
