

using System.ComponentModel.DataAnnotations;

namespace BackendEcommerce.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
