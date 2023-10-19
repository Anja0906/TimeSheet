using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;
using TimeSheet.WebAPI.Controllers;
using TimeSheet.WebAPI.Mappers;
using TimeSheet.WebAPI.Routes;

namespace TimeSheet.WebAPI.Test.Setup
{
    public class WorkingHourControllerTestSetup
    {
        public IMapper Mapper;
        public Mock<IWorkingHourService> WorkingHourServiceMock;
        public WorkingHourController WorkingHourController;
        public DefaultHttpContext HttpContext;

        public WorkingHourControllerTestSetup()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });
            Mapper = configuration.CreateMapper();
            WorkingHourServiceMock = new Mock<IWorkingHourService>();
            WorkingHourController = new WorkingHourController(Mapper, WorkingHourServiceMock.Object);
            HttpContext = new DefaultHttpContext();
            WorkingHourController.ControllerContext = new ControllerContext
            {
                HttpContext = HttpContext
            };
        }
        public void SetAdmin()
        {
            var userClaims = new UserClaims(4, Role.Admin, 35);
            HttpContext.Items[Constants.User] = userClaims;
        }
        public void SetWorker()
        {
            var userClaims = new UserClaims(8, Role.Worker, 40);
            HttpContext.Items[Constants.User] = userClaims;
        }

        public void GetAllMock(List<WorkingHour> serviceResponseData)
        {
            WorkingHourServiceMock.Setup(service => service.GetAll()).ReturnsAsync(serviceResponseData);
        }
        public void GetByIdMock(WorkingHour serviceResponseData, int id)
        {
            WorkingHourServiceMock.Setup(service => service.GetById(id)).ReturnsAsync(serviceResponseData);
        }
        public void CreateWorkingHourMock(int workerId, WorkingHour requestData, WorkingHour serviceResponseData)
        {
            WorkingHourServiceMock.Setup(service => service.AddWorkingHour(workerId, requestData)).ReturnsAsync(serviceResponseData);
        }
        public void UpdateWorkingHourMock(WorkingHour requestData, WorkingHour serviceResponseData)
        {
            WorkingHourServiceMock.Setup(service => service.UpdateWorkingHour(requestData)).ReturnsAsync(serviceResponseData);
        }
        public void DeleteWorkingHourMock(int id)
        {
            WorkingHourServiceMock.Setup(service => service.DeleteWorkingHour(id));
        }
        public void ReportMock(ReportRequest reportRequest, ReportResponse reportResponse)
        {
            WorkingHourServiceMock.Setup(service => service.Report(reportRequest)).ReturnsAsync(reportResponse);
        }
        public void CalendarMock(DateTime startDate, DateTime endDate, int workerId, int hoursPerWeek, CalendarResponse calendarResponse)
        {
            WorkingHourServiceMock.Setup(service => service.GetCalendar(workerId, hoursPerWeek, startDate, endDate)).ReturnsAsync(calendarResponse);
        }
        
    }
}
