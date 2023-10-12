using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Core.Models;

namespace TimeSheet.Core.IRepositories
{
    public interface IEmployeeRepository
    {
        Task<Emplyee> GetByName(string name);
        Task<Emplyee> UpdateEmplyee(Emplyee emplyee);
        Task<Emplyee> AddProject(int id, Project project);
        Task<List<Emplyee>> GetAll();
        Task<Emplyee> GetById(int id);
        Task<Emplyee> AddEmplyee(Emplyee emplyee);
        void DeleteEmplyee(int id);
    }
}
