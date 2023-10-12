using AutoMapper.Execution;

namespace TimeSheet.WebAPI.DTOs
{
    public class ReportResponseDTO
    {
        public DateTime Date { get; set; }
        public EmployeeDTO Employee { get; set; }
        public ProjectDTO Project { get; set; }
        public string Description { get; set; }
        public CategoryDTO Category { get; set; }
        public int Time {  get; set; }
        public ReportResponseDTO() { }

        public ReportResponseDTO(DateTime date, EmployeeDTO employee, ProjectDTO project, string description, CategoryDTO category, int time)
        {
            Date = date;
            Employee = employee;
            Project = project;
            Description = description;
            Category = category;
            Time = time;
        }
    }
}
