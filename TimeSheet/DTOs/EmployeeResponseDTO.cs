using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TimeSheet.Core.Models;

namespace TimeSheet.WebAPI.DTOs
{
    public class EmployeeResponseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public EmplyeeStatus EmplyeeStatus { get; set; }
        public Role Role { get; set; }
        public  List<ProjectResponseDTO>? Projects { get; set; }

        public EmployeeResponseDTO()
        {
        }

        public EmployeeResponseDTO(int id, string? name, string? username, string? email, EmplyeeStatus emplyeeStatus, Role role)
        {
            Id = id;
            Name = name;
            Username = username;
            Email = email;
            EmplyeeStatus = emplyeeStatus;
            Role = role;
        }

        public EmployeeResponseDTO(int id, string? name, string? username, string? email, EmplyeeStatus emplyeeStatus, Role role, List<ProjectResponseDTO>? projects) : this(id, name, username, email, emplyeeStatus, role)
        {
            Projects = projects;
        }
    }
}