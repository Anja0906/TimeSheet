namespace TimeSheet.Core.Models
{
    public class ReportResponse
    {
        public List<WorkingHour> Items { get; set; }
        public double TimeSum { get; set; }

        public ReportResponse(List<WorkingHour> items, double timeSum)
        {
            Items = items;
            TimeSum = timeSum;
        }

        public ReportResponse()
        {
            Items = new List<WorkingHour>();
        }
    }
}
