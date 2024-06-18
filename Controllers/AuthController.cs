using ExpenseSharing.Api.Models;
using ExpenseSharing.Api.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseSharing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] User obj)
        {
            if (ModelState.IsValid)
            {
                UserManagerResponseViewModel res = await _authService.RegisterUserAsync(obj);
                return Ok(res);
            }
            ModelState.AddModelError("", "invalid");
            return BadRequest(ModelState);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> LogIn([FromBody] User userObj)
        {
            if (ModelState.IsValid)
            {
                var res = await _authService.LoginUserAsync(userObj);
                var response = new { Username = userObj.Email };
                return Ok(response);
          

            }
            ModelState.AddModelError("", "Invalid Credentials");
            return BadRequest(ModelState);


        }
    }
}
