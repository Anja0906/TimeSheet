using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Core.Exceptions;
using TimeSheet.Core.IRepositories;
using TimeSheet.Core.Models;

namespace TimeSheet.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IMapper _mapper;
        private DataContext _dataContext;
        public ProjectRepository(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public Task<Project> AddProject(Project project)
        {
            var projectEntity = _mapper.Map<Entities.Project>(project);
            _dataContext.Projects.Add(projectEntity);
            _dataContext.SaveChanges();
            var createdModel = _mapper.Map<Project>(projectEntity);
            return Task.FromResult(createdModel);
        }

        public void DeleteProject(int id)
        {
            var existingProject = _dataContext.Projects.Where(x => x.Id == id).FirstOrDefault();
            if (existingProject == null)
            {
                throw new ResourceNotFoundException("Project with that id does not exist!");
            }
            _dataContext.Projects.Remove(existingProject);
            _dataContext.SaveChanges();
        }

        public Task<Project> GetById(int id)
        {
            var projectEntity = _dataContext.Projects.Where(p => p.Id == id).FirstOrDefault();
            if (projectEntity == null)
            {
                throw new ResourceNotFoundException("Project with that id does not exist!");

            }
            var projectModel = _mapper.Map<Project>(projectEntity);
            return Task.FromResult(projectModel);

        }

        public Task<Project> GetByName(string name)
        {
            var projectEntity = _dataContext.Projects.Where(p => p.Name == name).FirstOrDefault();
            if (projectEntity == null)
            {
                throw new ResourceNotFoundException("Project with that name does not exist!");
            }
            var projectModel = _mapper.Map<Project>(projectEntity);
            return Task.FromResult(projectModel);
        }

        public Task<Project> UpdateProject(Project project)
        {
            var existingProject = _dataContext.Projects.Where(p => p.Id == project.Id).FirstOrDefault();
            if (existingProject == null)
            {
                throw new ResourceNotFoundException("Project with that id does not exist!");
            }
            _dataContext.Attach(existingProject);
            _dataContext.Entry(existingProject).CurrentValues.SetValues(project);
            _dataContext.SaveChanges();
            var updatedProject = _dataContext.Projects.Where(p => p.Id == project.Id).FirstOrDefault();
            if (updatedProject == null)
            {
                throw new ArgumentException();
            }
            var mappedProject = _mapper.Map<Project>(updatedProject);
            return Task.FromResult(mappedProject);
        }

        public async Task<List<Project>> GetAll()
        {
            var categories = await _dataContext.Projects.ToListAsync();
            var result = _mapper.Map<List<Project>>(categories);
            return result;
        }

        public Task<List<Project>> GetLeadingProjects(int workerId)
        {
            var existingProject = _dataContext.Projects.Where(p => p.LeaderId == workerId).ToList();
            var result = _mapper.Map<List<Project>>(existingProject);
            return Task.FromResult(result);
        }
    }
}
