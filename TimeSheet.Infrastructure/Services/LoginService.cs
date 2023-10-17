using TimeSheet.Core.Exceptions;
using TimeSheet.Core.IRepositories;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;

namespace TimeSheet.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public Emplyee Login(LoginRequest loginRequest)
        {
            Emplyee emplyee = GetUserByEmail(loginRequest.Email);
            if (emplyee == null)
            {
                throw new WrongCredentialsException("Wrong email or password!");
            }
            loginRequest.Password = CalculatePasswordHash(loginRequest.Password, emplyee.Salt);
            return _loginRepository.Login(loginRequest);
        }

        public Emplyee GetUserByEmail(string email)
        {
            return _loginRepository.GetUserByEmail(email);
        }

        private string CalculatePasswordHash(string password, string passwordSalt) 
        {
            var hashPassword = PasswordHasher.HashPassword(password, passwordSalt);
            return hashPassword;
        }
    }
}
