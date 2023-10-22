using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProTracking.Domain.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        [Required]
        public int CreatedBy { get; set; }

        [NotMapped]
        public IEnumerable<Todo>? Todo { get; set; }
    }
}
