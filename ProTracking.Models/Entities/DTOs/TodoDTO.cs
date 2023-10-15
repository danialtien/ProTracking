using ProTracking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Domain.Entities.DTOs
{
    public class TodoDTO
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int? LabelId { get; set; }
        public string? Title { get; set; }
        public string? Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ReportTo { get; set; }
        public int Assignee { get; set; }
        public int CreatedBy { get; set; }
        public PriorityEnum Priority { get; set; }
        public string? IconPriority { get; set; }
    }
}
