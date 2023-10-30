using FolheandoBooks.Usuario.Model;
using FolheandoBooks.Usuario.Service;
using Microsoft.AspNetCore.Mvc;

namespace FolheandoBooks.Usuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Register model)
        {
            var result = await _userService.RegisterAsync(model);

            if (result.Succeeded)
            {
                var token = await _userService.GenerateJwtTokenAsync(model.Email, model.Password);
                if (!string.IsNullOrEmpty(token))
                {
                    return Ok(new { Token = token });
                }
            }

            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login model)
        {
            var token = await _userService.GenerateJwtTokenAsync(model.Email, model.Password);

            if (!string.IsNullOrEmpty(token))
            {
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }
    }
}