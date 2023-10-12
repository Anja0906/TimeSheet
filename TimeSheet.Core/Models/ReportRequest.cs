namespace TimeSheet.Core.Models
{
    public class ReportRequest
    {
        public int? TeamMemberId { get; set; }
        public int? ClientId { get; set; }
        public int? ProjectId { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public ReportRequest() { }
        public ReportRequest(int? teamMemberId, int? clientId, int? projectId, int? categoryId, DateTime? from, DateTime? to)
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
