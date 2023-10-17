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
    public class ProjectController : BaseController
    {
        private readonly IProjectservice _projectService;
        public ProjectController(IMapper mapper, IProjectservice projectService) : base(mapper) 
        {
            _projectService = projectService;
        }
        [HttpGet(ProjectRoutes.ProjectGetAll)]
        [ProducesResponseType(typeof(List<Project>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var serviceResponse = await _projectService.GetAll(UserClaims);
            var response = _mapper.Map<List<ProjectResponseDTO>>(serviceResponse);
            return Ok(response);
        }
        [HttpGet(ProjectRoutes.ProjectFindByName)]
        [ProducesResponseType(typeof(Project), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(string name)
        {
            var project = await _projectService.GetByName(name);
            var result = _mapper.Map<ProjectResponseDTO>(project);
            return Ok(result);
        }
        [HttpGet(ProjectRoutes.ProjectFindById)]
        [ProducesResponseType(typeof(Project), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var project = await _projectService.GetById(id);
            var result = _mapper.Map<ProjectResponseDTO>(project);
            return Ok(result);
        }
        [Authorize(Roles = Constants.Admin)]
        [HttpPost(ProjectRoutes.ProjectCreate)]
        [ProducesResponseType(typeof(Project), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(ProjectDTO projectDTO)
        {
            var projectModel = _mapper.Map<Project>(projectDTO);
            var createdModel = await _projectService.AddProject(projectModel);
            var response = new { Model = _mapper.Map<ProjectResponseDTO>(createdModel), Message = "Successfully created project!" };
            return Ok(response);
        }
        [Authorize(Roles = Constants.Admin)]
        [HttpPut(ProjectRoutes.ProjectUpdate)]
        [ProducesResponseType(typeof(Project), StatusCodes.Status200OK)]
        public async Task<IActionResult> Put(ProjectResponseDTO projectDTO)
        {
            var projectModel = _mapper.Map<Project>(projectDTO);
            var updatedModel = await _projectService.UpdateProject(projectModel);
            var response = new { Model = _mapper.Map<ProjectResponseDTO>(updatedModel), Message = "Successfully created project!" };
            return Ok(response);
        }
        [Authorize(Roles = Constants.Admin)]
        [HttpDelete(ProjectRoutes.ProjectDelete)]
        [ProducesResponseType(typeof(Project), StatusCodes.Status200OK)]
        public IActionResult Delete(int id)
        {
            _projectService.DeleteProject(id);
            return Ok();
        }
    }
}
