using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Core.Models;

namespace TimeSheet.Core.IRepositories
{
    public interface ILoginRepository
    {
        Emplyee GetUserByEmail(string email);
        public Emplyee Login(LoginRequest loginRequest);
    }
}
