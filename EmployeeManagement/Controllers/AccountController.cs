using EmployeeManagement.Models.Domain;
using EmployeeManagement.Models.DTOs;
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
        private readonly SignInManager<APIUser> _signInManager;

        public AccountController(SignInManager<APIUser> signInManager, UserManager<APIUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;

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
        [Route("Login")]
        public async Task<IActionResult> Login(RegisterDTO registerDTO)
        {
       
        throw new NotImplementedException(); 
        }





        }
    }
