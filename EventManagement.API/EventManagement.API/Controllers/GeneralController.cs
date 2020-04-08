using Event.Entity;
using Event.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventManagement.API
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GeneralController : AuthorizationBase
    {
        private readonly IUserService _userService;

        public GeneralController(IUserService userService)
        {
            _userService = userService;
        }


        // GET: api/<controller>

        [HttpPost]
        [Route("authentication")]
        public IActionResult Authentication(AuthInfo model)
        {
            UserInfo user = new UserInfo();
            user = _userService.Authenticate(model.UserName, model.Password);

            if (user == null)
                return BadRequest(new { message = "User cannot be authenticated." });

            UserDTO userInfo = new UserDTO(user);
            return Ok(userInfo);
        }

    }
}
