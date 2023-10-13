using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Core.Models
{
    public class CalendarResponse
    {
        public List<CalendarItem> Items { get; set; }
        public double TimeSum {  get; set; }

        public CalendarResponse(List<CalendarItem> items, double timeSum)
        {
            Items = items;
            TimeSum = timeSum;
        }

        public CalendarResponse()
        {
            Items = new List<CalendarItem>();
        }
    }
}
