using TimeSheet.Core.Models;

namespace TimeSheet.WebAPI.DTOs
{
    public class WorkingHourResponseDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public int ProjectId { get; set; }
        public ProjectResponseDTO? Project { get; set; }
        public int CategoryId { get; set; }
        public CategoryResponseDTO? Category { get; set; }
        public double Time { get; set; }
        public double Overtime { get; set; }
        public int EmplyeeId { get; set; }
        public EmployeeResponseDTO? Emplyee { get; set; }

        public WorkingHourResponseDTO()
        {
        }

        public WorkingHourResponseDTO(int id, DateTime date, string? description, int projectId, ProjectResponseDTO? project, int categoryId, CategoryResponseDTO? category, double time, double overtime, int emplyeeId, EmployeeResponseDTO? emplyee)
        {
            Id = id;
            Date = date;
            Description = description;
            ProjectId = projectId;
            Project = project;
            CategoryId = categoryId;
            Category = category;
            Time = time;
            Overtime = overtime;
            EmplyeeId = emplyeeId;
            Emplyee = emplyee;
        }
    }
}