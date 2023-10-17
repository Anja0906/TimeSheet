using System.Security.Claims;
using TimeSheet.Core.Models;

namespace TimeSheet.Core.IServices
{
    public interface IWorkingHourService
    {
        Task<WorkingHour> UpdateWorkingHour(WorkingHour workingHour);
        Task<List<WorkingHour>> GetAll();
        Task<WorkingHour> GetById(int id);
        Task<WorkingHour> AddWorkingHour(int WorkerId, WorkingHour workingHour);
        void DeleteWorkingHour(int id);
        Task<ReportResponse> Report(ReportRequest reportRequest);
        Task<CalendarResponse> GetCalendar(int userId, int hoursPerWeek, DateTime firstDay, DateTime lastDay);
    }
}
