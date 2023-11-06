using ProTracking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ProTracking.Domain.Entities
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int? LabelId { get; set; }
        public string? Title { get; set; }
        public string? Status { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(7);
        public int? ReportTo { get; set; }
        public int? Assignee { get; set; }
        public int CreatedBy { get; set; }

        public PriorityEnum Priority { get; set; }
        public string? IconPriority { get; set; }

        [NotMapped]
        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }

        [NotMapped]
        [ForeignKey(nameof(LabelId))]
        public Label? Label { get; set; }

        [NotMapped]
        [ForeignKey(nameof(CreatedBy))]
        public Customer Customer { get; set; }
    }
}
