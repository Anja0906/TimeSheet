using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Core.Models;
using TimeSheet.WebAPI.Routes;

namespace TimeSheet.WebAPI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly IMapper _mapper;
        protected UserClaims UserClaims
        {
            get
            {
                return HttpContext.Items[Constants.User] as UserClaims;
            }
        }

        public BaseController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
