using Microsoft.EntityFrameworkCore.Migrations.Operations;
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

        public Task<WorkingHour> GetByName(string name)
        {
            return _workingHourRepository.GetByName(name);
        }

        public Task<WorkingHour> GetById(int id)
        {
            return _workingHourRepository.GetById(id);
        }

        public Task<ReportResponse> Report(ReportRequest reportRequest)
        {
            var workingHours = _workingHourRepository.Report(reportRequest);
            var response = new ReportResponse(workingHours.Result, SumWorkingHours(workingHours.Result));
            return Task.FromResult(response);
        }

        public Task<CalendarResponse> GetCalendar(int userId, int hoursPerWeek, DateTime firstDay, DateTime lastDay)
        {
            List<CalendarItem> calendar = new List<CalendarItem>();
            var numberOfDays = (lastDay - firstDay).Days + 1;
            for (int i=0; i<=numberOfDays; i++)
            {
                var calendarItem = new CalendarItem(0, firstDay.AddDays(i), CalendarEntityState.LowerThanMinimum);
                calendar.Add(calendarItem);
            }
            var repositoryResponse = _workingHourRepository.GetCalendar(userId, firstDay, lastDay);
            var map = MapDTOs(repositoryResponse.Result, hoursPerWeek);
            var result = AddEmptyDays(calendar, map);
            return Task.FromResult(new CalendarResponse(result, SumCalenderHours(result)));
        }

        private List<CalendarItem> MapDTOs(Dictionary<DateTime, int> repositoryResponse, int hoursPerWeek)
        {
            var result = new List<CalendarItem>();
            var hoursPerDayPartTime = hoursPerWeek/10;
            foreach (var item in repositoryResponse)
            {
                CalendarEntityState calendarEntityState = CalendarEntityState.LowerThanMinimum;
                if (item.Value <= 0)
                    calendarEntityState = CalendarEntityState.LowerThanMinimum;
                else if (item.Value <= hoursPerDayPartTime)
                    calendarEntityState = CalendarEntityState.EnteredPartTime;
                else
                    calendarEntityState = CalendarEntityState.EnteredFullTime;
                result.Add(new CalendarItem(item.Value, item.Key, calendarEntityState));
            }
            return result;
        }

        private List<CalendarItem> AddEmptyDays(List<CalendarItem> allDays, List<CalendarItem> repositoryDays)
        {
            //TODO : izbaciti ove prvo iz liste 
            allDays = allDays.Where(item => !repositoryDays.Any(r => r.Date == item.Date)).ToList();
            allDays.AddRange(repositoryDays);
            allDays.OrderBy(item => item.Date);
            return allDays;
        }
        private double SumCalenderHours(List<CalendarItem> calendarItems)
        {
            double total = 0.0;
            foreach (var item in calendarItems)
                total += item.Time;
            return total;
        }
        private double SumWorkingHours(List<WorkingHour> workingHours)
        {
            double total = 0.0;
            foreach (var item in workingHours)
            {
                total += item.Time;
                total += item.Overtime;
            }
            return total;
        }
    }
}
