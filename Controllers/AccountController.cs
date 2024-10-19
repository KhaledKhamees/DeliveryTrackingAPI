using DeliveryTrackingAPI.Models;
using DeliveryTrackingAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DeliveryTrackingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerUser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.UserName = registerUser.UserName;
                applicationUser.Email = registerUser.Email;
                IdentityResult identityResult = await _userManager.CreateAsync(applicationUser, registerUser.Password);

                if (identityResult.Succeeded)
                {
                    return Ok("User registered successfully");
                }
            }
            return BadRequest();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            // Check if the model is valid
            if (ModelState.IsValid)
            {
                // Attempt to sign in with the provided credentials
                var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);

                if (result.Succeeded)
                {
                    // Generate JWT token upon successful login
                    var user = await _userManager.FindByNameAsync(loginDto.UserName);
                    var token = await GenerateJwtToken(user);

                    return Ok(new { token });
                }
                else
                {
                    return Unauthorized("Invalid login attempt.");
                }
            }
            return BadRequest("Invalid login request.");
        }

        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            // Create the claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };

            // JWT token signing key (symmetric security key)
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Create the token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(3), 
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
