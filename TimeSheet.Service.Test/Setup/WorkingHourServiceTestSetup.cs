using Moq;
using TimeSheet.Core.IRepositories;
using TimeSheet.Core.Models;
using TimeSheet.Service.Services;

namespace TimeSheet.Service.Test.Setup
{
    public class WorkingHourServiceTestSetup
    {
        public Mock<IWorkingHourRepository> WorkingHourRepositoryMock;
        public WorkingHourService WorkingHourService;
        public WorkingHourServiceTestSetup()
        {
            WorkingHourRepositoryMock = new Mock<IWorkingHourRepository>();
            WorkingHourService = new WorkingHourService(WorkingHourRepositoryMock.Object);
        }

        public void AddWorkingHourMock(int workerId, WorkingHour request, WorkingHour response)
        {
            WorkingHourRepositoryMock.Setup(repo => repo.AddWorkingHour(workerId, request)).ReturnsAsync(response);
        }

        public void GetAllMock(List<WorkingHour> workingHours)
        {
            WorkingHourRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(workingHours);
        }
        public void UpdateWorkingHourMock(WorkingHour request, WorkingHour response)
        {
            WorkingHourRepositoryMock.Setup(repo => repo.UpdateWorkingHour(request)).ReturnsAsync(response);
        }
        public void GetByIdMock(int id, WorkingHour response)
        {
            WorkingHourRepositoryMock.Setup(repo => repo.GetById(id)).ReturnsAsync(response);
        }
        public void ReportMock(ReportRequest reportRequest, List<WorkingHour> response)
        {
            WorkingHourRepositoryMock.Setup(repo => repo.Report(reportRequest))
                                    .ReturnsAsync(response);
        }
        public void CalendarMock(int userId, DateTime firstDay, DateTime lastDay, Dictionary<DateTime, int> response)
        {
            WorkingHourRepositoryMock.Setup(repo => repo.GetCalendar(userId, firstDay, lastDay))
                .ReturnsAsync(response);
        }
    }
}
