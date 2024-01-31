using Common.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using WebApiJwtAuthentication.Logging;
using WebApiJwtAuthentication.Models;
using WebApiJwtAuthentication.Publishers.Interfaces;
using WebApiJwtAuthentication.Services;

namespace WebApiJwtAuthentication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IClaimsService _claimsService;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IPublisherRabbitMQ _publisher;

        public UserController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
			SignInManager<ApplicationUser> signInManager,
			IClaimsService claimsService,
            IJwtTokenService jwtTokenService,
            IPublisherRabbitMQ publisher)
        {
            _userManager = userManager;
            _roleManager = roleManager;
			_signInManager = signInManager;
			_claimsService = claimsService;
            _jwtTokenService = jwtTokenService;
            _publisher = publisher;
        }



        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register([FromBody] UserRegisterDTO userRegisterDTO)
        {
            SimpleLogger.Instance.Log(SimpleLogger.Level.INFO, "Registration request");

            IdentityResult result;

            ApplicationUser newUser = new()
            {
                Email = userRegisterDTO.Email,
                UserName = userRegisterDTO.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            result = await _userManager.CreateAsync(newUser, userRegisterDTO.Password);

            if (!result.Succeeded)
                return Conflict(new UserRegisterResultDTO
                {
                    Succeeded = result.Succeeded,
                    Errors = result.Errors.Select(e => e.Description)
                });

            await SeedRoles();
            result = await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            await _publisher.SendUpdateUser(userRegisterDTO.Email);

            return CreatedAtAction(nameof(Register), new UserRegisterResultDTO { Succeeded = true });
        }

        private async Task SeedRoles()
        {
            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            {
                await _roleManager.CreateAsync(new ApplicationRole(UserRoles.User));
            }

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _roleManager.CreateAsync(new ApplicationRole(UserRoles.User));
            }
        }




        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            SimpleLogger.Instance.Log(SimpleLogger.Level.INFO, "Login request");

            var user = await _userManager.FindByEmailAsync(userLoginDTO.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, userLoginDTO.Password))
            {
                var userClaims = await _claimsService.GetUserClaimsAsync(user);

                var token = _jwtTokenService.GetJwtToken(userClaims);

                return Ok(new UserLoginResultDTO
                {
                    Succeeded = true,
                    Token = new TokenDTO
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo
                    }
                });
            }

            return Unauthorized(new UserLoginResultDTO
            {
                Succeeded = false,
                Message = "The email and password combination was invalid."
            });
        }

		[HttpPost]
		[Route("logout")]
		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();

			return NoContent();
		}

	}
}
