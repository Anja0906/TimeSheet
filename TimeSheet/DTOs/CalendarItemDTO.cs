using TimeSheet.Core.Models;

namespace TimeSheet.WebAPI.DTOs
{
    public class CalendarItemDTO
    {
        public int Time { get; set; }
        public DateTime Date { get; set; }
        public CalendarEntityState State { get; set; }

        public CalendarItemDTO()
        {
        }

        public CalendarItemDTO(int time, DateTime date, CalendarEntityState state)
        {
            Time = time;
            Date = date;
            State = state;
        }
    }
}
