using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;
using TimeSheet.WebAPI.DTOs;
using TimeSheet.WebAPI.Routes;

namespace TimeSheet.WebAPI.Controllers
{
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _emplyeeService;
        public EmployeeController(IMapper mapper, IEmployeeService emplyeeService) : base(mapper)
        {
            _emplyeeService = emplyeeService;
        }
        [HttpGet(EmployeeRoutes.EmployeeGetAll)]
        [ProducesResponseType(typeof(List<EmployeeResponseDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var serviceResponse = await _emplyeeService.GetAll();
            var response = _mapper.Map<List<EmployeeResponseDTO>>(serviceResponse);
            return Ok(response);
        }
        [HttpGet(EmployeeRoutes.EmployeeFindByName)]
        [ProducesResponseType(typeof(Emplyee), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string name)
        {
            var emplyee = await _emplyeeService.GetByName(name);
            var result = _mapper.Map<EmployeeResponseDTO>(emplyee);
            return Ok(result);
        }
        [HttpGet(EmployeeRoutes.EmployeeFindById)]
        [ProducesResponseType(typeof(Emplyee), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var emplyee = await _emplyeeService.GetById(id);
            var result = _mapper.Map<EmployeeResponseDTO>(emplyee);
            return Ok(result);
        }
        [Authorize(Roles = Constants.Admin)]
        [HttpPost(EmployeeRoutes.EmployeeCreate)]
        [ProducesResponseType(typeof(EmployeeResponseDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(EmployeeDTO emplyeeDTO)
        {
            var emplyeeModel = _mapper.Map<Emplyee>(emplyeeDTO);
            var createdModel = await _emplyeeService.AddEmplyee(emplyeeModel);
            var response = new { Model = _mapper.Map<EmployeeResponseDTO>(createdModel), Message = "Successfully created emplyee!" };
            return Ok(response);
        }
        [Authorize(Roles = Constants.Admin)]
        [HttpPut(EmployeeRoutes.EmployeeUpdate)]
        [ProducesResponseType(typeof(Emplyee), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(EmployeeResponseDTO emplyeeDTO)
        {
            var emplyeeModel = _mapper.Map<Emplyee>(emplyeeDTO);
            var updatedModel = await _emplyeeService.UpdateEmplyee(emplyeeModel);
            var response = new { Model = _mapper.Map<EmployeeResponseDTO>(updatedModel), Message = "Successfully created emplyee!" };
            return Ok(response);
        }
        [Authorize(Roles = Constants.Admin)]
        [HttpPut(EmployeeRoutes.EmployeeSetProject)]
        [ProducesResponseType(typeof(Emplyee), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(int id, ProjectDTO projectResponseDTO)
        {
            var projectModel = _mapper.Map<Project>(projectResponseDTO);
            var updatedModel = await _emplyeeService.AddProject(id, projectModel);
            var response = new { Model = _mapper.Map<EmployeeResponseDTO>(updatedModel), Message = "Successfully added project emplyee!" };
            return Ok(response);
        }
        [Authorize(Roles = Constants.Admin)]
        [HttpDelete(EmployeeRoutes.EmployeeDelete)]
        [ProducesResponseType(typeof(Emplyee), StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            _emplyeeService.DeleteEmplyee(id);
            return Ok();
        }

    }
}
