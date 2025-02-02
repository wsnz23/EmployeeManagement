using EmployeeManagement.Models;
using EmployeeManagement.Models.Domain;
using EmployeeManagement.Models.DTOs;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<APIUser> _userManager;
        //private readonly SignInManager<APIUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IAuthManager _authManager;
        public AccountController(UserManager<APIUser> userManager, ILogger<AccountController> logger, 
            IAuthManager authManager )//, SignInManager<APIUser> signInManager
        {
            _userManager = userManager;
           // _signInManager = signInManager;
            _logger = logger;
            _authManager = authManager;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            try { 
            if (ModelState.IsValid)
            {
                BadRequest(registerDTO);
            }
            var user = new APIUser
            {
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                UserName = registerDTO.Email

            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }

            await _userManager.AddToRolesAsync(user, registerDTO.Roles);
            return Accepted();
        }
        catch(Exception ex){
            return Problem(ex.Message,statusCode:500);
            }
        }




        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto userDTO)
        {
            _logger.LogInformation($"Login Attempt for {userDTO.Email} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!await _authManager.ValidateUser(userDTO))
                {
                    return Unauthorized();
                }

                return Accepted(new TokenRequest { Token = await _authManager.CreateToken(), RefreshToken = await _authManager.CreateRefreshToken() });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(Login)}");
                return Problem($"Something Went Wrong in the {nameof(Login)}", statusCode: 500);
            }
        }
        [HttpPost]
        [Route("refreshtoken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest request)
        {
            var tokenRequest = await _authManager.VerifyRefreshToken(request);
            if (tokenRequest is null)
            {
                return Unauthorized();
            }

            return Ok(tokenRequest);
        }
    }
}