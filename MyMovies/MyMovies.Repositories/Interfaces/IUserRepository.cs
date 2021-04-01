using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUsername(string username);

        bool CheckIfExists(string username, string email);
        
    }
}
