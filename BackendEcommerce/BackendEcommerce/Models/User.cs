using System.ComponentModel.DataAnnotations;
namespace BackendEcommerce.Models
{
    public class User
    {   [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Adresse mail non valide !")]
        public string? Email { get; set; }

        public Country? Country { get; set; }
        public ICollection<Review> Reviews { get; set; }

        public ICollection<Session> Sessions { get; set; }
    }
}
