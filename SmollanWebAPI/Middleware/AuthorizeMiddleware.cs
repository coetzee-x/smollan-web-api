using SmollanWebAPI.Services.UserService;
using System.Text;

namespace SmollanWebAPI.Middleware
{
    public class AuthorizeMiddleware
    {
        private RequestDelegate _requestDelegate;
        public AuthorizeMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public Task Invoke
            (
            HttpContext context,
            IUserService userService
            )
        {
            var authorization = context.Request.Headers.Authorization;

            if (authorization.Any())
            {
                var authorizationBytes = Convert.FromBase64String(authorization[0].Remove(0, 5).Trim());
                var userNameAndPassword = Encoding.UTF8.GetString(authorizationBytes);
                var username = userNameAndPassword.Split(':')[0];
                var password = userNameAndPassword.Split(':')[1];

                context.Items["User"] = userService.AuthorizeUser(username, password);
            }

            return _requestDelegate(context);
        }
    }
}
