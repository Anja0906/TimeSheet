using System.ComponentModel.DataAnnotations;

namespace TimeSheet.Core.Models { 
    public class WorkingHour
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public int ProjectId { get; set; }
        public  Project? Project { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public double Time { get; set; }
        public double Overtime { get; set; }
        public int EmplyeeId { get; set; }
        public Emplyee? Emplyee { get; set; }
    }
}
