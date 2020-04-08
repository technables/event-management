using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Entity;
using Event.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventManagement.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class UserController : AuthorizationBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        // GET: api/<controller>

       
    }
}
