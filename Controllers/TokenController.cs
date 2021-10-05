using AuthorizationService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private IAuthService authService;
        public readonly log4net.ILog log4netval;

        public TokenController(IAuthService authService)
        {
            log4netval = log4net.LogManager.GetLogger(typeof(TokenController));
            this.authService = authService;
        }

        [HttpGet]
        public IActionResult GenerateJSONWebToken()
        {
            log4netval.Info(" Http GET Request From: " + nameof(TokenController));
            string Token = authService.GetJsonWebToken();
            if (Token == null)
            {
                return BadRequest(Token);
            }
            else
            {
                return Ok(Token);
            }

        }
    }
}
