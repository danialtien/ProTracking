using ProTracking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Domain.Entities.DTOs
{
    public class ProjectParticipantDTO
    {
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public bool IsLeader { get; set; }
    }
}
