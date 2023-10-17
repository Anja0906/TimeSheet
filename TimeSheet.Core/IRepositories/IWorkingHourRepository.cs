using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Core.Models;

namespace TimeSheet.Core.IRepositories
{
    public interface IWorkingHourRepository
    {
        Task<WorkingHour> UpdateWorkingHour(WorkingHour workingHour);
        Task<List<WorkingHour>> GetAll();
        Task<Dictionary<DateTime, int>> GetCalendar(int userId, DateTime startDate, DateTime endDate);
        Task<WorkingHour> GetById(int id);
        Task<WorkingHour> AddWorkingHour(int WorkerId, WorkingHour workingHour);
        void DeleteWorkingHour(int id);
        Task<List<WorkingHour>> Report(ReportRequest reportRequest);
    }
}
