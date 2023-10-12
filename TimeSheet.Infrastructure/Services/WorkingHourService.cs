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

        public Task<List<WorkingHour>> Report(ReportRequest reportRequest)
        {
            return _workingHourRepository.Report(reportRequest);
        }
    }
}
