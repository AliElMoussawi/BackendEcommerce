using BackendEcommerce.Models;

namespace BackendEcommerce.Repositories
{
    public interface UserRepository
    {
        ICollection<User> GetUsers();

        User GetUser(int id);
        User GetUser(string email);
        bool UserExist(int id);
    }
}
