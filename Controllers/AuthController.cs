using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebApplication1.DTO;
using WebApplication1.Services;

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
        public async Task<ActionResult> SignInAsync(SignInDTO signInDTO)
        {
            await _authService.SignIn(signInDTO);
            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> LoginAsync(LoginDTO loginDTO)
        {
            return Ok(await _authService.LogIn(loginDTO));
        }

        [HttpPost]
        [Route("role/create")]
        public async Task<ActionResult> CreateRole(RoleDTO roleDTO)
        {
            await _authService.CreateRole(roleDTO);
            return Ok();
        }
    }
}
