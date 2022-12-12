using BackendEcommerce.Models;

namespace BackendEcommerce.Repositories
{
    public interface UserRepository
    {
        ICollection<User> GetUsers();
    }
}
