using TimeSheet.Core.Models;

namespace TimeSheet.WebAPI.DTOs
{
    public class ProjectResponseDTO
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ProjectStatus Status { get; set; }
        public int LeaderId { get; set; }
        public EmployeeResponseDTO? Leader { get; set; }
        public int CategoryId { get; set; }
        public CategoryResponseDTO? Category { get; set; }
        public int ClientId { get; set; }
        public ClientResponseDTO? Client { get; set; }

        public ProjectResponseDTO()
        {
        }

        public ProjectResponseDTO(int id, string? name, string? description, ProjectStatus status, int leaderId, EmployeeResponseDTO? leader, int categoryId, CategoryResponseDTO? category, int clientId, ClientResponseDTO? client)
        {
            Id = id;
            Name = name;
            Description = description;
            Status = status;
            LeaderId = leaderId;
            Leader = leader;
            CategoryId = categoryId;
            Category = category;
            ClientId = clientId;
            Client = client;
        }
    }
}