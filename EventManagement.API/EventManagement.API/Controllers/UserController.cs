using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventManagement.API.Controllers
{
    public class UserController : AuthorizationBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            int result = _userService.Authenticate("admin", "admin");
            return new string[] { "value1", "value2", result.ToString() };
        }


    }
}
