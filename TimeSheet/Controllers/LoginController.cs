using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TimeSheet.Core.Exceptions;
using TimeSheet.Core.IServices;
using TimeSheet.Core.Models;
using TimeSheet.WebAPI.DTOs;
using TimeSheet.WebAPI.Routes;

namespace TimeSheet.WebAPI.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private ILoginService _loginService;
        private IMapper _mapper;
        public LoginController(IMapper mapper, IConfiguration config, ILoginService loginService)
        {
            _mapper = mapper;
            _config = config;
            _loginService = loginService;
        }

        [HttpPost(Constants.LoginRoute)]
        public IActionResult Post([FromBody] LoginRequestDTO loginRequest)
        {
            var userRequest = _mapper.Map<LoginRequest>(loginRequest);
            var user = _loginService.Login(userRequest);
            if (user == null)
            {
                throw new WrongCredentialsException("Username or password is incorect!");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim("HoursPerWeek", user.HoursPerWeek.ToString())
            };

            var Sectoken = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

            return Ok(token);
        }
    }
}
