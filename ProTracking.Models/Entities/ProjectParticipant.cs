using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProTracking.Domain.Entities
{
    public class ProjectParticipant
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int CustomerId { get; set; }
        public bool IsLeader { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }
        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
    }
}
