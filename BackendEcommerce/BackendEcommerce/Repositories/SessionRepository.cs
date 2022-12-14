using BackendEcommerce.Models;

namespace BackendEcommerce.Repositories
{
    public interface SessionRepository
    {
        ICollection<Session> GetSessions();

        Session GetSession(int id);
        Session GetSession(User user);
        bool SessionActive(int id);
        bool SessionActive(User user);
        Session Add(Session Session);
    }
}
