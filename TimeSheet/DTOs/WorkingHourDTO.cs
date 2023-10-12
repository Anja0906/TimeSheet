using System.Text.Json.Serialization;

namespace TimeSheet.WebAPI.DTOs
{
    public class WorkingHourDTO
    {
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public int ProjectId { get; set; }
        public int CategoryId { get; set; }
        public int EmplyeeId { get; set; }
        public double Time { get; set; }
        public double Overtime { get; set; }

        public WorkingHourDTO() { }

        public WorkingHourDTO(DateTime date, string? description, int projectId, int categoryId, double time, double overtime)
        {
            Date = date;
            Description = description;
            ProjectId = projectId;
            CategoryId = categoryId;
            Time = time;
            Overtime = overtime;
        }
    }
}