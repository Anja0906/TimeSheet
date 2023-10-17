using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Core.Exceptions;
using TimeSheet.Core.IRepositories;
using TimeSheet.Core.Models;

namespace TimeSheet.Data.Repositories
{
    public class WorkingHourRepository : IWorkingHourRepository
    {
        private readonly IMapper _mapper;
        private DataContext _dataContext;
        public WorkingHourRepository(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public Task<WorkingHour> AddWorkingHour(int WorkerId, WorkingHour workingHour)
        {
            var worker = _dataContext.Employees.FirstOrDefault(p => p.Id == WorkerId);
            var workingHourEntity = _mapper.Map<Entities.WorkingHour>(workingHour);
            _dataContext.WorkingHours.Add(workingHourEntity);
            _dataContext.SaveChanges();
            var createdModel = _mapper.Map<WorkingHour>(workingHourEntity);
            return Task.FromResult(createdModel);
        }

        public void DeleteWorkingHour(int id)
        {
            var existingWorkingHour = _dataContext.WorkingHours.Where(x => x.Id == id).FirstOrDefault();
            if (existingWorkingHour == null)
            {
                throw new ResourceNotFoundException("WorkingHour with that id does not exist!");
            }
            _dataContext.WorkingHours.Remove(existingWorkingHour);
            _dataContext.SaveChanges();
        }

        public Task<WorkingHour> GetById(int id)
        {
            var workingHourEntity = _dataContext.WorkingHours.Where(p => p.Id == id).FirstOrDefault();
            if (workingHourEntity == null)
            {
                throw new ResourceNotFoundException("WorkingHour with that id does not exist!");

            }
            var workingHourModel = _mapper.Map<WorkingHour>(workingHourEntity);
            return Task.FromResult(workingHourModel);

        }


        public Task<WorkingHour> UpdateWorkingHour(WorkingHour workingHour)
        {
            var existingWorkingHour = _dataContext.WorkingHours.Where(p => p.Id == workingHour.Id).FirstOrDefault();
            if (existingWorkingHour == null)
            {
                throw new ResourceNotFoundException("WorkingHour with that id does not exist!");
            }
            _dataContext.Attach(existingWorkingHour);
            _dataContext.Entry(existingWorkingHour).CurrentValues.SetValues(workingHour);
            _dataContext.SaveChanges();
            var updatedWorkingHour = _dataContext.WorkingHours.Where(p => p.Id == workingHour.Id).FirstOrDefault();
            if (updatedWorkingHour == null)
            {
                throw new ArgumentException();
            }
            var mappedWorkingHour = _mapper.Map<WorkingHour>(updatedWorkingHour);
            return Task.FromResult(mappedWorkingHour);
        }

        public Task<List<WorkingHour>> GetAll()
        {
            var categories = _dataContext.WorkingHours.OrderBy(p => p.Id).ToList();
            List<WorkingHour> result = _mapper.Map<List<WorkingHour>>(categories);
            return Task.FromResult(result);
        }

        public Task<List<WorkingHour>> Report(ReportRequest reportRequest)
        {
            var baseQuery = _dataContext.WorkingHours.AsQueryable();
            if (reportRequest.CategoryId.HasValue)
            {
                baseQuery = baseQuery.Where(e => e.CategoryId == reportRequest.CategoryId);
            }
            if (reportRequest.ProjectId.HasValue)
            {
                baseQuery = baseQuery.Where(e => e.ProjectId == reportRequest.ProjectId);
            }
            if (reportRequest.TeamMemberId.HasValue)
            {
                baseQuery = baseQuery.Where(e => e.EmplyeeId == reportRequest.TeamMemberId);
            }
            if (reportRequest.ClientId.HasValue)
            {
                baseQuery = baseQuery.Include(e => e.Project);
                baseQuery = baseQuery.Where(e => e.Project.ClientId == reportRequest.ClientId);
            }
            if (reportRequest.CategoryId.HasValue)
            {
                baseQuery = baseQuery.Where(e => e.CategoryId == reportRequest.CategoryId);
            }
            if (reportRequest.From.HasValue)
            {
                baseQuery = baseQuery.Where(e => e.Date>=reportRequest.From);
            }
            if (reportRequest.To.HasValue)
            {
                baseQuery = baseQuery.Where(e => e.Date<=reportRequest.To);
            }
            var result = _mapper.Map<List<WorkingHour>>(baseQuery);
            return Task.FromResult(result);
        }

        public Task<Dictionary<DateTime, int>> GetCalendar(int userId, DateTime startDate, DateTime endDate)
        {
            var workingHours = _dataContext.WorkingHours.Where(wh => wh.Date >= startDate && wh.Date <= endDate && wh.EmplyeeId == userId)
                                                        .GroupBy(wh => wh.Date.Date)
                                                        .ToDictionary(group => group.Key, group => (int)group.Sum(wh => wh.Time + wh.Overtime));
            return Task.FromResult(workingHours);
        }
        
    }

}
