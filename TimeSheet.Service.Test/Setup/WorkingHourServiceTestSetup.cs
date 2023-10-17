using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Core.IRepositories;
using TimeSheet.Core.Models;
using TimeSheet.Service.Services;

namespace TimeSheet.Service.Test.Setup
{
    public class WorkingHourServiceTestSetup
    {
        protected Mock<IWorkingHourRepository> workingHourRepositoryMock;
        protected WorkingHourService workingHourService;
        protected WorkingHour WorkingHour { get; set; }
        protected WorkingHour nonExistingWorkingHour { get; set; }
        protected ReportRequest reportRequest { get; set; }
        protected Dictionary<DateTime, int> repositoryResponse { get; set; }
        protected int WorkerId;
        protected List<WorkingHour> workingHours { get; set; }
        public WorkingHourServiceTestSetup()
        {
            workingHourRepositoryMock = new Mock<IWorkingHourRepository>();
            workingHourService = new WorkingHourService(workingHourRepositoryMock.Object);
            Setup();
        }
        private void Setup()
        {
            WorkerId = 2;
            WorkingHour = new WorkingHour()
            {
                Id = 23,
                Date = DateTime.Now,
                Description = "Test",
                ProjectId = 2,
                CategoryId = 1,
                Time = 9,
                Overtime = 1,
                EmplyeeId = WorkerId,

            };
            nonExistingWorkingHour = new WorkingHour()
            {
                Id = 1234,
                Date = DateTime.Now,
                Description = "Test",
                ProjectId = 2,
                CategoryId = 1,
                Time = 9,
                Overtime = 1,
                EmplyeeId = WorkerId,

            };
            workingHours = new List<WorkingHour>()
            {
                new WorkingHour()
            {
                Id = 23,
                Date = DateTime.Now,
                Description = "Test1",
                ProjectId = 2,
                CategoryId = 1,
                Time = 9,
                Overtime = 1,
                EmplyeeId = WorkerId,

            },
                new WorkingHour()
            {
                Id = 13,
                Date = DateTime.Now,
                Description = "Test2",
                ProjectId = 3,
                CategoryId = 3,
                Time = 7,
                Overtime = 3,
                EmplyeeId = WorkerId,

            },
                new WorkingHour()
            {
                Id = 12,
                Date = DateTime.Now,
                Description = "Test3",
                ProjectId = 1,
                CategoryId = 2,
                Time = 5,
                Overtime = 2,
                EmplyeeId = WorkerId,

            } };
            reportRequest = new ReportRequest()
            {
                TeamMemberId = 8,
                ClientId = 1,
                ProjectId = 1,
                CategoryId = 1,
                From = DateTime.Parse("2023-10-01"),
                To = DateTime.Parse("2023-10-30"),
            };
            repositoryResponse = new Dictionary<DateTime, int>
            {
                { new DateTime(2023, 1, 1), 8 },
                { new DateTime(2023, 1, 2), 8 },
            };

        }
    }
}
