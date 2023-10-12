

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Data.Entities
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public ProjectStatus Status { get; set; }   
        public int LeaderId { get; set; }
        public virtual Emplyee? Leader { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public int ClientId { get; set; }
        public virtual Client? Client { get; set; }
    }
}
