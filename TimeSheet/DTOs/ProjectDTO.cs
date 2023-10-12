using System.Text.Json.Serialization;
using TimeSheet.Core.Models;

namespace TimeSheet.WebAPI.DTOs
{
    public class ProjectDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ProjectStatus Status { get; set; }
        public int LeaderId { get; set; }
        public int CategoryId { get; set; }
        public int ClientId { get; set; }

        public ProjectDTO() { }

        public ProjectDTO(string? name, string? description, ProjectStatus status, int leaderId, int categoryId, int clientId)
        {
            Name = name;
            Description = description;
            Status = status;
            LeaderId = leaderId;
            CategoryId = categoryId;
            ClientId = clientId;
        }
    }
}