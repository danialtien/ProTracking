using ProTracking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Domain.Entities.DTOs
{
    public class ChildTaskDTO
    {
        public int Id { get; set; }
        public int TodoId { get; set; }
        public int? CreatedBy { get; set; }
        public string? Title { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public PriorityEnum? Priority { get; set; }
    }
}
