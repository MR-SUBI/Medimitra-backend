using MediMitra.Models;
using MediMitra.Models.Authentication.Login;
using MediMitra.Models.Authentication.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MediMitra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;
        public AuthenticationController(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;

        }
        [HttpPost]
        public async Task<ActionResult> Register([FromBody] RegisterUser registerUser, string role)
        {
            //check user exist
            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExist != null)
            {
                return StatusCode(StatusCodes.Status403Forbidden,
                   new Response { Status = "Error", Message = "User already exists!" });
            }

            //add the user in the database 
            IdentityUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.UserName,
                TwoFactorEnabled = false
            };
            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                return StatusCode(StatusCodes.Status201Created,
                 new Response { Status = "Success", Message = "User Created Successfully!" });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                 new Response { Status = "Error", Message = "User failed to create." });
            }

            //assign a role 

        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUser loginUser)
        {
            var user = await _userManager.FindByEmailAsync(loginUser.Email);
            if (user == null)
            {
                return Unauthorized(new Response { Status = "Error", Message = "Invalid email or password." });
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginUser.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return Ok(new Response { Status = "Success", Message = "Logged in successfully." });
            }

            return Unauthorized(new Response { Status = "Error", Message = "Invalid email or password." });
        }

    }

}