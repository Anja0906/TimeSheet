using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Core.Models;

namespace TimeSheet.Core.IServices
{
    public interface IWorkingHourService
    {
        Task<WorkingHour> GetByName(string name);
        Task<WorkingHour> UpdateWorkingHour(WorkingHour workingHour);
        Task<List<WorkingHour>> GetAll();
        Task<WorkingHour> GetById(int id);
        Task<WorkingHour> AddWorkingHour(int WorkerId, WorkingHour workingHour);
        void DeleteWorkingHour(int id);
        Task<List<WorkingHour>> Report(ReportRequest reportRequest);
    }
}
