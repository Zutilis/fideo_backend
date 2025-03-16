using Microsoft.AspNetCore.Mvc;
using Fideo.DTO;
using Fideo.Services;

namespace WebApplication1.Controllers
{
    public class AuthController : Controller
    {
        public readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("signin")]
        public async Task<ActionResult> SignInAsync(SignInDTO signin)
        {
            await _authService.SignIn(signin);
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> LoginAsync(LoginDTO login)
        {
            return Ok(await _authService.LogIn(login));
        }

        [HttpPost]
        [Route("role/create")]
        public async Task<ActionResult> CreateRole(RoleDTO role)
        {
            await _authService.CreateRole(role);
            return Ok();
        }
    }
}
