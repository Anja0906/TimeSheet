using Moq;
using TimeSheet.Core.Exceptions;
using TimeSheet.Core.Models;
using TimeSheet.Service.Test.Setup;
using Xunit;

namespace TimeSheet.Service.Test.Services
{
    public class WorkingHourServiceTest : WorkingHourServiceTestSetup
    {
        public WorkingHourServiceTest() : base(){}
        
        [Fact]
        public async Task AddWorkingHour_CallsRepositoryWithCorrectParameters()
        {
            workingHourRepositoryMock
                .Setup(repo => repo.AddWorkingHour(WorkerId, WorkingHour))
                .ReturnsAsync(WorkingHour);
            var result = await workingHourService.AddWorkingHour(WorkerId, WorkingHour);
            workingHourRepositoryMock.Verify(repo => repo.AddWorkingHour(WorkerId, WorkingHour), Times.Once);
            Assert.Equal(WorkingHour, result);
        }

        [Fact]
        public async Task AddWorkingHour_ValidInput_ReturnsWorkingHour()
        {
            workingHourRepositoryMock
                .Setup(repo => repo.AddWorkingHour(WorkerId, WorkingHour))
                .ReturnsAsync(WorkingHour);
            var result = await workingHourService.AddWorkingHour(WorkerId, WorkingHour);
            Assert.NotNull(result); 
        }

        [Fact]
        public async Task AddWorkingHour_InvalidWorkerId_ReturnsNull()
        {
            var workerId = 0;
            var result = await workingHourService.AddWorkingHour(workerId, WorkingHour);
            Assert.Null(result);
        }

        [Fact]
        public async Task AddWorkingHour_InvalidWorkingHour_ReturnsNull()
        {
            WorkingHour workingHour = null;
            var result = await workingHourService.AddWorkingHour(WorkerId, workingHour);
            Assert.Null(result);
        }
        [Fact]
        public void DeleteWorkingHour_ValidId_CallsRepository()
        {
            int workingHourId = 1;
            workingHourService.DeleteWorkingHour(workingHourId);
            workingHourRepositoryMock.Verify(repo => repo.DeleteWorkingHour(workingHourId), Times.Once);
        }

        [Fact]
        public void DeleteWorkingHour_InvalidId_ThrowsException()
        {
            var invalidId = -1;
            workingHourRepositoryMock
                    .Setup(repo => repo.DeleteWorkingHour(It.Is<int>(id => id <= 0)))
                    .Throws(new ResourceNotFoundException("WorkingHour with that id does note exist!"));
            var ex = Assert.Throws<ResourceNotFoundException>(() => workingHourService.DeleteWorkingHour(invalidId));
            Assert.Equal("WorkingHour with that id does note exist!", ex.Message);
        }

        [Fact]
        public async Task GetAll_ReturnsListOfWorkingHours()
        {
            workingHourRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(workingHours);
            var result = await workingHourService.GetAll();
            Assert.NotNull(result);
            Assert.Equal(workingHours.Count, result.Count);
            for (int i = 0; i < workingHours.Count; i++)
            {
                Assert.Equal(workingHours[i].Id, result[i].Id);
            }
        }
        [Fact]
        public async Task GetAll_ReturnsEmptyListOfWorkingHours()
        {
            workingHourRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(new List<WorkingHour>());
            var result = await workingHourService.GetAll();
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task UpdateWorkingHour_ValidUpdate_ReturnsUpdatedWorkingHour()
        {
            workingHourRepositoryMock.Setup(repo => repo.UpdateWorkingHour(WorkingHour))
                .ReturnsAsync(WorkingHour);
            var result = await workingHourService.UpdateWorkingHour(WorkingHour);
            Assert.NotNull(result);
        }
        [Fact]
        public async Task UpdateWorkingHour_InvalidUpdate_ThrowsException()
        {
            workingHourRepositoryMock
                    .Setup(repo => repo.UpdateWorkingHour(nonExistingWorkingHour))
                    .Throws(new ResourceNotFoundException("WorkingHour with that id does not exist!"));
            var ex = await Assert.ThrowsAsync<ResourceNotFoundException>(() => workingHourService.UpdateWorkingHour(nonExistingWorkingHour));
            Assert.Equal("WorkingHour with that id does not exist!", ex.Message);
        }
        [Fact]
        public async Task UpdateWorkingHour_InvalidUpdate_ReturnsNull()
        {
            WorkingHour nullWorkingHour = null;
            var result = await workingHourService.UpdateWorkingHour(nullWorkingHour);
            Assert.Null(result);
        }

        [Fact]
        public async Task GetByName_ValidId_ReturnsWorkingHour()
        {
            int id = 1;
            workingHourRepositoryMock.Setup(repo => repo.GetById(id))
                .ReturnsAsync(WorkingHour);
            var result = await workingHourService.GetById(id);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetByName_InvalidId_ThrowsException()
        {
            int id = -1;
            workingHourRepositoryMock
                    .Setup(repo => repo.GetById(It.Is<int>(id => id <= 0)))
                    .Throws(new ResourceNotFoundException("WorkingHour with that id does not exist!"));
            var ex = await Assert.ThrowsAsync<ResourceNotFoundException>(() => workingHourService.GetById(id));
            Assert.Equal("WorkingHour with that id does not exist!", ex.Message);
        }

        [Fact]
        public async Task Report_ValidRequest_GeneratesReportResponse()
        {
            workingHourRepositoryMock.Setup(repo => repo.Report(reportRequest))
                .ReturnsAsync(workingHours);
            var result = await workingHourService.Report(reportRequest);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Report_NullRequest_ReturnsNullResponse()
        {
            ReportRequest nullRequest = null;
            workingHourRepositoryMock.Setup(repo => repo.Report(nullRequest))
                .Throws(new NullReferenceException("You cannot send null object as parameter!"));
            var ex = await Assert.ThrowsAsync<NullReferenceException>(() => workingHourService.Report(nullRequest));
            Assert.Equal("You cannot send null object as parameter!", ex.Message);
        }

        [Fact]
        public async Task Report_ValidReportData_ReturnsEmptyReportResponse()
        {
            workingHourRepositoryMock.Setup(repo => repo.Report(reportRequest))
                                    .ReturnsAsync(new List<WorkingHour>());
            var result = await workingHourService.Report(reportRequest);
            Assert.Empty(result.Items);
        }
        [Fact]
        public async Task GetCalendar_ValidParameters_GeneratesCalendarResponse()
        {
            int userId = 1;
            int hoursPerWeek = 40;
            DateTime firstDay = new DateTime(2023, 1, 1);
            DateTime lastDay = new DateTime(2023, 1, 7);
            workingHourRepositoryMock.Setup(repo => repo.GetCalendar(userId, firstDay, lastDay))
                .ReturnsAsync(repositoryResponse);
            var result = await workingHourService.GetCalendar(userId, hoursPerWeek, firstDay, lastDay);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetCalendar_NonExistingWorkerId_ThrowsExceprtion()
        {
            int userId = 111;
            int hoursPerWeek = 40;
            DateTime firstDay = new DateTime(2023, 1, 1);
            DateTime lastDay = new DateTime(2023, 1, 7); 
            workingHourRepositoryMock.Setup(repo => repo.GetCalendar(userId, firstDay, lastDay))
                .Throws(new ResourceNotFoundException("Employee with that id does not exist!"));
            var ex = await Assert.ThrowsAsync<ResourceNotFoundException>(() => workingHourService.GetCalendar(userId, hoursPerWeek, firstDay, lastDay));
            Assert.Equal("Employee with that id does not exist!", ex.Message);
        }
    }
}