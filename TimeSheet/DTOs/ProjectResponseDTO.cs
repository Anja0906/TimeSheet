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
        public Emplyee? Leader { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        public ProjectResponseDTO()
        {
        }

        public ProjectResponseDTO(int id, string? name, string? description, ProjectStatus status, int leaderId, Emplyee? leader, int categoryId, Category? category, int clientId, Client? client)
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