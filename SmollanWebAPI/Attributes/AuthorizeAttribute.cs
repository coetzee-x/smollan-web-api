using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SmollanWebAPI.Attributes
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.Items["User"] == null)
                context.Result = new JsonResult(new { message = "Unauthorized", status = StatusCodes.Status401Unauthorized });
        }
    }
}
