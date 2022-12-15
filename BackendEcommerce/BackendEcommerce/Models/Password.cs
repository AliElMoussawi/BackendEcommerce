using System.ComponentModel.DataAnnotations;

namespace BackendEcommerce.Models
{
    public class Password
    {
        [Key]
        public int  Id { get; set; }
        public User? User { get; set; }
        [Required]
        public string? HashedPassword { get; set;}

        public DateTime CreationDate { get; set; }
        public bool Valid { get; set; }
    }
}
