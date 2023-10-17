using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net.Http;
using System.Security.Claims;
using TimeSheet.Core.IRepositories;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;
using TimeSheet.WebAPI.Controllers;
using TimeSheet.WebAPI.Routes;
using Xunit;

namespace TimeSheet.WebAPI.Test
{
    public class WorkingHourControllerTest
    {
        protected Mock<IMapper> _mapper;
        protected Mock<IWorkingHourService> _workingHourServiceMock;
        protected WorkingHourController _controller;
        protected DefaultHttpContext _httpContext;

        public WorkingHourControllerTest()
        {
            _mapper = new Mock<IMapper>();
            _workingHourServiceMock = new Mock<IWorkingHourService>();
            _controller = new WorkingHourController(_mapper.Object, _workingHourServiceMock.Object);
            _httpContext = new DefaultHttpContext();
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = _httpContext
            };
        }

        [Fact]
        public async Task GetAll_AuthorizedAdminUser_ReturnsData()
        {
            var userClaims = new UserClaims(4, Role.Worker, 8);
            _httpContext.Items[Constants.User] = userClaims;
            var result = await _controller.GetAll();
            Assert.IsType<OkObjectResult>(result);
        }
        
    }
}