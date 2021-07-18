using EuropeLeagues.API.Authentication;
using EuropeLeagues.API.UserModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuropeLeagues.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController: ControllerBase
    {
        IJwtAuthHandler jwtAuthHandler;
        public AuthController(IJwtAuthHandler jwtAuth)
        {
            jwtAuthHandler = jwtAuth;
        }

        [HttpPost]
        public IActionResult Login([FromBody] User user)
        {
            var theuser = jwtAuthHandler.AuthenticateUser(user);
            if (theuser !=null)
            {
                var token = jwtAuthHandler.GenerateJwtToken(user);
                return Ok(new { user, token });
            }

            return BadRequest();
        }

    }
}
