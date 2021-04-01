using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyMovies.Repositories
{
    public class UsersRepository : BaseRepository<User> , IUserRepository
    {
        
        public UsersRepository(MyMoviesDbContext context) : base(context)
        {
        }

        public bool CheckIfExists(string username, string email)
        {
            return _context.Users.Any(x => x.Username == username || x.Email == email);
        }

    
        public User GetUsername(string username)
        {
            return _context.Users.FirstOrDefault(x => x.Username == username);
        }

     
    }
}
