using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SlamBackend.Models;

namespace SlamBackend.DTO
{
    public class LoginDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
