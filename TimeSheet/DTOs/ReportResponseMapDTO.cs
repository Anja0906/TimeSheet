namespace TimeSheet.WebAPI.DTOs
{
    public class ReportResponseMapDTO
    {
        public List<WorkingHourResponseDTO> Items { get; set; }
        public double TimeSum { get; set; }

        public ReportResponseMapDTO(List<WorkingHourResponseDTO> items, double timeSum)
        {
            Items = items;
            TimeSum = timeSum;
        }

        public ReportResponseMapDTO()
        {
            Items = new List<WorkingHourResponseDTO>();
        }
    }
}
