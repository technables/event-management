using Event.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace EventManagement.API.Helper
{
    public class AuthorizeAnonymousAttribute : IAuthorizationFilter
    {
        public AuthorizeAnonymousAttribute()
        {

        }

        void IAuthorizationFilter.OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                string clientID = context.HttpContext.Request?.Headers["ClientCode"];

                if (clientID != "event-management")
                {
                    context.Result = new UnauthorizedObjectResult(new UserAuthenticateResponse
                    {
                        IsAuthenticate = false,
                        StatusCode = StatusCode.NotAllowed,
                        Message = ConstantMessages.InvalidClient
                    });
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
