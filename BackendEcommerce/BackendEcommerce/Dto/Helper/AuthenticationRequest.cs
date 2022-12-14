using System.ComponentModel.DataAnnotations;

namespace BackendEcommerce.Dto.Helper
{
    public class AuthenticationRequest
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
