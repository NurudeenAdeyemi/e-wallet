using ewallet.Entities;

namespace ewallet.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUser(string email);
        bool UserExist(string email);
        IEnumerable<User> GetUsers();
    }
}
