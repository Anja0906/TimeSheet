using System.Text.Json.Serialization;
using TimeSheet.Core.Models;

namespace TimeSheet.WebAPI.DTOs
{
    public class EmployeeDTO
    {
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public EmplyeeStatus EmplyeeStatus { get; set; }
        public Role Role { get; set; }

        public EmployeeDTO() { }

        public EmployeeDTO(string? name, string? username, string? email, string? password, EmplyeeStatus emplyeeStatus, Role role)
        {
            Name = name;
            Username = username;
            Email = email;
            Password = password;
            EmplyeeStatus = emplyeeStatus;
            Role = role;
        }
    }
}