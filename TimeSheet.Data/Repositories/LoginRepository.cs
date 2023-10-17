using AutoMapper;
using System;
using TimeSheet.Core.Exceptions;
using TimeSheet.Core.IRepositories;
using TimeSheet.Core.Models;

namespace TimeSheet.Data.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        IMapper _mapper;
        DataContext _dataContext;

        public LoginRepository(IMapper mapper, DataContext dataContext)
        {
            _mapper = mapper;
            _dataContext = dataContext;
        }

        public Emplyee Login(LoginRequest loginRequest)
        {
            if (loginRequest == null)
            {
                throw new WrongCredentialsException("Username or password is incorect!");
            }
            var user = _dataContext.Employees.Where(e => e.Email==loginRequest.Email && e.PasswordHash==loginRequest.Password).FirstOrDefault();
            if (user == null)
            {
                throw new WrongCredentialsException("Username or password is incorect!");
            }
            var userResponse = _mapper.Map<Emplyee>(user);
            return userResponse;
        }

        public Emplyee GetUserByEmail(string email)
        {
            var user = _dataContext.Employees.FirstOrDefault(e => e.Email==email);
            var userModel = _mapper.Map<Emplyee>(user);
            return userModel;
        }
    }
}
