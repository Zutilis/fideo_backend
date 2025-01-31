using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Configurations;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class AuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly JwtSettings _jwtSettings;

        public AuthService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task SignIn(SignInDTO signInDTO)
        {
            User user = new User
            {
                FirstName = signInDTO.FirstName,
                LastName = signInDTO.LastName,
                Email = signInDTO.Email,
                UserName = signInDTO.Email
            };

            var result = await _userManager.CreateAsync(user, signInDTO.Password);

            if (result.Succeeded) return;

            throw new BadHttpRequestException(result.Errors.FirstOrDefault().Description);
        }

        public async Task CreateRole(RoleDTO roleDTO)
        {
            Role role = new Role
            {
                Description = roleDTO.Description,
                Name = roleDTO.Name
            };

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded) return;

            throw new BadHttpRequestException(result.Errors.FirstOrDefault().Description);
        }

        public async Task<string> LogIn(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);

            if (user == null)
                throw new BadHttpRequestException("Utilisateur introuvable");

            if (!await _userManager.CheckPasswordAsync(user, loginDTO.Password))
                throw new UnauthorizedAccessException("Mot de passe incorrect");

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
