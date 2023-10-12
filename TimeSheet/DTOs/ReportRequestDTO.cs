using TimeSheet.Core.Models;

namespace TimeSheet.WebAPI.DTOs
{
    public class ReportRequestDTO
    {
        public int TeamMemberId { get; set; }
        public int ClientId { get; set; }
        public int ProjectId { get; set; }
        public int CategoryId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public ReportRequestDTO() { }

        public ReportRequestDTO(int teamMemberId, int clientId, int projectId, int categoryId, DateTime from, DateTime to)
        {
            TeamMemberId = teamMemberId;
            ClientId = clientId;
            ProjectId = projectId;
            CategoryId = categoryId;
            From = from;
            To = to;
        }
    }
}
