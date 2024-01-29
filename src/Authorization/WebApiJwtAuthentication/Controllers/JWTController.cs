using Common.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApiJwtAuthentication.Models;
using WebApiJwtAuthentication.Services;

namespace WebApiJwtAuthentication.Controllers
{
    public class JWTController : ControllerBase
    {
        private readonly IJwtTokenService _jwtTokenService;

        public JWTController(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [HttpGet]
        [Route("Validate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<bool> Validate([FromHeader] string token)
        {
            return Ok(_jwtTokenService.ValidateJwtToken(token));
        }
    }
}