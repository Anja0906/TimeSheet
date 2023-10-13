using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Core.Models
{
    public class CalendarItem
    {
        public int Time { get; set; }
        public DateTime Date { get; set; }
        public CalendarEntityState State { get; set; }

        public CalendarItem()
        {
        }

        public CalendarItem(int time, DateTime date, CalendarEntityState state)
        {
            this.Time = time;
            Date = date;
            State = state;
        }
    }
}
