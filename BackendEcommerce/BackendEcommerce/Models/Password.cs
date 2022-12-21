using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendEcommerce.Models
{
    public class Password
    {
        [Key]
        public int  Id { get; set; }
        public User? User { get; set; }
        [Required]
        public string? HashedPassword { get; set;}
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public bool Valid { get; set; }
    }
}
