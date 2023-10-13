using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Core.Exceptions;
using TimeSheet.Core.IRepositories;
using TimeSheet.Core.Models;

namespace TimeSheet.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IMapper _mapper;
        private DataContext _dataContext;
        public EmployeeRepository(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }
        public Task<Emplyee> AddEmplyee(Emplyee emplyee)
        {
            var emplyeeEntity = _mapper.Map<Entities.Emplyee>(emplyee);
            _dataContext.Employees.Add(emplyeeEntity);
            _dataContext.SaveChanges();
            var createdModel = _mapper.Map<Emplyee>(emplyeeEntity);
            return Task.FromResult(createdModel);
        }

        public void DeleteEmplyee(int id)
        {
            var existingEmplyee = _dataContext.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (existingEmplyee == null)
            {
                throw new ResourceNotFoundException("Emplyee with that id does not exist!");
            }
            _dataContext.Employees.Remove(existingEmplyee);
            _dataContext.SaveChanges();
        }

        public Task<Emplyee> GetById(int id)
        {
            var emplyeeEntity = _dataContext.Employees.Where(p => p.Id == id).FirstOrDefault();
            if (emplyeeEntity == null)
            {
                throw new ResourceNotFoundException("Emplyee with that id does not exist!");

            }
            var emplyeeModel = _mapper.Map<Emplyee>(emplyeeEntity);
            return Task.FromResult(emplyeeModel);

        }

        public Task<Emplyee> GetByName(string name)
        {
            var emplyeeEntity = _dataContext.Employees.Where(p => p.Name == name).FirstOrDefault();
            if (emplyeeEntity == null)
            {
                throw new ResourceNotFoundException("Emplyee with that name does not exist!");
            }
            var emplyeeModel = _mapper.Map<Emplyee>(emplyeeEntity);
            return Task.FromResult(emplyeeModel);
        }

        public Task<Emplyee> UpdateEmplyee(Emplyee emplyee)
        {
            var existingEmplyee = _dataContext.Employees.Where(p => p.Id == emplyee.Id).FirstOrDefault();
            if (existingEmplyee == null)
            {
                throw new ResourceNotFoundException("Emplyee with that id does not exist!");
            }
            _dataContext.Attach(existingEmplyee);
            _dataContext.Entry(existingEmplyee).CurrentValues.SetValues(emplyee);
            _dataContext.SaveChanges();
            var updatedEmplyee = _dataContext.Employees.Where(p => p.Id == emplyee.Id).FirstOrDefault();
            if (updatedEmplyee == null)
            {
                throw new ArgumentException();
            }
            var mappedEmplyee = _mapper.Map<Emplyee>(updatedEmplyee);
            return Task.FromResult(mappedEmplyee);
        }

        public Task<List<Emplyee>> GetAll()
        {
            var categories = _dataContext.Employees
                    .AsNoTracking().ToList();
            List<Emplyee> result = _mapper.Map<List<Emplyee>>(categories);
            return Task.FromResult(result);
        }
        public Task<Emplyee> AddProject(int id, Project project)
        {
            var existingEmplyee = _dataContext.Employees.Where(p => p.Id == id).FirstOrDefault();
            var existingProject = _dataContext.WorkingHours.Where(p => p.Id == 1).FirstOrDefault();
   
            _dataContext.SaveChanges();
            return Task.FromResult(_mapper.Map<Emplyee>(existingEmplyee));
            /*if (existingEmplyee == null) { throw new ResourceNotFoundException("Emplyee with that id does not exist!"); }
            if (existingEmplyee.Projects == null)
            {
                existingEmplyee.Projects = new List<Entities.Project> { _mapper.Map<Entities.Project>(project) };
            }
            existingEmplyee.Projects.Add(_mapper.Map<Entities.Project>(project));
            _dataContext.SaveChanges();
            return Task.FromResult(_mapper.Map<Emplyee>(existingEmplyee));*/



        }
    }
}
