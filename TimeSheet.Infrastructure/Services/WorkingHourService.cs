using TimeSheet.Core.IRepositories;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;

namespace TimeSheet.Service.Services
{
    public class WorkingHourService : IWorkingHourService
    {
        private readonly IWorkingHourRepository _workingHourRepository;
        public WorkingHourService(IWorkingHourRepository workingHourRepository)
        {
            _workingHourRepository = workingHourRepository;
        }
        public Task<WorkingHour> AddWorkingHour(int WorkerId, WorkingHour workingHour)
        {
            return _workingHourRepository.AddWorkingHour(WorkerId, workingHour);
        }

        public void DeleteWorkingHour(int id)
        {
            _workingHourRepository.DeleteWorkingHour(id);
        }

        public Task<List<WorkingHour>> GetAll()
        {
            return _workingHourRepository.GetAll();
        }

        public Task<WorkingHour> UpdateWorkingHour(WorkingHour workingHour)
        {
            return _workingHourRepository.UpdateWorkingHour(workingHour);
        }

        public Task<WorkingHour> GetById(int id)
        {
            return _workingHourRepository.GetById(id);
        }

        public Task<ReportResponse> Report(ReportRequest reportRequest)
        {
            var workingHours = _workingHourRepository.Report(reportRequest);
            var response = new ReportResponse(workingHours.Result, workingHours.Result.Sum(wh => wh.Time+wh.Overtime));
            return Task.FromResult(response);
        }

        public async Task<CalendarResponse> GetCalendar(int userId, int hoursPerWeek, DateTime firstDay, DateTime lastDay)
        {
            var repositoryResponse = await _workingHourRepository.GetCalendar(userId, firstDay, lastDay);

            List<CalendarItem> calendar = new List<CalendarItem>();
            for (DateTime i = firstDay; i <= lastDay; i = i.AddDays(1)) 
            {
                var calendarItem = repositoryResponse.ContainsKey(i)
                    ? MapOnCalendarItem(repositoryResponse[i], i, hoursPerWeek)
                    : new CalendarItem(0, i, CalendarEntityState.Empty);

                calendar.Add(calendarItem);
            }
            var response = new CalendarResponse(calendar, calendar.Sum(wh => wh.Time));

            return response;
        }

        private CalendarItem MapOnCalendarItem(int time, DateTime date, int hoursPerWeek)
        {
            var hoursPerDay = hoursPerWeek / 5;
            CalendarEntityState calendarEntityState = CalendarEntityState.Empty;

            if (time <= 0)
            {
                calendarEntityState = CalendarEntityState.Empty;
            }
            else if (time >= hoursPerDay)
            {
                calendarEntityState = CalendarEntityState.AchievedFullTime;
            }
            else
            {
                calendarEntityState = CalendarEntityState.NonAchievedFullTime;
            }

            return new CalendarItem(time, date, calendarEntityState);
        }

    }
}
