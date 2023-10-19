using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;
using TimeSheet.WebAPI.DTOs;
using TimeSheet.WebAPI.Routes;

namespace TimeSheet.WebAPI.Controllers
{
    [ApiController]
    public class WorkingHourController : BaseAuthorizedController
    {
        private readonly IWorkingHourService _workingHourService;

        public WorkingHourController(IMapper mapper, IWorkingHourService workingHourService)
            : base(mapper)
        {
            _workingHourService = workingHourService;
        }
        [HttpGet(WorkingHourRoutes.WorkingHourGetAll)]
        [ProducesResponseType(typeof(List<WorkingHourResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var serviceResponse = await _workingHourService.GetAll();
            var response = _mapper.Map<List<WorkingHourResponseDTO>>(serviceResponse);
            return Ok(response);
        }
        [HttpGet(WorkingHourRoutes.WorkingHourFindById)]
        [ProducesResponseType(typeof(WorkingHourResponseDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var workingHour = await _workingHourService.GetById(id);
            var result = _mapper.Map<WorkingHourResponseDTO>(workingHour);
            return Ok(result);
        }
        [HttpPost(WorkingHourRoutes.WorkingHourCreate)]
        [ProducesResponseType(typeof(WorkingHour), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(WorkingHourDTO workingHourDTO)
        {
            var workingHourModel = _mapper.Map<WorkingHour>(workingHourDTO);
            var createdModel = await _workingHourService.AddWorkingHour(UserClaims.Id, workingHourModel);
            var response = new { Model = _mapper.Map<WorkingHourResponseDTO>(createdModel), Message = "Successfully created workingHour!" };
            return Ok(response);
        }
        [HttpPut(WorkingHourRoutes.WorkingHourUpdate)]
        [ProducesResponseType(typeof(WorkingHour), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(WorkingHourResponseDTO workingHourDTO)
        {
            var workingHourModel = _mapper.Map<WorkingHour>(workingHourDTO);
            var updatedModel = await _workingHourService.UpdateWorkingHour(workingHourModel);
            var response = new { Model = _mapper.Map<WorkingHourResponseDTO>(updatedModel), Message = "Successfully created workingHour!" };
            return Ok(response);
        }
        [HttpDelete(WorkingHourRoutes.WorkingHourDelete)]
        [ProducesResponseType(typeof(WorkingHour), StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            _workingHourService.DeleteWorkingHour(id);
            return Ok();
        }
        [HttpGet(WorkingHourRoutes.WorkingHourReport)]
        [ProducesResponseType(typeof(ReportResponseMapDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetReport([FromQuery]ReportRequest reportRequest)
        {
            var serviceResponse = await _workingHourService.Report(reportRequest);
            var response = _mapper.Map<ReportResponseMapDTO>(serviceResponse);
            return Ok(response);
        }
        [HttpGet(WorkingHourRoutes.Calendar)]
        [ProducesResponseType(typeof(CalendarResponseDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCalendar(DateTime startDate, DateTime endDate)
        {
            var serviceResponse = await _workingHourService.GetCalendar(UserClaims.Id, UserClaims.HoursPerWeek, startDate, endDate);
            var response = _mapper.Map<CalendarResponseDTO>(serviceResponse);
            return Ok(response);
        }
    }
}
