using System.Security.Claims;
using TimeSheet.Core.Models;
using TimeSheet.WebAPI.DTOs;
using TimeSheet.WebAPI.Routes;

namespace TimeSheet.WebAPI.ExtractClaimsMiddleware
{
    public class ExtractClaimsMiddleware
    {
        private readonly RequestDelegate _next;

        public ExtractClaimsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var userIdClaim = context.User.Claims.FirstOrDefault(claim => claim.Type == "Id");
            var roleClaim = context.User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role);
            var hoursPerWeekClaim = context.User.Claims.FirstOrDefault(claim => claim.Type == "HoursPerWeek");

            if (userIdClaim != null && roleClaim != null && hoursPerWeekClaim != null)
            {
                string userId = userIdClaim.Value;
                string role = roleClaim.Value;
                string hoursPerWeek = hoursPerWeekClaim.Value;
                var userClaims = new UserClaims(userId, role, hoursPerWeek);
                context.Items[Constants.User] = userClaims;
            }

            await _next(context);
        }
    }
}
