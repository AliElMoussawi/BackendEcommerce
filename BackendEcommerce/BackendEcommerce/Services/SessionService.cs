using BackendEcommerce.Models;
using BackendEcommerce.Repositories;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BackendEcommerce.Services
{
    public class SessionService:SessionRepository
    {
        private readonly AppDbContext context;
        public SessionService(AppDbContext context) {
            this.context = context;
        }
        public ICollection<Session> GetSessions()
        {
            return context.Sessions.OrderBy(p=>p.Id).ToList();
        }
        public Session GetSession(int id) {
            return context.Sessions.Where(p => (p.Id == id && p.Expired == null)).FirstOrDefault();
        }
        public Session GetSession(User user)
        {
            return context.Sessions.Where(p => (p.User == user && p.Expired == null)).FirstOrDefault();
        }
        public bool SessionActive(int id)//this function will return true if Session exist 
        {
            return context.Sessions.Any((p => p.Id == id && p.Expired == null));
        }
        public bool SessionActive(User user)//this function will return true if Session exist 
        {
            return context.Sessions.Any(p =>(p.User ==user && p.Expired==null));
        }
        public Session Add(Session Session)
        {
            EntityEntry<Session> val =context.Sessions.Add(Session);
            context.SaveChanges();
            if (val != null)
            {
                return val.Entity;
            }
            return null;
        }
    }
}
