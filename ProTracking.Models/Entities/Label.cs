using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProTracking.Domain.Entities
{
    public class Label
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Title { get; set; }

        [NotMapped]
        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }
    }
}
