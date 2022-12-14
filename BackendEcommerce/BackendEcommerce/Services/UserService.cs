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
        public User GetUser(int id) {
            return context.Users.Where(p => p.Id == id).FirstOrDefault();
        }
        public User GetUser(string email)
        {
            return context.Users.Where(p => p.Email == email).FirstOrDefault();
        }
        public bool UserExist(int id)//this function will return true if user exist 
        {
            return context.Users.Any(p => p.Id == id);
        }
    }
}
