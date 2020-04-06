using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManagement.API.Helper;

namespace EventManagement.API
{
    [TypeFilter(typeof(AuthorizeAnonymousAttribute))]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizationBase : ControllerBase
    {
    }
}
