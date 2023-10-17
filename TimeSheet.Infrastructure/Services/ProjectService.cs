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

        public Task<List<Project>> GetAll(UserClaims userClaims)
        {
            if (userClaims.Role == Role.Admin) 
            {
                return _projectRepository.GetAll();
            }

            return _projectRepository.GetLeadingProjects(userClaims.Id);
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
