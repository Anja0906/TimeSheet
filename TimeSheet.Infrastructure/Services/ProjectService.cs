using TimeSheet.Core.IRepositories;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;

namespace TimeSheet.Service.Services
{
    public class ProjectService : IProjectservice
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public Task<Project> AddProject(Project project)
        {
            return _projectRepository.AddProject(project);
        }

        public void DeleteProject(int id)
        {
            _projectRepository.DeleteProject(id);
        }

        public Task<List<Project>> GetAll()
        {
            return _projectRepository.GetAll();
        }

        public Task<Project> UpdateProject(Project project)
        {
            return _projectRepository.UpdateProject(project);
        }

        public Task<Project> GetByName(string name)
        {
            return _projectRepository.GetByName(name);
        }

        public Task<Project> GetById(int id)
        {
            return _projectRepository.GetById(id);
        }
    }
}
