using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Data.Entities
{
    public class Emplyee
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        [NotMapped] 
        public string? Password { get; set; }

        public string? PasswordHash { get; set; }
        public EmplyeeStatus EmplyeeStatus { get; set; }
        public Role Role { get; set; }
        public virtual List<Project>? Projects { get; set; }
    }
}
