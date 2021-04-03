using Microsoft.EntityFrameworkCore;
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

        public override User GetById(int entityId)
        {
            var newUser = _context.Users
                .Include(x => x.Comments)
                    .ThenInclude(x => x.Movie)
                .FirstOrDefault(x => x.Id == entityId);

            return newUser;
        }

    }
}
