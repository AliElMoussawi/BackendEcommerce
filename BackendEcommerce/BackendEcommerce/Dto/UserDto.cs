using BackendEcommerce.Models;
using System.ComponentModel.DataAnnotations;

namespace BackendEcommerce.Dto
{
    public class UserDto
    { //no need to use it for the user model just for learning 

        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Adresse mail non valide !")]
        public string? Email { get; set; }

    }
}