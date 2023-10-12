using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;
using TimeSheet.WebAPI.DTOs;
using TimeSheet.WebAPI.Routes;

namespace TimeSheet.WebAPI.Controllers
{
    [ApiController]
    public class WorkingHourController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWorkingHourService _workingHourService;
        public WorkingHourController(IMapper mapper, IWorkingHourService workingHourService)
        {
            _mapper = mapper;
            _workingHourService = workingHourService;
        }
        [HttpGet(WorkingHourRoutes.WorkingHourGetAll)]
        [ProducesResponseType(typeof(List<WorkingHour>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var serviceResponse = await _workingHourService.GetAll();
            var response = _mapper.Map<List<WorkingHourResponseDTO>>(serviceResponse);
            return Ok(response);
        }
        [HttpGet(WorkingHourRoutes.WorkingHourFindByName)]
        [ProducesResponseType(typeof(WorkingHour), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string name)
        {
            var workingHour = await _workingHourService.GetByName(name);
            var result = _mapper.Map<WorkingHourResponseDTO>(workingHour);
            return Ok(result);
        }
        [HttpGet(WorkingHourRoutes.WorkingHourFindById)]
        [ProducesResponseType(typeof(WorkingHour), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var workingHour = await _workingHourService.GetById(id);
            var result = _mapper.Map<WorkingHourResponseDTO>(workingHour);
            return Ok(result);
        }
        [HttpPost(WorkingHourRoutes.WorkingHourCreate)]
        [ProducesResponseType(typeof(WorkingHour), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(int WorkerId, WorkingHourDTO workingHourDTO)
        {
            var workingHourModel = _mapper.Map<WorkingHour>(workingHourDTO);
            var createdModel = await _workingHourService.AddWorkingHour(WorkerId, workingHourModel);
            var response = new { Model = createdModel, Message = "Successfully created workingHour!" };
            return Ok(response);
        }
        [HttpPut(WorkingHourRoutes.WorkingHourUpdate)]
        [ProducesResponseType(typeof(WorkingHour), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(WorkingHourResponseDTO workingHourDTO)
        {
            var workingHourModel = _mapper.Map<WorkingHour>(workingHourDTO);
            var updatedModel = await _workingHourService.UpdateWorkingHour(workingHourModel);
            var response = new { Model = updatedModel, Message = "Successfully created workingHour!" };
            return Ok(response);
        }
        [HttpDelete(WorkingHourRoutes.WorkingHourDelete)]
        [ProducesResponseType(typeof(WorkingHour), StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            _workingHourService.DeleteWorkingHour(id);
            return Ok("Successfully deleted workingHour!");
        }
        [HttpGet(WorkingHourRoutes.WorkingHourReport)]
        [ProducesResponseType(typeof(List<WorkingHourResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetReport([FromQuery]ReportRequest reportRequest)
        {
            var serviceResponse = await _workingHourService.Report(reportRequest);
            var response = _mapper.Map<List<WorkingHourResponseDTO>>(serviceResponse);
            return Ok(response);
        }

    }
}
