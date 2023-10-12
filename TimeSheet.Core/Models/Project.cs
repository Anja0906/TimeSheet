namespace TimeSheet.Core.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ProjectStatus Status { get; set; }
        public int LeaderId { get; set; }
        public  Emplyee? Leader { get; set; }
        public int CategoryId { get; set; }
        public  Category? Category { get; set; }
        public int ClientId { get; set; }
        public  Client? Client { get; set; }
    }
}
