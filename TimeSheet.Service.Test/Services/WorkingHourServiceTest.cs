using Moq;
using TimeSheet.Core.Exceptions;
using TimeSheet.Core.Models;
using TimeSheet.Service.Test.Setup;
using Xunit;

namespace TimeSheet.Service.Test.Services
{
    public class WorkingHourServiceTest
    {
        private readonly WorkingHourServiceTestSetup setup;
        private WorkingHour workingHour { get; set; }
        private int workerId;
        private List<WorkingHour> workingHours;
        private WorkingHour nonExistingWorkingHour { get; set; }
        private ReportRequest reportRequest { get; set; }
        private Dictionary<DateTime, int> calndarResponse { get; set; }
        public WorkingHourServiceTest() {
            setup = new WorkingHourServiceTestSetup();
        }
        
        private void SeedData()
        {
            workerId = 2;
            workingHour = new WorkingHour(){Id = 23, Date = DateTime.Now, Description = "Test", ProjectId = 2, CategoryId = 1, Time = 9, Overtime = 1, EmplyeeId = workerId};
            workingHours = new List<WorkingHour> 
            {   
                new WorkingHour { Id = 23, Date = DateTime.Now, Description = "Test1", ProjectId = 2, CategoryId = 1, Time = 9, Overtime = 1, EmplyeeId = workerId},
                new WorkingHour { Id = 13, Date = DateTime.Now, Description = "Test2", ProjectId = 3, CategoryId = 3, Time = 7, Overtime = 3, EmplyeeId = workerId},
                new WorkingHour { Id = 12, Date = DateTime.Now, Description = "Test3", ProjectId = 1, CategoryId = 2, Time = 5, Overtime = 2, EmplyeeId = workerId }
            };
            nonExistingWorkingHour = new WorkingHour { Id = 1234, Date = DateTime.Now, Description = "Test", ProjectId = 2, CategoryId = 1, Time = 9, Overtime = 1, EmplyeeId = workerId};

            reportRequest = new ReportRequest { TeamMemberId = 8, ClientId = 1, ProjectId = 1, CategoryId = 1, From = DateTime.Parse("2023-10-01"), To = DateTime.Parse("2023-10-30")};
            calndarResponse = new Dictionary<DateTime, int>
            {
                { new DateTime(2023, 1, 1), 9 },
                { new DateTime(2023, 1, 2), 0 },
                { new DateTime(2023, 1, 3), 4 },
                { new DateTime(2023, 1, 4), 9 },
                { new DateTime(2023, 1, 5), 8 },
                { new DateTime(2023, 1, 6), 5 },
            };
        }
        [Fact]
        public async Task AddWorkingHour_CallsRepositoryWithCorrectParameters()
        {
            SeedData();
            setup.AddWorkingHourMock(workerId, workingHour, workingHour);
            var result = await setup.WorkingHourService.AddWorkingHour(workerId, workingHour);
            setup.WorkingHourRepositoryMock.Verify(repo => repo.AddWorkingHour(workerId, workingHour), Times.Once);
            Assert.Equal(workingHour, result);
        }
        [Fact]
        public void DeleteWorkingHour_ValidId_CallsRepository()
        {
            SeedData();
            int workingHourId = 1;
            setup.WorkingHourService.DeleteWorkingHour(workingHourId);
            setup.WorkingHourRepositoryMock.Verify(repo => repo.DeleteWorkingHour(workingHourId), Times.Once);
        }

        [Fact]
        public async Task GetAll_ReturnsListOfWorkingHours()
        {
            SeedData();
            setup.GetAllMock(workingHours);
            var result = await setup.WorkingHourService.GetAll();
            Assert.NotNull(result);
            Assert.Equal(workingHours.Count, result.Count);
            for (int i = 0; i < workingHours.Count; i++)
            {
                Assert.Equal(workingHours[i].Id, result[i].Id);
            }
        }

        [Fact]
        public async Task UpdateWorkingHour_ValidUpdate_ReturnsUpdatedWorkingHour()
        {
            SeedData();
            setup.UpdateWorkingHourMock(workingHour, workingHour);
            var result = await setup.WorkingHourService.UpdateWorkingHour(workingHour);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetById_ValidId_ReturnsWorkingHour()
        {
            SeedData();
            int id = 23;
            setup.GetByIdMock(id, workingHour);
            var result = await setup.WorkingHourService.GetById(id);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Report_ValidRequest_GeneratesReportResponse()
        {
            SeedData();
            setup.ReportMock(reportRequest, workingHours);
            var result = await setup.WorkingHourService.Report(reportRequest);
            Assert.NotNull(result);
            Assert.Equal(result.Items.Count, workingHours.Count);
        }

        [Fact]
        public async Task GetCalendar_ValidParameters_GeneratesCalendarResponse()
        {
            SeedData();
            int userId = 1;
            int hoursPerWeek = 40;
            DateTime firstDay = new DateTime(2023, 1, 1);
            DateTime lastDay = new DateTime(2023, 1, 10);
            setup.CalendarMock(userId, firstDay, lastDay, calndarResponse);
            var result = await setup.WorkingHourService.GetCalendar(userId, hoursPerWeek, firstDay, lastDay);
            int expectedDays = (int)(lastDay - firstDay).TotalDays + 1;
            Assert.NotNull(result);
            Assert.Equal(result.Items.Count, expectedDays);
        }
        [Fact]
        public async Task GetCalendar_ShouldCalculateCorrectCalendar()
        {
            SeedData();
            int userId = 1;
            int hoursPerWeek = 40;
            DateTime firstDay = new DateTime(2023, 1, 1);
            DateTime lastDay = new DateTime(2023, 1, 7);
            setup.CalendarMock(userId, firstDay, lastDay, calndarResponse);
            var result = await setup.WorkingHourService.GetCalendar(userId, hoursPerWeek, firstDay, lastDay);
            Assert.Equal(lastDay, result.Items.Last().Date);
            Assert.Equal(0, result.Items.Last().Time);
            Assert.Equal(CalendarEntityState.Empty, result.Items.Last().State);
        }
    }
}