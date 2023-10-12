using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Core.Models
{
    public class Emplyee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PasswordHash { get; set; }
        public EmplyeeStatus EmplyeeStatus { get; set; }
        public Role Role { get; set; }
        public  List<Project>? Projects { get; set; }
    }
}
