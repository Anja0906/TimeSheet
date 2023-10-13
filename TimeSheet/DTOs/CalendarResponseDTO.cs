using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.WebAPI.DTOs
{
    public class CalendarResponseDTO
    {
        public List<CalendarItemDTO> Items { get; set; }
        public double TimeSum {  get; set; }

        public CalendarResponseDTO(List<CalendarItemDTO> items, double timeSum)
        {
            Items = items;
            TimeSum = timeSum;
        }

        public CalendarResponseDTO()
        {
            Items = new List<CalendarItemDTO>();
        }
    }
}
