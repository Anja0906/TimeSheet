using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Core.Models;
using TimeSheet.WebAPI.Routes;

namespace TimeSheet.WebAPI.Controllers
{
    [Authorize]
    public class BaseAuthorizedController : Controller
    {
        protected readonly IMapper _mapper;
        protected UserClaims UserClaims => HttpContext.Items[Constants.User] as UserClaims;

        public BaseAuthorizedController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
