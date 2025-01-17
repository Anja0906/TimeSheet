﻿using TimeSheet.Core.Exceptions;
using TimeSheet.Core.IRepositories;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;

namespace TimeSheet.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _emplyeeRepository;
        public EmployeeService(IEmployeeRepository emplyeeRepository)
        {
            _emplyeeRepository = emplyeeRepository;
        }
        public Task<Emplyee> AddEmplyee(Emplyee emplyee)
        {
            if (emplyee.Password == null || emplyee.Password == "")
            {
                throw new EmptyFieldException("Password must be different from ''");
            }
            var salt = PasswordHasher.GenerateSalt();
            emplyee.Salt = salt;
            emplyee.PasswordHash = PasswordHasher.HashPassword(emplyee.Password, salt);
            return _emplyeeRepository.AddEmplyee(emplyee);
        }

        public void DeleteEmplyee(int id)
        {
            _emplyeeRepository.DeleteEmplyee(id);
        }

        public Task<List<Emplyee>> GetAll()
        {
            return _emplyeeRepository.GetAll();
        }

        public Task<Emplyee> UpdateEmplyee(Emplyee emplyee)
        {
            var salt = PasswordHasher.GenerateSalt();
            emplyee.Salt = salt;
            emplyee.PasswordHash = PasswordHasher.HashPassword(emplyee.Password, salt);
            return _emplyeeRepository.UpdateEmplyee(emplyee);
        }

        public Task<Emplyee> GetByName(string name)
        {
            return _emplyeeRepository.GetByName(name);
        }

        public Task<Emplyee> GetById(int id)
        {
            return _emplyeeRepository.GetById(id);
        }

        public Task<Emplyee> AddProject(int id, Project project)
        {
            return _emplyeeRepository.AddProject(id, project);
        }
    }
}
