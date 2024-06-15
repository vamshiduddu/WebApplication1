using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

public class UsernameAuthorizeAttributeFilter : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly string _username;

    public UsernameAuthorizeAttributeFilter(string username)
    {
        _username = username;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        //var user = context.HttpContext.User;
        //if (user.Identity.IsAuthenticated)
        //{
        //    var usernameClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
        //    if (usernameClaim != null && usernameClaim.Value == _username)
        //    {
        //        return; // Authorized
        //    }
        //}

        //// If not authorized, set the result to 401 Unauthorized
        //context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
    }
}
