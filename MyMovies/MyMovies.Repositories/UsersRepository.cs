using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System.Linq;

namespace MyMovies.Repositories
{
    public class UsersRepository : IUserRepository
    {
        private MyMoviesDbContext _context;

        public UsersRepository(MyMoviesDbContext context)
        {
            _context = context;
        }

        public User GetById(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.Id == userId);
        }

        public User GetUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}
