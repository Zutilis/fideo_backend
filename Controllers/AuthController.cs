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
        public async Task<ActionResult> SignInAsync([FromBody] SignInDTO signin)
        {
            return Ok(await _authService.SignIn(signin));
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> LoginAsync([FromBody] LoginDTO login)
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
