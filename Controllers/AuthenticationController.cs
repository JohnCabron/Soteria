using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Soteria.Server.Authentication;
using Soteria.Server.Services;
using Soteria.Server.Services.Interfaces;

namespace Soteria.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticateService _authService;
        public AuthenticationController(IAuthenticateService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult RequestToken([FromBody] TokenRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string token;
            if (_authService.IsAuthenticated(request, out token))
            {
                return Ok(token);
            }

            return BadRequest("Invalid Request");
        }
    }
}