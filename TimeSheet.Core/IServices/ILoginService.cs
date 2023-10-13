using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheet.Core.Models;

namespace TimeSheet.Core.IServices
{
    public interface ILoginService
    {
        public Emplyee Login(LoginRequest loginRequest);
    }
}
