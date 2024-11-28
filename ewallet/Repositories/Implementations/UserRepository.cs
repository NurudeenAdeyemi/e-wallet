using ewallet.Context;
using ewallet.Entities;
using ewallet.Repositories.Interfaces;

namespace ewallet.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        protected readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User GetUser(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public bool UserExist(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }
    }
}
