using ProTracking.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProTracking.Domain.Entities.DTOs
{
    public class GetProjectWithTodoAndPaties
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }
        public int CreatedBy { get; set; }
        public string? UserCreatedName { get; set; }
        public ICollection<ProjectParticipantWUsernameDTO> Participants { get; set; }
        public ICollection<TodoDTO>? Todos { get; set; }
    }
}
