using System.IdentityModel.Tokens.Jwt;
using System.Text;
using api.Data;
using api.DTOs;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AuthenticationController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInContext, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInContext;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            var existingUser = await _userManager.FindByNameAsync(registerDTO.Username);
            if (existingUser != null) return BadRequest("Username already exists");
            var newUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = registerDTO.Username,
            };
            var result = await _userManager.CreateAsync(newUser, registerDTO.Password);
            return Ok(newUser.Id);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.Username);
            if (user == null) return BadRequest("Invalid username");
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest("Invalid username or password");
        }
    }
}
