using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TimeSheet.Core.Models;
using TimeSheet.WebAPI.DTOs;
using TimeSheet.WebAPI.Test.Setup;
using Xunit;

namespace TimeSheet.WebAPI.Test.Controllers
{
    public class WorkingHourControllerTest
    {
        private readonly WorkingHourControllerTestSetup testSetup;
        private List<WorkingHour> workingHours;
        private List<CalendarItem> calendarItems;
        public WorkingHourControllerTest()
        {
            testSetup = new WorkingHourControllerTestSetup();
        }
        void SeedData()
        {
            workingHours = new List<WorkingHour>
            {
                new WorkingHour { Id = 1, Date = DateTime.Now, Description = "Description 1", ProjectId = 1, CategoryId = 1, Time = 9, Overtime = 2, EmplyeeId = 2},
                new WorkingHour { Id = 2, Date = DateTime.Now, Description = "Description 2", ProjectId = 2, CategoryId = 2, Time = 3, Overtime = 0, EmplyeeId = 1},
            };
            calendarItems = new List<CalendarItem>
            {
                new CalendarItem { Date = DateTime.Parse("2023-10-01"), State = CalendarEntityState.Empty, Time = 0},
                new CalendarItem { Date = DateTime.Parse("2023-10-02"), State = CalendarEntityState.NonAchievedFullTime, Time = 5},
                new CalendarItem { Date = DateTime.Parse("2023-10-03"), State = CalendarEntityState.AchievedFullTime, Time = 10},
            };
        }

        [Fact]
        public async Task GetAll_AuthorizedUser_ReturnsData()
        {
            SeedData();
            testSetup.SetAdmin();
            testSetup.GetAllMock(workingHours);
            var result = await testSetup.WorkingHourController.GetAll();
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            var responseData = okResult.Value as List<WorkingHourResponseDTO>;
            Assert.Equal(workingHours.Count, responseData.Count);
        }
        [Fact]
        public async Task GetById_AuthorizedUser_ReturnsWorkingHour()
        {
            SeedData();
            testSetup.SetAdmin();
            int workingHourId = 1;
            testSetup.GetByIdMock(workingHours[0], workingHourId);
            var result = await testSetup.WorkingHourController.GetById(workingHourId);
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            var responseData = okResult.Value as WorkingHourResponseDTO;
            Assert.Equal(workingHours[0].Id, responseData.Id);
        }
        [Fact]
        public async Task CreateWorkingHour_AuthorizedUser_ReturnsCreatedWorkingHour()
        {
            SeedData();
            testSetup.SetWorker();
            int workerId = 8;
            var serviceRequest = new WorkingHourDTO { Date = DateTime.Now, Description = "Description 1", ProjectId = 1, CategoryId = 1, Time = 9, Overtime = 2, EmplyeeId = 2 };
            testSetup.CreateWorkingHourMock(workerId, testSetup.Mapper.Map<WorkingHour>(serviceRequest), workingHours[0]);
            var result = await testSetup.WorkingHourController.Post(serviceRequest);
            testSetup.WorkingHourServiceMock.Verify(service => service.AddWorkingHour(It.IsAny<int>(), It.IsAny<WorkingHour>()), Times.Once);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public async Task UpdateWorkingHour_AuthorizedUser_ReturnsCreatedWorkingHour()
        {
            SeedData();
            testSetup.SetWorker();
            int workerId = 8;
            var serviceRequest = new WorkingHourResponseDTO { Date = DateTime.Now, Description = "Descdesc", ProjectId = 1, CategoryId = 1, Time = 9, Overtime = 1, EmplyeeId = 2 };
            testSetup.UpdateWorkingHourMock(testSetup.Mapper.Map<WorkingHour>(serviceRequest), workingHours[0]);
            var result = await testSetup.WorkingHourController.Put(serviceRequest);
            testSetup.WorkingHourServiceMock.Verify(service => service.UpdateWorkingHour(It.IsAny<WorkingHour>()), Times.Once);
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void DeleteWorkingHour_AuthorizedUser_ReturnsCreatedWorkingHour()
        {
            SeedData();
            testSetup.SetWorker();
            int workingHourId = 1;
            testSetup.DeleteWorkingHourMock(workingHourId);
            var result = testSetup.WorkingHourController.Delete(workingHourId);
            testSetup.WorkingHourServiceMock.Verify(service => service.DeleteWorkingHour(It.IsAny<int>()), Times.Once);
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public async Task Report_AuthorizedUser_ReturnsCreatedWorkingHour()
        {
            SeedData();
            testSetup.SetWorker();
            ReportRequest reportRequest = new ReportRequest(8, 1, 1, 1, DateTime.Parse("2023-10-30"), DateTime.Parse("2023-10-01"));
            ReportResponse reportResponse = new ReportResponse { Items = workingHours, TimeSum = 14 };
            testSetup.ReportMock(reportRequest, reportResponse);
            var result = await testSetup.WorkingHourController.GetReport(reportRequest);
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            var responseData = okResult.Value as ReportResponseMapDTO;
            Assert.Equal(workingHours.Count, responseData.Items.Count);
        }
        [Fact]
        public async Task Calendar_AuthorizedUser_ReturnsCreatedWorkingHour()
        {
            SeedData();
            testSetup.SetWorker();
            var calendarResponse = new CalendarResponse { Items = calendarItems, TimeSum= 15 };
            testSetup.CalendarMock(DateTime.Parse("2023-10-30"), DateTime.Parse("2023-10-01"), 8, 40, calendarResponse);
            var result = await testSetup.WorkingHourController.GetCalendar(DateTime.Parse("2023-10-30"), DateTime.Parse("2023-10-01"));
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            var responseData = okResult.Value as CalendarResponseDTO;
            Assert.Equal(calendarItems.Count, responseData.Items.Count);
        }
    }
}