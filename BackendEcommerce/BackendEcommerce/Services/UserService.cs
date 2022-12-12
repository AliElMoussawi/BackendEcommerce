using BackendEcommerce.Models;
using BackendEcommerce.Repositories;

namespace BackendEcommerce.Services
{
    public class UserService:UserRepository
    {
        private readonly AppDbContext context;
        public UserService(AppDbContext context) {
            this.context = context;
        }
        public ICollection<User> GetUsers()
        {
            return context.Users.OrderBy(p=>p.Id).ToList();
        }
    }
}
