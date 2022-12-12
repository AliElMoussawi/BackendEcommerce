using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendEcommerce.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Token { get; set; }

        public DateTime Creation { get; set; }
        public DateTime Expired { get; set; }

        public User? User { get; set; } 
    }
}
